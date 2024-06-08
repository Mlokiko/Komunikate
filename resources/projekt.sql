-- database postgres, port 5432, dla poprawnego domyślnego działania aplikacji

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
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (friend_id) REFERENCES users(user_id),
    CONSTRAINT status_check CHECK (status IN ('requested', 'accepted', 'blocked')));
	--CONSTRAINT self_friend CHECK (user_id <> friend_id)); --- Czy potrzebne?

CREATE TABLE messages(
	message_id SERIAL,
	message_text_content TEXT NOT NULL,
	message_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	sender_id INTEGER,
	receiver_id INTEGER);


-- Specjalny user w bazie danych, którym sprawdzane jest połączenie z bazą danych - nie wymaga żadnych specjalnych uprawnień

CREATE USER testconnection PASSWORD 'testConnection';


-- Specjalny user który będzie logować się do bazy danych i tworzyć nowych użytkowników
-- Jeżeli schema jest inna niż public, trzeba zmodyfikować poniższe granty
-- CREATEROLE pozwala tworzyć role (użytkowników bazy danych)
-- Chyba wystarczy tylko all privileges on all tables, albo i mniej, zobaczy sie

CREATE USER usercreator PASSWORD 'userCreator' CREATEROLE;
GRANT USAGE, CREATE ON SCHEMA public TO usercreator;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO usercreator;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO usercreator;


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
RAISE EXCEPTION 'Użytkownik zablokował cię';
END IF;
-- RAISE NOTICE 'jesteście znajomymi';			-- tylko do sprawdzenia czy funkcja działa
RETURN NULL;
END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE TRIGGER at_insert_message_check_is_friends BEFORE INSERT OR UPDATE ON messages
FOR EACH ROW EXECUTE PROCEDURE is_friend();

-- Trigger sprawdzający czy wiadomość jest pusta

CREATE OR REPLACE FUNCTION check_null() RETURNS trigger AS $$
DECLARE
BEGIN
if (NEW.message_text_content = '' OR NEW.message_text_content IS NULL) THEN
RAISE EXCEPTION 'Wiadomość nie może być pusta!';
END IF;
RETURN NULL;
END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE TRIGGER at_insert_message_check_null BEFORE INSERT OR UPDATE ON messages
FOR EACH ROW EXECUTE PROCEDURE check_null();


-- Przykładowe dane do bazy danych

insert into users(username, password, name, surname)
values('Andrju', 'password123', 'Andrzej', 'Deczko');
CREATE USER Andrju PASSWORD 'password123';
CREATE VIEW view_Andrju_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Andrju_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Andrju_list_messages TO Andrju;
GRANT SELECT ON View_Andrju_read_users TO Andrju;

insert into users(username, password, name, surname)
values('Mateo', 'Grucha142', 'Mateusz', 'Pikora');
CREATE USER Mateo PASSWORD 'Grucha142';
CREATE VIEW view_Mateo_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Mateo_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Mateo_list_messages TO Mateo;
GRANT SELECT ON View_Mateo_read_users TO Mateo;

insert into users(username, password, name, surname)
values('Filipo', '232gamaciko', 'Filip', 'Morczynski');
CREATE USER Filipo PASSWORD '232gamaciko';
CREATE VIEW view_Filipo_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Filipo_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Filipo_list_messages TO Filipo;
GRANT SELECT ON View_Filipo_read_users TO Filipo;

insert into users(username, password, name, surname)
values('Greg', 'maslo232', 'Grzegorz', 'Duszynski');
CREATE USER Greg PASSWORD 'maslo232';
CREATE VIEW view_Greg_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Greg_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Greg_list_messages TO Greg;
GRANT SELECT ON View_Greg_read_users TO Greg;

insert into users(username, password, name, surname)
values('Orion', 'husaria192', 'Olaf', 'DiriDiri');
CREATE USER Orion PASSWORD 'husaria192';
CREATE VIEW view_Orion_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Orion_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Orion_list_messages TO Orion;
GRANT SELECT ON View_Orion_read_users TO Orion;

insert into users(username, password, name, surname)
values('Kapa', 'xxxBbBxxx0', 'Kacper', 'Bednarek');
CREATE USER Kapa PASSWORD 'xxxBbBxxx0';
CREATE VIEW view_Kapa_list_messages AS
SELECT * FROM messages
WHERE sender_id = 1 OR receiver_id = 1;
CREATE VIEW view_Kapa_read_users AS
SELECT user_id, username from users;
GRANT SELECT ON View_Kapa_list_messages TO Kapa;
GRANT SELECT ON View_Kapa_read_users TO Kapa;

-- przykładowe relacje pomiędzy użytkownikami

insert into friends(user_id, friend_id, status)
values(1, 2, 'accepted');
insert into friends(user_id, friend_id, status)
values(1, 3, 'blocked');
insert into friends(user_id, friend_id, status)
values(1, 4, 'requested');

-- przykładowe wiadomości

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
-- DROP TABLE users CASCADE;
-- DROP TABLE friends CASCADE;
-- DROP TABLE messages CASCADE;
-- DROP TRIGGER at_insert_message_check_is_friends on messages;
-- DROP FUNCTION is_friend();
-- DROP TRIGGER at_insert_message_check_null on messages;
-- DROP FUNCTION check_null();



------------------------------------------

-- Moje stare podejście do tematu - zapomniałem że NEW w funkcji triggera jest typem rekordowym. Może można to wykorzystać do czegoś innego, ale nie sprawdzałem czy działa

-- CREATE FUNCTION username_to_id(v_username varchar) RETURNS INTEGER PLPGSQL as $$
-- DECLARE
-- v_id integer;
-- BEGIN

-- SELECT user_id 
-- INTO v_id
-- FROM users
-- WHERE username = v_username;

-- IF NOT FOUND THEN
-- 	RAISE NOTICE 'Nie znaleziono id użytkownika o nazwie: (%)', v_username;
-- END IF;

-- return v_id;
-- END $$;

-- CREATE FUNCTION is_friend(v_sender_id INTEGER, v_receiver VARCHAR) LANGUAGE PLPGSQL AS $$
-- DECLARE
-- v_receiver_id integer;
-- v_status varchar;
-- BEGIN

-- v_receiver_id = CALL username_to_id(v_receiver);

-- SELECT status
-- INTO v_status
-- FROM friends
-- WHERE user_id = v_sender_id AND friend_id = v_receiver_id;

-- IF(v_status IS NULL)      -- albo == '', ale musze sprawdzić
-- EXCEPTION 'Nie jesteś znajomym użytkownika (%)', receiver;
-- ELSE IF(v_status == 'requested')
-- EXCEPTION "Użytkownik (%) nie dodał cię jeszcze do znajomych", receiver;
-- ELSE IF(v_status == 'blocked')
-- EXCEPTION "Użytkownik (%) zablokował cię", receiver;
-- END IF;
-- RAICE NOTICE 'jesteście znajomymi';
-- END $$;

------------------------------------------

-- GRANT CONNECT ON DATABASE my_database TO my_user; teoretycznie to powinno pomóc, ale nic nie daje...
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


---------------------------------------
-- CREATE TABLE groups(
-- 	id SERIAL,
-- 	group_name TEXT,
-- 	group_users INTEGER);
