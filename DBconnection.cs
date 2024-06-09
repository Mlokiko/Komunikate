using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    MessageBox.Show("Success open postgreSQL connection.");
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
            DBconnection.user_name_lower = userName.ToLower();
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={password}");
            try
            {
                con.Open();
                var cmd = new NpgsqlCommand($"SELECT user_id, username FROM View_{userName}_read_users WHERE username = '{userName}'", con);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DBconnection.user_id = reader.GetInt32(0);
                }
                DBconnection.user_name = userName;
                DBconnection.user_password = password;
                return true;
            }
            catch (Exception ex)
            {
                // To można by jakoś zmienić, żeby tą biblioteke dało się używać z innym frameworkiem UI (konsola, WPF, MAUI, cos webowego) bez zmian w kodzie
                // (chyba) Najlepiej by było zwracać wartości liczbowe typu 1 - ok, 2 - error, 3 - inny error i obsługiwać je w kodzie programu, a nie tutaj
                DBconnection.user_name_lower = "";
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
                int receiver_id = 0;
                con.Open();
                var cmd = new NpgsqlCommand($"SELECT user_id, username FROM View_{DBconnection.user_name}_read_users WHERE username = '{username}'", con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    receiver_id = reader.GetInt32(0);
                }
                con.Close();

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
            int userID = 0;
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username=usercreator;Password=userCreator");
            con.Open();
            var create_user = new NpgsqlCommand($"INSERT INTO USERS(username, password, name, surname) VALUES('{userName}', '{password}', '{name}', '{surname}')", con);
            var check_id = new NpgsqlCommand($"SELECT user_id FROM users WHERE username = '{userName}'", con);
            var create_database_user = new NpgsqlCommand($"CREATE USER {userName} PASSWORD '{password}'", con);
            var add_to_group = new NpgsqlCommand($"ALTER GROUP user_group ADD user {userName}", con);
            var create_view_list_messages = new NpgsqlCommand($"CREATE VIEW view_{userName}_list_messages AS SELECT * FROM messages WHERE sender_id = {userID} OR receiver_id = {userID}", con);
            var create_view_read_users = new NpgsqlCommand($"CREATE VIEW view_{userName}_read_users AS SELECT user_id, username from users", con);
            var create_grant_on_list_messages = new NpgsqlCommand($"GRANT SELECT ON view_{userName}_list_messages TO {userName}", con);
            var create_grant_on_read_users = new NpgsqlCommand($"GRANT SELECT ON view_{userName}_read_users TO {userName}", con);
            try
            {
                create_user.ExecuteNonQuery();
                NpgsqlDataReader reader = check_id.ExecuteReader();     
                while (reader.Read())                                       // Ten kawałek kodu można by pewnie wykonać inaczej (lepiej)
                {
                    userID = reader.GetInt32(0);
                }                                                           // Te otwieranie teoretycznie też można by zmienić
                con.Close();
                con.Open();
                create_database_user.ExecuteNonQuery();
                con.Close();
                con.Open();
                add_to_group.ExecuteNonQuery();
                con.Close();
                con.Open();
                create_view_list_messages.ExecuteNonQuery();
                con.Close();
                con.Open();
                create_view_read_users.ExecuteNonQuery();
                con.Close();
                con.Open();
                create_grant_on_list_messages.ExecuteNonQuery();
                con.Close();
                con.Open();
                create_grant_on_read_users.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
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
        /// Funkcja zwraca 0 gdy nie jest sie znajomym, 1 gdy jest sie w fazie request, 2 gdy jest sie zablokowanym, 3 gdy jest sie znajomym, 4 gdy jest błąd?
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

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return 4;
        }
        public static bool AddFriend(string userName)
        {
            int friend_id = 0;
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            try
            {
                var cmd = new NpgsqlCommand($"SELECT user_id, username FROM View_{userName}_read_users WHERE username = '{userName}'", con);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    friend_id = reader.GetInt32(0);
                }

                con.Open();
                var cmd2 = new NpgsqlCommand($"DELETE FROM friends WHERE user_id = {DBconnection.user_id} AND friend_id = {friend_id}", con);
                cmd2.ExecuteNonQuery();
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

            return true;
        }
        public static bool DeleteFriend(string userName)
        {
            return true;
        }
    }
}
