-- database postgres, port 5432, dla poprawnego domyślnego działania aplikacji
-- w projekcie nie użyto żadnych transakcji - nie ma sensownego zastosowania dla nich

CREATE TABLE users (
	user_id SERIAL PRIMARY KEY NOT NULL,
	username VARCHAR(100) UNIQUE NOT NULL,
	password VARCHAR(20) CONSTRAINT zle_haslo check(length(password) < 20 AND length(password) > 4),
	name VARCHAR(100) NOT NULL,
	surname VARCHAR(100) NOT NULL);

CREATE TABLE friends (
    user_id INT,
    friend_id INT,
    status VARCHAR(20) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id, friend_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (friend_id) REFERENCES users(user_id) ON DELETE CASCADE,
    CONSTRAINT status_check CHECK (status IN ('requested', 'accepted', 'blocked')),
	CONSTRAINT self_friend CHECK (user_id <> friend_id));

CREATE TABLE messages(
	message_id SERIAL,
	message_text_content TEXT NOT NULL,
	message_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	sender_id INTEGER,
	receiver_id INTEGER);

-- Grupa do której dołączają wszyscy userzy - pozwala na umieszczanie danych w messages

CREATE GROUP user_group;
GRANT INSERT on messages TO user_group;
GRANT ALL PRIVILEGES ON messages_message_id_seq TO user_group;		-- all privileges czy tylko read wystarczy?

-- Specjalni userzy pozwalają na czynności którymi są nazwani. Niestety dla usuwania użytkowników nie jestem w stanie znależć innego rozwiązania jak nadać mu prawa superusera

-- Specjalny user w bazie danych, którym sprawdzane jest połączenie z bazą danych - nie wymaga żadnych specjalnych uprawnień

CREATE USER testconnection PASSWORD 'testConnection';

-- Specjalny user w bazie danych, który usuwa użytkowników

CREATE USER userdeleater PASSWORD 'userDeleater' SUPERUSER;
--GRANT USAGE ON SCHEMA public TO userdeleater;
--GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO userdeleater;
--GRANT DELETE ON ALL TABLES IN SCHEMA public TO userdeleater;
--GRANT DROP ON SCHEMA public TO userdeleater;

-- Specjalny user który będzie logować się do bazy danych i tworzyć nowych użytkowników
-- Jeżeli schema jest inna niż public, trzeba zmodyfikować poniższe granty
-- CREATEROLE pozwala tworzyć role (użytkowników bazy danych)

CREATE USER usercreator PASSWORD 'userCreator' SUPERUSER;			-- zamiast SUPERUSER CREATEROLE
-- Ogólnie to poddaje się, nie wiem jak pozwolić mu dodawać do grup bez nadawania mu superusera
-- GRANT USAGE, CREATE ON SCHEMA public TO usercreator;
-- GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO usercreator;  -- sequences, czyli specjalne tabele tworzone gdy używa się np. serial (autonumeracji)
-- GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO usercreator;



CREATE OR REPLACE FUNCTION username_to_id(IN v_username varchar) RETURNS INTEGER AS $$
DECLARE
v_id INTEGER;
BEGIN

SELECT user_id 
INTO v_id
FROM users
WHERE username = v_username;

IF NOT FOUND THEN
	RAISE EXCEPTION 'Nie znaleziono id użytkownika o nazwie: (%)', v_username;
END IF;

RETURN v_id;
END $$ LANGUAGE PLPGSQL SECURITY DEFINER;

-- Dałoby rade przekształcić funkcjse is_friend() na taką że współpracowałaby z triggerem i dałoby się ją normalnie wywołać, ale stworzyłem osobną funkcję
-- Funkcja zwraca:
-- 0 gdy nie jest sie znajomym
-- 1 aktywny użytkownik wysłał zaproszenie do znajomych
-- 2 gdy ten drugi użytkownik wysłał zaproszenie
-- 3 aktywny użytkownik zablokował użytkownika
-- 4 gdy ten drugi użytkownik zablokował nas
-- 5 gdy jest się znajomymi

CREATE OR REPLACE FUNCTION is_friend2(v_sender_id INTEGER, v_receiver VARCHAR) RETURNS INTEGER LANGUAGE PLPGSQL SECURITY DEFINER AS $$
DECLARE
v_receiver_id INTEGER;
v_your_status VARCHAR;
v_his_status VARCHAR;
BEGIN

v_receiver_id := username_to_id(v_receiver);

SELECT status
INTO v_your_status
FROM friends
WHERE user_id = v_sender_id AND friend_id = v_receiver_id;

SELECT status
INTO v_his_status
FROM friends
WHERE user_id = v_receiver_id AND friend_id = v_sender_id;

IF(v_your_status IS NULL AND v_his_status IS NULL)  THEN
RETURN 0;
ELSEIF(v_your_status = 'requested') THEN
RETURN 1;
ELSEIF(v_his_status = 'requested') THEN
RETURN 2;
ELSEIF(v_your_status = 'blocked') THEN
RETURN 3;
ELSEIF(v_his_status = 'blocked') THEN
RETURN 4;
END IF;
RETURN 5;
END $$;

-- Trigger sprawdzający czy użytkownicy są znajomymi
-- Sprawdzanie czy użytkownik aplikacji jest użytkownikiem w bazie, który wysyła wiadomość, jest zrobione po stronie aplikacji

CREATE OR REPLACE FUNCTION is_friend() RETURNS trigger AS $$
DECLARE
v_your_status varchar;
v_his_status varchar;
BEGIN

SELECT status
INTO v_your_status
FROM friends
WHERE user_id = NEW.sender_id AND friend_id = NEW.receiver_id;

SELECT status
INTO v_his_status
FROM friends
WHERE user_id = NEW.receiver_id AND friend_id = NEW.sender_id;

IF(v_your_status IS NULL AND v_his_status IS NULL)  THEN
RAISE EXCEPTION 'Nie jesteś znajomym użytkownika';
ELSEIF(v_your_status = 'requested') THEN
RAISE EXCEPTION 'Użytkownik nie dodał cię jeszcze do znajomych';
ELSEIF(v_his_status = 'requested') THEN
RAISE EXCEPTION 'Użytkownik wysłał zaproszenie do znajomych';
ELSEIF(v_your_status = 'blocked') THEN
RAISE EXCEPTION 'Zablokowałeś użytkownika';
ELSEIF(v_his_status = 'blocked') THEN
RAISE EXCEPTION 'Użytkownik zablokował cię';
END IF;
RETURN NEW;
END;
$$ LANGUAGE PLPGSQL SECURITY DEFINER;			-- SECURITY DEFINER pozwala na wykonanie funkcji z prawami właściciela funkcji (superuser tworzący bazę danych), a nie użytkownika używającego funkcji.

CREATE OR REPLACE TRIGGER at_insert_message_check_is_friends BEFORE INSERT OR UPDATE ON messages
FOR EACH ROW EXECUTE PROCEDURE is_friend();

-- Trigger sprawdzający czy wiadomość jest pusta - taka sama funkcjonalność jest w kodzie C#, ale "przezorny zawsze ubezpieczony"

CREATE OR REPLACE FUNCTION check_null() RETURNS trigger AS $$
DECLARE
BEGIN
if (NEW.message_text_content = '' OR NEW.message_text_content IS NULL) THEN
RAISE EXCEPTION 'Wiadomość nie może być pusta!';
END IF;
RETURN NEW;
END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE TRIGGER at_insert_message_check_null BEFORE INSERT OR UPDATE ON messages
FOR EACH ROW EXECUTE PROCEDURE check_null();


-- Przykładowe dane do bazy danych:
-- Przykładowi użytkownicy:

insert into users(username, password, name, surname)
values('Andrju', 'password123', 'Andrzej', 'Deczko');
CREATE USER Andrju PASSWORD 'password123';
CREATE VIEW view_Andrju_list_messages AS				-- Pozwala użytkownikowi na odczytywanie swoich wiadomości
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Andrju_read_users AS					-- Pozwala użytkownikowi na odczytywanie userów (z pominięciem ich haseł i innych danych w tabeli)
SELECT user_id, username from users;
CREATE VIEW view_Andrju_read_friends AS					-- Pozwala użytkownikowi na odczytywanie swoich znajomych
SELECT * FROM friends
WHERE user_id = 1 OR friend_id = 1;
GRANT SELECT, UPDATE, INSERT ON view_Andrju_read_friends TO Andrju;
GRANT SELECT ON view_Andrju_list_messages TO Andrju;
GRANT SELECT ON View_Andrju_read_users TO Andrju;
ALTER GROUP user_group ADD USER Andrju;					-- Dodaje użytkownika do grupy pozwalającej pisać wiadomości

insert into users(username, password, name, surname)
values('Mateo', 'Grucha142', 'Mateusz', 'Pikora');
CREATE USER Mateo PASSWORD 'Grucha142';
CREATE VIEW view_Mateo_list_messages AS
SELECT * FROM messages
WHERE sender_id = 2 OR receiver_id = 2;
CREATE VIEW view_Mateo_read_users AS
SELECT user_id, username from users;
CREATE VIEW view_Mateo_read_friends AS
SELECT * FROM friends
WHERE user_id = 2 OR friend_id = 2;
GRANT SELECT, UPDATE, INSERT ON view_Mateo_read_friends TO Mateo;
GRANT SELECT ON View_Mateo_list_messages TO Mateo;
GRANT SELECT ON View_Mateo_read_users TO Mateo;
ALTER GROUP user_group ADD USER Mateo;

insert into users(username, password, name, surname)
values('Filipo', '232gamaciko', 'Filip', 'Morczynski');
CREATE USER Filipo PASSWORD '232gamaciko';
CREATE VIEW view_Filipo_list_messages AS
SELECT * FROM messages
WHERE sender_id = 3 OR receiver_id = 3;
CREATE VIEW view_Filipo_read_users AS
SELECT user_id, username from users;
CREATE VIEW view_Filipo_read_friends AS
SELECT * FROM friends
WHERE user_id = 3 OR friend_id = 3;
GRANT SELECT, UPDATE, INSERT ON view_Filipo_read_friends TO Filipo;
GRANT SELECT ON View_Filipo_list_messages TO Filipo;
GRANT SELECT ON View_Filipo_read_users TO Filipo;
ALTER GROUP user_group ADD USER Filipo;

insert into users(username, password, name, surname)
values('Greg', 'maslo232', 'Grzegorz', 'Duszynski');
CREATE USER Greg PASSWORD 'maslo232';
CREATE VIEW view_Greg_list_messages AS
SELECT * FROM messages
WHERE sender_id = 4 OR receiver_id = 4;
CREATE VIEW view_Greg_read_users AS
SELECT user_id, username from users;
CREATE VIEW view_Greg_read_friends AS
SELECT * FROM friends
WHERE user_id = 4 OR friend_id = 4;
GRANT SELECT, UPDATE, INSERT ON view_Greg_read_friends TO Greg;
GRANT SELECT ON View_Greg_list_messages TO Greg;
GRANT SELECT ON View_Greg_read_users TO Greg;
ALTER GROUP user_group ADD USER Greg;

insert into users(username, password, name, surname)
values('Orion', 'husaria192', 'Olaf', 'DiriDiri');
CREATE USER Orion PASSWORD 'husaria192';
CREATE VIEW view_Orion_list_messages AS
SELECT * FROM messages
WHERE sender_id = 5 OR receiver_id = 5;
CREATE VIEW view_Orion_read_users AS
SELECT user_id, username from users;
CREATE VIEW view_Orion_read_friends AS
SELECT * FROM friends
WHERE user_id = 5 OR friend_id = 5;
GRANT SELECT, UPDATE, INSERT ON view_Orion_read_friends TO Orion;
GRANT SELECT ON View_Orion_list_messages TO Orion;
GRANT SELECT ON View_Orion_read_users TO Orion;
ALTER GROUP user_group ADD USER Orion;

insert into users(username, password, name, surname)
values('Kapa', 'xxxBbBxxx0', 'Kacper', 'Bednarek');
CREATE USER Kapa PASSWORD 'xxxBbBxxx0';
CREATE VIEW view_Kapa_list_messages AS
SELECT * FROM messages
WHERE sender_id = 6 OR receiver_id = 6;
CREATE VIEW view_Kapa_read_users AS
SELECT user_id, username from users;
CREATE VIEW view_Kapa_read_friends AS
SELECT * FROM friends
WHERE user_id = 6 OR friend_id = 6;
GRANT SELECT, UPDATE, INSERT ON view_Kapa_read_friends TO Kapa;
GRANT SELECT ON View_Kapa_list_messages TO Kapa;
GRANT SELECT ON View_Kapa_read_users TO Kapa;
ALTER GROUP user_group ADD USER Kapa;

-- Przykładowe relacje pomiędzy użytkownikami:

insert into friends(user_id, friend_id, status)
values(1, 2, 'accepted');
insert into friends(user_id, friend_id, status)
values(2, 1, 'accepted');
insert into friends(user_id, friend_id, status)
values(2, 3, 'requested');


insert into friends(user_id, friend_id, status)
values(5, 6, 'accepted');
insert into friends(user_id, friend_id, status)
values(6, 5, 'accepted');
insert into friends(user_id, friend_id, status)
values(1, 5, 'accepted');
insert into friends(user_id, friend_id, status)
values(5, 1, 'accepted');
insert into friends(user_id, friend_id, status)
values(1, 3, 'blocked');
insert into friends(user_id, friend_id, status)
values(1, 4, 'requested');


-- Przykładowe wiadomości:

insert into messages(message_text_content, sender_id, receiver_id)
values('Piwo?', 1, 2);
insert into messages(message_text_content, sender_id, receiver_id)
values('piwo', 2, 1);
insert into messages(message_text_content, sender_id, receiver_id)
values('O której?', 1, 2);
insert into messages(message_text_content, sender_id, receiver_id)
values('Nie wiem, 19:00?', 2, 1);
insert into messages(message_text_content, sender_id, receiver_id)
values('OK, będe czekać pod starym browarem', 1, 2);
insert into messages(message_text_content, sender_id, receiver_id)
values('Albo nie, pod Avenidą', 1, 2);

insert into messages(message_text_content, sender_id, receiver_id)
values('Żyjesz?', 5, 6);
insert into messages(message_text_content, sender_id, receiver_id)
values('No żyje', 6, 5);
insert into messages(message_text_content, sender_id, receiver_id)
values('Coś sie stało?', 6, 5);
insert into messages(message_text_content, sender_id, receiver_id)
values('Masz kase?', 5, 1);







---- USUWANIE BAZY DANYCH
-- Do poprawnego usunięcia bazy, trzeba usunąć użytkowników bazy danych (bazy danych, nie zawartości tabeli users) stworzonych w trakcie pracy programu. Na razie robie to manualnie w pgadmin, może uda się zrobić funkcje składowaną która będzie to wykonywać
-- Nie ma takiego problemu przy usuwaniu usera z poziomu aplikacji, tylko przy "czystce" w trakcie testów - usuwania całej zawartości bazy


DELETE FROM friends CASCADE;
DROP TABLE friends CASCADE;
DELETE FROM users CASCADE;
DROP TABLE users CASCADE;
DELETE FROM messages CASCADE;
DROP TABLE messages CASCADE;
-- DROP TRIGGER at_insert_message_check_is_friends on messages; -- Nie potrzeba usuwać tego triggera gdy kaskadowo usuwamy messages - jest usuwany przy usuwaniu messages
DROP FUNCTION is_friend();
-- DROP TRIGGER at_insert_message_check_null on messages;  -- Tak samo jak wyżej
DROP FUNCTION check_null();

REVOKE ALL PRIVILEGES ON ALL TABLES IN SCHEMA public FROM testconnection;
REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public FROM testconnection;
REVOKE ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public FROM testconnection;
REVOKE ALL ON SCHEMA public FROM testconnection;
DROP USER testconnection;

REVOKE ALL PRIVILEGES ON ALL TABLES IN SCHEMA public FROM usercreator;
REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public FROM usercreator;
REVOKE ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public FROM usercreator;
REVOKE ALL ON SCHEMA public FROM usercreator;
DROP USER usercreator;

REVOKE ALL PRIVILEGES ON ALL TABLES IN SCHEMA public FROM userdeleater;
REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public FROM userdeleater;
REVOKE ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public FROM userdeleater;
REVOKE ALL ON SCHEMA public FROM userdeleater;
DROP USER userdeleater;

DROP GROUP user_group;
DROP USER andrju;
DROP USER mateo;
DROP USER filipo;
DROP USER greg;
DROP USER orion;
DROP USER kapa;

------------------------------------------
-- Funkcje przed modyfikacją - aktualnie sprawdzają czy którykolwiek z userów jest znajomym/zablokowanym

CREATE OR REPLACE FUNCTION username_to_id(IN v_username varchar) RETURNS INTEGER AS $$
DECLARE
v_id INTEGER;
BEGIN

SELECT user_id 
INTO v_id
FROM users
WHERE username = v_username;

IF NOT FOUND THEN
	RAISE EXCEPTION 'Nie znaleziono id użytkownika o nazwie: (%)', v_username;
END IF;

RETURN v_id;
END $$ LANGUAGE PLPGSQL SECURITY DEFINER;

-- Dałoby rade przekształcić funkcjse is_friend() na taką że współpracowałaby z triggerem i dałoby się ją normalnie wywołać, ale stworzyłem osobną funkcję
-- Funkcja zwraca 0 gdy nie jest sie znajomym, 1 gdy jest sie w fazie request, 2 gdy jest sie zablokowanym, 3 gdy jest sie znajomym

CREATE OR REPLACE FUNCTION is_friend2(v_sender_id INTEGER, v_receiver VARCHAR) RETURNS INTEGER LANGUAGE PLPGSQL SECURITY DEFINER AS $$
DECLARE
v_receiver_id INTEGER;
v_status VARCHAR;
v_status_2 VARCHAR;
BEGIN

v_receiver_id := username_to_id(v_receiver);

SELECT status
INTO v_status
FROM friends
WHERE user_id = v_sender_id AND friend_id = v_receiver_id;

SELECT status
INTO v_status_2
FROM friends
WHERE user_id = v_receiver_id AND friend_id = v_sender_id;

IF(v_status IS NULL AND v_status_2 IS NULL) THEN
RETURN 0;
ELSEIF(v_status = 'requested' OR v_status_2 = 'requested') THEN
RETURN 1;
ELSEIF(v_status = 'blocked' OR v_status_2 = 'blocked') THEN
RETURN 2;
END IF;
RETURN 3;
END $$;

-- Trigger sprawdzający czy użytkownicy są znajomymi
-- Sprawdzanie czy użytkownik aplikacji jest użytkownikiem w bazie, który wysyła wiadomość, jest zrobione po stronie aplikacji

CREATE OR REPLACE FUNCTION is_friend() RETURNS trigger AS $$
DECLARE
v_status varchar;
v_status_2 varchar;
BEGIN

SELECT status
INTO v_status
FROM friends
WHERE user_id = NEW.sender_id AND friend_id = NEW.receiver_id;

SELECT status
INTO v_status_2
FROM friends
WHERE user_id = NEW.receiver_id AND friend_id = NEW.sender_id;

IF(v_status IS NULL AND v_status_2 IS NULL)  THEN
RAISE EXCEPTION 'Nie jesteś znajomym użytkownika';
ELSEIF(v_status = 'requested' OR v_status_2 = 'requested') THEN
RAISE EXCEPTION 'Użytkownik nie dodał cię jeszcze do znajomych';
ELSEIF(v_status = 'blocked' OR v_status_2 = 'blocked') THEN
RAISE EXCEPTION 'Użytkownik zablokował cię (lub ty go)';
END IF;
RETURN NEW;
END;
$$ LANGUAGE PLPGSQL SECURITY DEFINER;			-- SECURITY DEFINER pozwala na wykonanie funkcji z prawami właściciela funkcji (superuser tworzący bazę danych), a nie użytkownika używającego funkcji.
------------------------------------------

-- dobra, wiadomość dla mnie, userzy w postgresie ZAWSZE są z małej litery...

-- te uprawnienia na dole są potrzebne żeby można było wysyłać wiadomości
-- GRANT INSERT ON messages TO {user}; ORAZ
-- GRANT UPDATE ON messages_message_id_seq to {user};

-- -- Proces tworzenia usera w bazie danych i aplikacji.
-- -- Nazwę usera zapisujemy do zmiennej {username} w C#, tak samo hasło i potem tym zapytaniem przekazujemy do DBMS.

-- create user {username} Password '{password}';

-- -- Teraz sprawdzamy zapytaniem sql jakie ma user_id i zapisujemy je do zmiennej {id}

-- SELECT user_id FROM users
-- WHERE username = {username}

-- -- Tworzymy perspektywę pozwalającą na odczytywanie wiadomości i odczytywanie username (potrzebne będzie do pisania wiadomości).
-- -- Samo pisanie wiadomości zrobione zostanie w C# (tam będzie sprawdzanie), ale można też zrobić to jako funkcje składowane.
-- CREATE VIEW view_{username}_list_messages AS
-- SELECT * FROM messages
-- WHERE sender_id = {id} OR receiver_id = {id};

-- CREATE VIEW view_{username}_read_users AS
-- SELECT user_id, username from users;

-- -- Dajemy zezwolenie użytkownikowi do przeglądania jego perspektyw.

-- GRANT SELECT ON View_{username}_list_messages TO {username};
-- GRANT SELECT ON View_{username}_read_users TO {username};


--------------------------------------- Kiedyś do zrobienia
-- CREATE TABLE groups(
-- 	id SERIAL,
-- 	group_name TEXT,
-- 	group_users INTEGER);
