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
                    MessageBox.Show($"Wysłałeś zaproszenie do znajomych do {userNameText.Text}");
                    break;
                case 2:
                    MessageBox.Show($"Użytkownik {userNameText.Text} wysłał zaproszenie do znajomych");
                    break;
                case 3:
                    MessageBox.Show($"Zablokowałeś użytkownika {userNameText.Text}");
                    break;
                case 4:
                    MessageBox.Show($"Użytkownik {userNameText.Text} zablokował cię");
                    break;
                case 5:
                    MessageBox.Show($"Jesteś znajomym użytkownika {userNameText.Text}");
                    break;
                case 6:
                    MessageBox.Show("Inny błąd?");
                    break;
            }
        }

        private void addFriendButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.AddFriend(userNameText.Text))
                MessageBox.Show($"Dodano {userNameText.Text} do znajomych");
            else
                MessageBox.Show($"Nie dodano {userNameText.Text} do znajomych");
        }
        private void blockFriendButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.BlockFriend(userNameText.Text))
                MessageBox.Show($"Zablokowano użytkownika {userNameText.Text}");
            else
                MessageBox.Show($"Nie zablokowano użytkownia {userNameText.Text}");
        }
        private void unBlockFriendButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.UnBlockFriend(userNameText.Text))
                MessageBox.Show($"Odblokowano użytkownika {userNameText.Text}");
            else
                MessageBox.Show($"Nie odblokowano użytkownika {userNameText.Text}");
        }
        private void deleteFriendButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.DeleteFriend(userNameText.Text))
                MessageBox.Show($"Usunięto ze znajomych użytkownika {userNameText.Text}");
            else
                MessageBox.Show($"Nie usunięto ze znajomych użytkownika {userNameText.Text}");
        }
    }
}
