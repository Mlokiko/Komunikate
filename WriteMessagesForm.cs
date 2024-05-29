using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest3
{
    public partial class WriteMessagesForm : Form
    {
        public WriteMessagesForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(DBconnection.WriteMessage(userNameText.Text, messageContentText.Text) == 0)
            {
                MessageBox.Show("Nie ma użytkownika o takiej nazwie");
            }
            else if (DBconnection.WriteMessage(userNameText.Text, messageContentText.Text) == 1)
            {
                MessageBox.Show("Poprawnie wysłano wiadomość");
            }
            else if (DBconnection.WriteMessage(userNameText.Text, messageContentText.Text) == 2)
            {
                MessageBox.Show("Zawartość wiadomości nie może być pusta");
            }
            else if (DBconnection.WriteMessage(userNameText.Text, messageContentText.Text) == 3)
            {
                MessageBox.Show("Inny błąd?");
            }
        }
    }
}
