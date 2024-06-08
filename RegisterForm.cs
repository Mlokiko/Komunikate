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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(DBconnection.Register(userNameText.Text, passwordText.Text, nameText.Text, surnameText.Text))
            {
                MessageBox.Show("Pomyślnie utworzono użytkownika");
            }
            else
            {
                MessageBox.Show("Nie utworzono użytkownika");
            }
        }
    }
}
