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
            DBconnection.CheckFriendStatus(userNameText.Text);
        }
    }
}
