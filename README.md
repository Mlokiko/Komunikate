Prosty Komunikator tekstowy

Do poprawnego działania wymagane jest:
- posiadanie zainstalowanego postgresa, standardowo aplikacja korzysta z standardowej bazy danych postgres na porcie 5432
- zaimportowanie tabel oraz wymaganych użytkowników (testconnection oraz usercreator)
- zaimportowanie triggerów oraz funkcji składowanej z pliku projekt.sql (znajduje się w folderze resources)

Plik projekt.sql zawiera wymagane tabele, relacje pomiędzy nimi, funkcje składowe oraz testową zawartość bazy danych (przykładowych użytkowników, ich statusy znajomości oraz wiadomości)
