using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsTest3
{
    internal class DBconnection
    {
        public static int user_id;
        public static string user_name = "";
        public static string user_name_lower = "";
        public static string user_password = ""; // Nwm czy to dobry pomysł tutaj to przechowywać... gdyby chociaż było zahaszowane
        public static string server = "127.0.0.1";
        public static string port = "5432";
        public static string database = "postgres";

        /// <summary>
        /// Funkcja sprawdza połączenie z bazą wskazaną przez parametry. Używa specjalnego użytkownika do tego. Po poprawnym wykonaniu zapisuje informacje o bazie do zmiennych statycznych tej biblioteki.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool CheckConnectionToDB(string server, string port, string database)
        {
            try
            {
                var con = new NpgsqlConnection($"Server={server};Port={port};Database={database};Username=testconnection;Password=testConnection");
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                    MessageBox.Show("Połączono z serwerem.");
                con.Close();
                DBconnection.server = server;
                DBconnection.port = port;
                DBconnection.database = database;
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Funkcja logująca usera. Loguje się do DB podanymi parametrami i odczytuje id użytkownika, zapisuje potem podane informacje i id w zmiennych statycznych tej biblioteki.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool LogIn(string userName, string password)
        {
            DBconnection.user_name = userName;
            DBconnection.user_name_lower = userName.ToLower();
            DBconnection.user_password = password;
            try
            {
                DBconnection.user_id = NameToId(userName);
                DBconnection.user_name = userName;
                DBconnection.user_password = password;
                return true;
            }
            catch (Exception ex)
            {
                // To można by jakoś zmienić, żeby tą biblioteke dało się używać z innym frameworkiem UI (konsola, WPF, MAUI, cos webowego) bez zmian w kodzie
                // (chyba) Najlepiej by było zwracać wartości liczbowe typu 1 - ok, 2 - error, 3 - inny error i obsługiwać je w kodzie programu, a nie tutaj
                DBconnection.user_name = "";
                DBconnection.user_name_lower = "";
                DBconnection.user_password = "";
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Funkcja pobierająca dane z DB - do ogarnięcia żeby lepiej działała (tzn, formatowanie)
        /// </summary>
        /// <param name="selectSql"></param>
        /// <returns></returns>
        public static DataTable GetData(string selectSql)
        {
            //https://stackoverflow.com/questions/60670411/add-postgresql-databaseas-data-source-for-winforms-datagridview
            DataSet ds = new DataSet();
            try
            {
                string connstring = String.Format($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectSql, conn);
                da.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// Funkcja wysyła wiadomość do innego użytkownika;
        /// 
        /// Funkcja zwraca:
        /// 1 dla prawidłowo wykonanego inserta
        /// 0 gdy nie ma w bazie danego użytkownika
        /// 2 gdy zawartość wiadomości jest pusta
        /// 3 gdy pojawił się inny błąd
        /// </summary>
        /// <param name="username"></param>
        /// <param name="message_content"></param>
        /// <returns></returns>
        public static int WriteMessage(string username, string message_content)
        {
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                int receiver_id = NameToId(username);

                if (receiver_id == 0)
                    return 0;
                else if (message_content == "")
                    return 2;

                con.Open();
                using (var cmd2 = new NpgsqlCommand($"INSERT INTO messages(message_text_content, sender_id, receiver_id) VALUES('{message_content}', {DBconnection.user_id}, {receiver_id})", con))
                {
                    cmd2.ExecuteNonQuery();
                }
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 3;
            }
        }
        /// <summary>
        /// Funkcja tworzy użytkownika w bazie danych (postgresowego), wpis w bazie na temat użytkownika oraz jego perpektywy i nadaje mu uprawnienia do nich. Zwraca true gdy uda się utworzyć usera false gdy nie.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static bool Register(string userName, string password, string name, string surname)
        {
            using (var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username=usercreator;Password=userCreator"))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int userID = 0;
                        var create_user = new NpgsqlCommand($"INSERT INTO USERS(username, password, name, surname) VALUES('{userName}', '{password}', '{name}', '{surname}')", con);
                        create_user.ExecuteNonQuery();
                        var check_id = new NpgsqlCommand($"SELECT user_id FROM users WHERE username = '{userName}'", con);
                        using (NpgsqlDataReader reader = check_id.ExecuteReader())
                        {
                            while (reader.Read())           // Nie mam pojęcia czemu w while to działa a poza nie... niech ktoś to sprawdzi, zastanawia mnie to
                            {
                                userID = reader.GetInt32(0);
                            }
                        }
                        var create_database_user = new NpgsqlCommand($"CREATE USER {userName} PASSWORD '{password}'", con);
                        create_database_user.ExecuteNonQuery();
                        var add_to_group = new NpgsqlCommand($"ALTER GROUP user_group ADD user {userName}", con);
                        add_to_group.ExecuteNonQuery();
                        var create_view_list_messages = new NpgsqlCommand($"CREATE VIEW view_{userName}_list_messages AS SELECT * FROM messages WHERE sender_id = {userID} OR receiver_id = {userID}", con);
                        create_view_list_messages.ExecuteNonQuery();
                        var create_view_read_users = new NpgsqlCommand($"CREATE VIEW view_{userName}_read_users AS SELECT user_id, username from users", con);
                        create_view_read_users.ExecuteNonQuery();
                        var create_view_read_friends = new NpgsqlCommand($"CREATE VIEW view_{userName}_read_friends AS SELECT * FROM friends WHERE user_id = {userID} OR friend_id = {userID}", con);
                        create_view_read_friends.ExecuteNonQuery();
                        var grant_view_read_friends = new NpgsqlCommand($"GRANT ALL PRIVILEGES ON view_{userName}_read_friends TO {userName}", con);
                        grant_view_read_friends.ExecuteNonQuery();
                        var grant_on_list_messages = new NpgsqlCommand($"GRANT SELECT ON view_{userName}_list_messages TO {userName}", con);
                        grant_on_list_messages.ExecuteNonQuery();
                        var grant_on_read_users = new NpgsqlCommand($"GRANT SELECT ON view_{userName}_read_users TO {userName}", con);
                        grant_on_read_users.ExecuteNonQuery();

                        transaction.Commit();
                        con.Close();

                        DBconnection.user_name = userName;
                        DBconnection.user_name_lower = userName.ToLower();
                        DBconnection.user_password = password;
                        DBconnection.user_id = userID;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        con.Close();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Funkcja usuwa wpis w bazie danych, powiązania z użytkownikiem, oraz jego usera w DB. Zwraca true gdy uda się usunąć, false gdy nie.  
        /// </summary>
        /// <returns></returns>
        public static bool DeleteAccount()
        {
            if(DBconnection.user_id == 0)
                return false;

            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username=userdeleater;Password=userDeleater");
            var cmd = new NpgsqlCommand($"DELETE FROM users WHERE user_id = {DBconnection.user_id}", con);
            var cmd2 = new NpgsqlCommand($"DROP OWNED BY {DBconnection.user_name}", con);
            var cmd3 = new NpgsqlCommand($"DROP USER {DBconnection.user_name}", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
                DBconnection.user_id = 0;
                DBconnection.user_name = "";
                DBconnection.user_name_lower = "";
                DBconnection.user_password = "";
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Funkcja zwraca:
        ///    0 gdy nie jest sie znajomym
        ///    1 aktywny użytkownik wysłał zaproszenie do znajomych
        ///    2 gdy ten drugi użytkownik wysłał zaproszenie
        ///    3 aktywny użytkownik zablokował użytkownika
        ///    4 gdy ten drugi użytkownik zablokował nas
        ///    5 gdy jest się znajomymi
        ///    6 gdy wystąpił inny błąd?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int CheckFriendStatus(string userName)
        {
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                con.Open();
                var cmd = new NpgsqlCommand($"SELECT is_friend2({DBconnection.user_id}, '{userName}')", con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 6;
            }
        }
        public static bool AddFriend(string userName)
        {
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                // TO DO
                int friend_id = NameToId(userName);

                con.Open();
                var cmd = new NpgsqlCommand($"", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message); 
                return false; 
            }
            return true;
        }
        public static bool BlockFriend(string userName)
        {
            int id = NameToId(userName);
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                con.Open();
                var cmd = new NpgsqlCommand($"UPDATE view_{DBconnection.user_name}_read_friends SET status = 'blocked' WHERE user_id = {DBconnection.user_id} AND friend_id = {id}", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public static bool DeleteFriend(string userName)
        {
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                bool friend = false;
                var checkIsFriend = new NpgsqlCommand($"SELECT EXISTS(SELECT 1 FROM view_{DBconnection.user_name_lower}_read_friends WHERE user_id = {DBconnection.user_id} AND friend_id = {NameToId(userName)}) UNION SELECT EXISTS(SELECT 1 FROM view_{DBconnection.user_name_lower}_read_friends WHERE user_id = {NameToId(userName)} AND friend_id = {DBconnection.user_id})", con);

                con.Open();
                using (NpgsqlDataReader reader = checkIsFriend.ExecuteReader())
                {
                    while (reader.Read())           // Nie mam pojęcia czemu w while to działa a poza nie... niech ktoś to sprawdzi, zastanawia mnie to
                    {
                        friend = reader.GetBoolean(0);
                    }
                }
                if (!friend)
                {
                    MessageBox.Show($"Użytkownik {userName} Nie jest twoim znajomym");
                    return false;
                }
                    
                var cmd = new NpgsqlCommand($"DELETE FROM view_{DBconnection.user_name_lower}_read_friends WHERE user_id = {DBconnection.user_id} AND friend_id = {NameToId(userName)}", con);
                var cmd2 = new NpgsqlCommand($"DELETE FROM view_{DBconnection.user_name_lower}_read_friends WHERE user_id = {NameToId(userName)} AND friend_id = {DBconnection.user_id}", con);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Funkcja zwraca ID podanego w argumencie usera. Łączy się z bazą jako aktualny użytkownik aplikacji
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int NameToId(string userName)
        {
            int zmienna = 0;
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            var cmd = new NpgsqlCommand($"SELECT user_id FROM View_{DBconnection.user_name}_read_users WHERE username = '{userName}'", con);

            con.Open();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                zmienna = reader.GetInt32(0);
            }
            con.Close();
            return zmienna;
        }
    }
}
