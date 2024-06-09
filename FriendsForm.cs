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
    public partial class FriendsForm : Form
    {
        public FriendsForm()
        {
            InitializeComponent();
        }

        private void checkFriendStatusButton_Click(object sender, EventArgs e)
        {
            switch (DBconnection.CheckFriendStatus(userNameText.Text))
            {
                case 0:
                    MessageBox.Show($"Nie jesteś znajomym z {userNameText.Text}");
                    break;
                case 1:
                    MessageBox.Show($"Jesteś w fazie \"reguest\" z {userNameText.Text}");
                    break;
                case 2:
                    MessageBox.Show($"Albo ty albo użytkownik {userNameText.Text} zablokował znajomość");
                    break;
                case 3:
                    MessageBox.Show($"Jesteś znajomym z {userNameText.Text}");
                    break;
                case 4:
                    MessageBox.Show($"Jakiś błąd?");
                    break;
            }
        }
    }
}
