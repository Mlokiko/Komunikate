namespace WinFormsTest3
{
    public partial class MainForm : Form
    {

        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
        }
        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(childForm);
            this.panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }
        private void readMessagesButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.user_name == "")
            {
                MessageBox.Show("Zaloguj si� najpierw");
            }
            else
            {
                OpenChildForm(new ReadMessagesForm());
            }
        }

        private void writeMessagesButton_Click(object sender, EventArgs e)
        {
            if (DBconnection.user_name == "")
            {
                MessageBox.Show("Zaloguj si� najpierw");
            }
            else
            {
                OpenChildForm(new WriteMessagesForm());
            }
        }

        //private void logoutButton_Click(object sender, EventArgs e)
        //{

        //}


        private void logoutButton_Click(object sender, EventArgs e)
        {
            // wst�pnie powinno dzia�a�
            if (DBconnection.user_name == "")
            {
                MessageBox.Show("Nie jeste� zalogowany");
            }
            else
            {
                DBconnection.user_name = "";
                currentUserText.Text = "Nie po��czono";
                statusText.Text = "Nie po��czono";
                MessageBox.Show("Wylogowano");
                //OpenChildForm(new ChangeServerForm());
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm());
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InfoForm());
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LogInForm());
        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
