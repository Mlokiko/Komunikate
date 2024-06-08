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
                // To można by jakoś zmienić, żeby tą biblioteke dało się używać z innym frameworkiem graficznym (WPF, MAUI, cos webowego) bez zmian w kodzie
                // (chyba) Najlepiej by było zwracać wartości liczbowe typu 1 - ok, 2 - error, 3 - inny error
                DBconnection.user_name_lower = "";
                MessageBox.Show(ex.Message);
            }
            return false;
        }

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

        // summary, trzeba napisac
        // zwraca 1 gdy prawidłowo wykonano inserta
        // zwraca 0 gdy nie ma w bazie danego użytkownika
        // zwraca 2 gdy zawartość wiadomości jest pusta
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
                {
                    return 0;
                }
                else if (message_content == ""){
                    return 2;
                }
                //MessageBox.Show($"{receiver_id}");
                //MessageBox.Show($"{DBconnection.user_id}");
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
        public static bool Register(string userName, string password, string name, string surname)
        {
            int userID = 0;
            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username=usercreator;Password=userCreator");
            con.Open();
            var create_user = new NpgsqlCommand($"INSERT INTO USERS(username, password, name, surname) VALUES('{userName}', '{password}', '{name}', '{surname}')", con);
            var check_id = new NpgsqlCommand($"SELECT user_id FROM users WHERE username = '{userName}'", con);
            var create_database_user = new NpgsqlCommand($"CREATE USER {userName} PASSWORD '{password}'", con);
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
        // public static void ListConversationMessages() { }

    }
}
