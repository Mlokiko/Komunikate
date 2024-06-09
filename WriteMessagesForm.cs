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
            switch (DBconnection.WriteMessage(userNameText.Text, messageContentText.Text))
            {
                case 0:
                    MessageBox.Show("Nie ma użytkownika o takiej nazwie");
                    break;
                case 1:
                    MessageBox.Show("Poprawnie wysłano wiadomość");
                    break;
                case 2:
                    MessageBox.Show("Zawartość wiadomości nie może być pusta");
                    break;
                case 3:
                    MessageBox.Show("Inny błąd?");
                    break;
            }
        }
    }
}
