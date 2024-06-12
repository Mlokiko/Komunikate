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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.CheckConnectionToDB(ipText.Text, portText.Text, databaseText.Text))
            {
                Application.OpenForms.OfType<MainForm>().FirstOrDefault().statusText.Text = $"Połączono z {databaseText.Text}";
            }
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.user_id == 0)
            {
                MessageBox.Show("Musisz być zalogowany aby usunąć konto");
            }
            else if (DBconnection.DeleteAccount())
            {
                    MessageBox.Show("Pomyślnie usunięto konto");
            }
        }
    }
}
