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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.user_id != 0)
                MessageBox.Show("Najpierw wyloguj się");
            if (userNameText.Text == "")
                MessageBox.Show("Musisz wprowadzić nazwę użytkownika");
            if (passwordText.Text == "")
                MessageBox.Show("Musisz wprowadzić hasło");
            else if (passwordText.Text.Length < 5)
                MessageBox.Show("Wprowadzone hasło jest za krótkie");
            else if (DBconnection.LogIn(userNameText.Text, passwordText.Text))
            {
                MessageBox.Show("Poprawnie Zalogowano");
                Application.OpenForms.OfType<MainForm>().FirstOrDefault().statusText.Text = $"Połączono z {DBconnection.database}";
                Application.OpenForms.OfType<MainForm>().FirstOrDefault().currentUserText.Text = userNameText.Text;
                MessageBox.Show("Możesz teraz przejść do pisania wiadomości i odczytywania ich");
            }
            else
                MessageBox.Show("Nie zalogowano");
        }
    }
}
