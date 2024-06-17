using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsTest3
{
    public partial class ReadMessagesForm : Form
    {
        public ReadMessagesForm()
        {
            InitializeComponent();

            var con = new NpgsqlConnection($"Server={DBconnection.server};Port={DBconnection.port};Database={DBconnection.database};Username={DBconnection.user_name_lower};Password={DBconnection.user_password}");
            var cmd = new NpgsqlCommand($"SELECT DISTINCT username FROM View_{DBconnection.user_name}_read_users NATURAL JOIN View_{DBconnection.user_name}_read_friends where status = 'accepted';", con);
            con.Open();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            var lista = new List<string>();
            //int i = 0;
            while (reader.Read())
            {
                lista.Add(reader.GetString(0));
            }
            FriendsBox.DataSource = lista;
            con.Close();

            //usersDataGridView.DataSource = DBconnection.GetData($"SELECT DISTINCT username FROM View_{DBconnection.user_name}_read_users NATURAL JOIN View_{DBconnection.user_name}_read_friends where status='accepted';");
            //FriendsBox.DataSource = DBconnection.GetData($"SELECT DISTINCT username FROM View_{DBconnection.user_name}_read_users NATURAL JOIN View_{DBconnection.user_name}_read_friends where status='accepted';");
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void messagesdDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //usersDataGridView.DataSource = DBconnection.GetData($"SELECT username FROM View_{DBconnection.user_name}_read_users NATURAL JOIN View_{DBconnection.user_name}_read_friends where status='accepted';");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //messagesdDataGridView.DataSource = DBconnection.GetData($"SELECT message_text_content, message_date, sender_id, receiver_id FROM View_{DBconnection.user_name}_list_messages");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string friendName = friendNameTextBox.Text;
            var friendId = DBconnection.NameToId(friendName);

            if (friendName.Length == 0)
                MessageBox.Show("Proszę wprowadzić nazwę znajomego");
            else if (friendId == 0)
                MessageBox.Show("Taki użytkownik nie istnieje lub nie masz takiego znajomego");
            else
                messagesdDataGridView.DataSource = DBconnection.GetData($"SELECT message_date AS \"Data wysłania\", message_text_content AS \"Wiadomość\" FROM View_{DBconnection.user_name}_list_messages vlm JOIN View_{DBconnection.user_name}_read_users vu ON (vlm.sender_id=vu.user_id OR vlm.receiver_id=vu.user_id) WHERE vu.username='{friendName}' ORDER BY message_date ASC;");

            //messagesdDataGridView.DataSource = DBconnection.GetData($"SELECT message_text_content, message_date, sender_id, receiver_id FROM View_{DBconnection.user_name_lower}_list_messages WHERE sender_id=(SELECT user_id FROM View_{DBconnection.user_name_lower}_read_users WHERE username={friendName}) OR receiver_id=(SELECT user_id FROM View_{DBconnection.user_name_lower}_read_users WHERE username={friendName})");
        }
    }
}
