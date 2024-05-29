namespace WinFormsTest3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            panelTop = new Panel();
            panelLogo = new Panel();
            LogoLabel = new Label();
            panelContent = new Panel();
            ss2 = new Label();
            ss1 = new Label();
            panelLeft = new Panel();
            infoButton = new Button();
            settingsButton = new Button();
            registerButton = new Button();
            logoutButton = new Button();
            currentUserText = new Label();
            currentUserLabel = new Label();
            statusText = new Label();
            statusLabel = new Label();
            logInButton = new Button();
            writeMessagesButton = new Button();
            readMessagesButton = new Button();
            panelTop.SuspendLayout();
            panelLogo.SuspendLayout();
            panelContent.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(632, 31);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(75, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Witaj!";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(44, 62, 80);
            panelTop.Controls.Add(panelLogo);
            panelTop.Controls.Add(labelTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1197, 97);
            panelTop.TabIndex = 6;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(44, 62, 80);
            panelLogo.Controls.Add(LogoLabel);
            panelLogo.Dock = DockStyle.Left;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 97);
            panelLogo.TabIndex = 0;
            // 
            // LogoLabel
            // 
            LogoLabel.AutoSize = true;
            LogoLabel.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LogoLabel.ForeColor = SystemColors.Control;
            LogoLabel.Location = new Point(12, 31);
            LogoLabel.Name = "LogoLabel";
            LogoLabel.Size = new Size(154, 33);
            LogoLabel.TabIndex = 0;
            LogoLabel.Text = "Komunikate";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(ss2);
            panelContent.Controls.Add(ss1);
            panelContent.Location = new Point(199, 98);
            panelContent.Margin = new Padding(0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(998, 580);
            panelContent.TabIndex = 7;
            // 
            // ss2
            // 
            ss2.AutoSize = true;
            ss2.Location = new Point(423, 295);
            ss2.Name = "ss2";
            ss2.Size = new Size(145, 15);
            ss2.TabIndex = 1;
            ss2.Text = "Aby rozpocząć, zaloguj się";
            // 
            // ss1
            // 
            ss1.AutoSize = true;
            ss1.Location = new Point(380, 271);
            ss1.Name = "ss1";
            ss1.Size = new Size(239, 15);
            ss1.TabIndex = 0;
            ss1.Text = "Witaj w prostym komunikatorze tekstowym!";
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(44, 62, 80);
            panelLeft.Controls.Add(infoButton);
            panelLeft.Controls.Add(settingsButton);
            panelLeft.Controls.Add(registerButton);
            panelLeft.Controls.Add(logoutButton);
            panelLeft.Controls.Add(currentUserText);
            panelLeft.Controls.Add(currentUserLabel);
            panelLeft.Controls.Add(statusText);
            panelLeft.Controls.Add(statusLabel);
            panelLeft.Controls.Add(logInButton);
            panelLeft.Controls.Add(writeMessagesButton);
            panelLeft.Controls.Add(readMessagesButton);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            panelLeft.Location = new Point(0, 97);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 581);
            panelLeft.TabIndex = 8;
            // 
            // infoButton
            // 
            infoButton.BackColor = Color.FromArgb(52, 73, 94);
            infoButton.BackgroundImageLayout = ImageLayout.None;
            infoButton.Dock = DockStyle.Top;
            infoButton.FlatAppearance.BorderSize = 0;
            infoButton.FlatStyle = FlatStyle.Flat;
            infoButton.ForeColor = Color.White;
            infoButton.ImageAlign = ContentAlignment.TopLeft;
            infoButton.Location = new Point(0, 300);
            infoButton.Margin = new Padding(0);
            infoButton.Name = "infoButton";
            infoButton.Size = new Size(200, 50);
            infoButton.TabIndex = 16;
            infoButton.Text = "Info";
            infoButton.UseVisualStyleBackColor = false;
            infoButton.Click += infoButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(52, 73, 94);
            settingsButton.BackgroundImageLayout = ImageLayout.None;
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = Color.White;
            settingsButton.ImageAlign = ContentAlignment.TopLeft;
            settingsButton.Location = new Point(0, 250);
            settingsButton.Margin = new Padding(0);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(200, 50);
            settingsButton.TabIndex = 15;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.FromArgb(52, 73, 94);
            registerButton.BackgroundImageLayout = ImageLayout.None;
            registerButton.Dock = DockStyle.Top;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.ForeColor = Color.White;
            registerButton.ImageAlign = ContentAlignment.TopLeft;
            registerButton.Location = new Point(0, 200);
            registerButton.Margin = new Padding(0);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(200, 50);
            registerButton.TabIndex = 13;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.FromArgb(52, 73, 94);
            logoutButton.BackgroundImageLayout = ImageLayout.Zoom;
            logoutButton.Dock = DockStyle.Top;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.ForeColor = Color.White;
            logoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            logoutButton.Location = new Point(0, 150);
            logoutButton.Margin = new Padding(0);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(200, 50);
            logoutButton.TabIndex = 10;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // currentUserText
            // 
            currentUserText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentUserText.AutoSize = true;
            currentUserText.ForeColor = Color.White;
            currentUserText.Location = new Point(12, 560);
            currentUserText.Name = "currentUserText";
            currentUserText.Size = new Size(109, 21);
            currentUserText.TabIndex = 7;
            currentUserText.Text = "Nie połączono";
            // 
            // currentUserLabel
            // 
            currentUserLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentUserLabel.AutoSize = true;
            currentUserLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            currentUserLabel.ForeColor = Color.White;
            currentUserLabel.Location = new Point(0, 539);
            currentUserLabel.Name = "currentUserLabel";
            currentUserLabel.Size = new Size(98, 21);
            currentUserLabel.TabIndex = 6;
            currentUserLabel.Text = "Użytkownik:";
            // 
            // statusText
            // 
            statusText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusText.AutoSize = true;
            statusText.ForeColor = Color.White;
            statusText.Location = new Point(12, 518);
            statusText.Name = "statusText";
            statusText.Size = new Size(109, 21);
            statusText.TabIndex = 5;
            statusText.Text = "Nie połączono";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            statusLabel.ForeColor = Color.White;
            statusLabel.Location = new Point(3, 497);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(59, 21);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Status:";
            // 
            // logInButton
            // 
            logInButton.BackColor = Color.FromArgb(52, 73, 94);
            logInButton.BackgroundImageLayout = ImageLayout.None;
            logInButton.Dock = DockStyle.Top;
            logInButton.FlatAppearance.BorderSize = 0;
            logInButton.FlatStyle = FlatStyle.Flat;
            logInButton.ForeColor = Color.White;
            logInButton.ImageAlign = ContentAlignment.MiddleLeft;
            logInButton.Location = new Point(0, 100);
            logInButton.Margin = new Padding(0);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(200, 50);
            logInButton.TabIndex = 3;
            logInButton.Text = "Log in";
            logInButton.UseVisualStyleBackColor = false;
            logInButton.Click += logInButton_Click;
            // 
            // writeMessagesButton
            // 
            writeMessagesButton.BackColor = Color.FromArgb(52, 73, 94);
            writeMessagesButton.BackgroundImageLayout = ImageLayout.None;
            writeMessagesButton.Dock = DockStyle.Top;
            writeMessagesButton.FlatAppearance.BorderSize = 0;
            writeMessagesButton.FlatStyle = FlatStyle.Flat;
            writeMessagesButton.ForeColor = Color.White;
            writeMessagesButton.ImageAlign = ContentAlignment.MiddleLeft;
            writeMessagesButton.Location = new Point(0, 50);
            writeMessagesButton.Margin = new Padding(0);
            writeMessagesButton.Name = "writeMessagesButton";
            writeMessagesButton.Size = new Size(200, 50);
            writeMessagesButton.TabIndex = 1;
            writeMessagesButton.Text = "Write Message";
            writeMessagesButton.UseVisualStyleBackColor = false;
            writeMessagesButton.Click += writeMessagesButton_Click;
            // 
            // readMessagesButton
            // 
            readMessagesButton.BackColor = Color.FromArgb(52, 73, 94);
            readMessagesButton.BackgroundImageLayout = ImageLayout.None;
            readMessagesButton.Dock = DockStyle.Top;
            readMessagesButton.FlatAppearance.BorderSize = 0;
            readMessagesButton.FlatStyle = FlatStyle.Flat;
            readMessagesButton.ForeColor = Color.White;
            readMessagesButton.ImageAlign = ContentAlignment.MiddleLeft;
            readMessagesButton.Location = new Point(0, 0);
            readMessagesButton.Margin = new Padding(0);
            readMessagesButton.Name = "readMessagesButton";
            readMessagesButton.Size = new Size(200, 50);
            readMessagesButton.TabIndex = 0;
            readMessagesButton.Text = "Read Messages";
            readMessagesButton.UseVisualStyleBackColor = false;
            readMessagesButton.Click += readMessagesButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1197, 678);
            Controls.Add(panelLeft);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            MinimumSize = new Size(900, 550);
            Name = "MainForm";
            Text = "Komunikate";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTitle;
        private Label currentUserLabel;
        private Panel panel1;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelLeft;
        private Button logInButton;
        private Button writeMessagesButton;
        private Button readMessagesButton;
        private Panel panelLogo;
        private Label LogoLabel;
        private Label statusLabel;
        private Label ss2;
        private Label ss1;
        public Label statusText;
        public Label currentUserText;
        private Button logoutButton;
        private Button infoButton;
        private Button settingsButton;
        private Button registerButton;
    }
}
