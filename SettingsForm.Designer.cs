namespace WinFormsTest3
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label2 = new Label();
            checkedListBox2 = new CheckedListBox();
            label3 = new Label();
            ipText = new TextBox();
            connectButton = new Button();
            databaseText = new TextBox();
            ipLabel = new Label();
            databaseLabel = new Label();
            portLabel = new Label();
            portText = new TextBox();
            deleteAccountButton = new Button();
            deleteAccountLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(548, 21);
            label1.Name = "label1";
            label1.Size = new Size(189, 15);
            label1.TabIndex = 0;
            label1.Text = "Kiedyś tutaj będą opcje do wyboru";
            // 
            // button1
            // 
            button1.Location = new Point(593, 262);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(548, 79);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(204, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Włącz powiadomienia systemowe";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(548, 104);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(236, 19);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Minimalizuj do zasobnika systemowego";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(624, 45);
            label2.Name = "label2";
            label2.Size = new Size(128, 15);
            label2.TabIndex = 6;
            label2.Text = "Aktualnie nic nie dziala";
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "nigdy", "5 minut", "10 minut", "20 minut", "30 minut", "1 godzina" });
            checkedListBox2.Location = new Point(548, 144);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(120, 112);
            checkedListBox2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(548, 126);
            label3.Name = "label3";
            label3.Size = new Size(152, 15);
            label3.TabIndex = 8;
            label3.Text = "Automatycznie wyloguj po:";
            // 
            // ipText
            // 
            ipText.Location = new Point(73, 18);
            ipText.Name = "ipText";
            ipText.PlaceholderText = "127.0.0.1";
            ipText.Size = new Size(100, 23);
            ipText.TabIndex = 17;
            ipText.Text = "127.0.0.1";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(60, 105);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(113, 23);
            connectButton.TabIndex = 15;
            connectButton.Text = "Check connection";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // databaseText
            // 
            databaseText.Location = new Point(73, 76);
            databaseText.Name = "databaseText";
            databaseText.PlaceholderText = "postgres";
            databaseText.Size = new Size(100, 23);
            databaseText.TabIndex = 21;
            databaseText.Text = "postgres";
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new Point(10, 21);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(60, 15);
            ipLabel.TabIndex = 16;
            ipLabel.Text = "IP serwera";
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new Point(13, 79);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new Size(54, 15);
            databaseLabel.TabIndex = 20;
            databaseLabel.Text = "database";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(38, 50);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(29, 15);
            portLabel.TabIndex = 18;
            portLabel.Text = "Port";
            // 
            // portText
            // 
            portText.Location = new Point(73, 47);
            portText.Name = "portText";
            portText.PlaceholderText = "5432";
            portText.Size = new Size(100, 23);
            portText.TabIndex = 19;
            portText.Text = "5432";
            // 
            // deleteAccountButton
            // 
            deleteAccountButton.Location = new Point(115, 215);
            deleteAccountButton.Name = "deleteAccountButton";
            deleteAccountButton.Size = new Size(113, 23);
            deleteAccountButton.TabIndex = 22;
            deleteAccountButton.Text = "Usuń konto";
            deleteAccountButton.UseVisualStyleBackColor = true;
            deleteAccountButton.Click += deleteAccountButton_Click;
            // 
            // deleteAccountLabel
            // 
            deleteAccountLabel.AutoSize = true;
            deleteAccountLabel.Location = new Point(13, 241);
            deleteAccountLabel.Name = "deleteAccountLabel";
            deleteAccountLabel.Size = new Size(331, 15);
            deleteAccountLabel.TabIndex = 23;
            deleteAccountLabel.Text = "Usunięcie konta spowoduje usunięcie wszystkich wiadomości";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteAccountLabel);
            Controls.Add(deleteAccountButton);
            Controls.Add(ipText);
            Controls.Add(connectButton);
            Controls.Add(databaseText);
            Controls.Add(ipLabel);
            Controls.Add(databaseLabel);
            Controls.Add(portLabel);
            Controls.Add(portText);
            Controls.Add(label3);
            Controls.Add(checkedListBox2);
            Controls.Add(label2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label2;
        private CheckedListBox checkedListBox2;
        private Label label3;
        private TextBox ipText;
        private Button connectButton;
        private TextBox databaseText;
        private Label ipLabel;
        private Label databaseLabel;
        private Label portLabel;
        private TextBox portText;
        private Button deleteAccountButton;
        private Label deleteAccountLabel;
    }
}