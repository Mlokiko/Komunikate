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
            ipText = new TextBox();
            connectButton = new Button();
            databaseText = new TextBox();
            ipLabel = new Label();
            databaseLabel = new Label();
            portLabel = new Label();
            portText = new TextBox();
            deleteAccountButton = new Button();
            deleteAccountLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // ipText
            // 
            ipText.Location = new Point(354, 142);
            ipText.Name = "ipText";
            ipText.PlaceholderText = "127.0.0.1";
            ipText.Size = new Size(100, 23);
            ipText.TabIndex = 17;
            ipText.Text = "127.0.0.1";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(341, 229);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(113, 23);
            connectButton.TabIndex = 15;
            connectButton.Text = "Check connection";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // databaseText
            // 
            databaseText.Location = new Point(354, 200);
            databaseText.Name = "databaseText";
            databaseText.PlaceholderText = "postgres";
            databaseText.Size = new Size(100, 23);
            databaseText.TabIndex = 21;
            databaseText.Text = "postgres";
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new Point(291, 145);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(60, 15);
            ipLabel.TabIndex = 16;
            ipLabel.Text = "IP serwera";
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new Point(294, 203);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new Size(54, 15);
            databaseLabel.TabIndex = 20;
            databaseLabel.Text = "database";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(319, 174);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(29, 15);
            portLabel.TabIndex = 18;
            portLabel.Text = "Port";
            // 
            // portText
            // 
            portText.Location = new Point(354, 171);
            portText.Name = "portText";
            portText.PlaceholderText = "5432";
            portText.Size = new Size(100, 23);
            portText.TabIndex = 19;
            portText.Text = "5432";
            // 
            // deleteAccountButton
            // 
            deleteAccountButton.Location = new Point(341, 300);
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
            deleteAccountLabel.Location = new Point(247, 326);
            deleteAccountLabel.Name = "deleteAccountLabel";
            deleteAccountLabel.Size = new Size(294, 15);
            deleteAccountLabel.TabIndex = 23;
            deleteAccountLabel.Text = "Usunięcie konta nie spowoduje usunięcia wiadomości ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 255);
            label1.Name = "label1";
            label1.Size = new Size(399, 15);
            label1.TabIndex = 24;
            label1.Text = "Naciśnięcie przycisku spowoduje próbę połączenia z wskazanym serwerem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 270);
            label2.Name = "label2";
            label2.Size = new Size(590, 15);
            label2.TabIndex = 25;
            label2.Text = "Gdy połączenie powiedzie się, w trakcie logowania użytkownik będzie logować się do wskazanego tutaj serwera";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(deleteAccountLabel);
            Controls.Add(deleteAccountButton);
            Controls.Add(ipText);
            Controls.Add(connectButton);
            Controls.Add(databaseText);
            Controls.Add(ipLabel);
            Controls.Add(databaseLabel);
            Controls.Add(portLabel);
            Controls.Add(portText);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox ipText;
        private Button connectButton;
        private TextBox databaseText;
        private Label ipLabel;
        private Label databaseLabel;
        private Label portLabel;
        private TextBox portText;
        private Button deleteAccountButton;
        private Label deleteAccountLabel;
        private Label label1;
        private Label label2;
    }
}