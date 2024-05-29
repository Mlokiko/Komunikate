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

namespace WinFormsTest3
{
    public partial class ReadMessagesForm : Form
    {
        public ReadMessagesForm()
        {
            InitializeComponent();
            usersDataGridView.DataSource = DBconnection.GetData($"SELECT username from View_{DBconnection.user_name}_read_users");
            messagesdDataGridView.DataSource = DBconnection.GetData($"SELECT message_text_content, message_date, sender_id, receiver_id FROM View_{DBconnection.user_name}_list_messages");
        }
    }
}
