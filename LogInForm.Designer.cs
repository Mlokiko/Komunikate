namespace WinFormsTest3
{
    partial class LogInForm
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
            userNameLabel = new Label();
            passwordLabel = new Label();
            userNameText = new TextBox();
            passwordText = new TextBox();
            logInButton = new Button();
            SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(382, 233);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(112, 15);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "Nazwa Użytkownika";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(456, 262);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(37, 15);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Hasło";
            // 
            // userNameText
            // 
            userNameText.Location = new Point(500, 230);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(100, 23);
            userNameText.TabIndex = 2;
            userNameText.Text = "Mateo";
            // 
            // passwordText
            // 
            passwordText.Location = new Point(500, 259);
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.Size = new Size(100, 23);
            passwordText.TabIndex = 3;
            passwordText.Text = "Grucha142";
            // 
            // logInButton
            // 
            logInButton.Location = new Point(525, 288);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(75, 23);
            logInButton.TabIndex = 4;
            logInButton.Text = "Zaloguj się";
            logInButton.UseVisualStyleBackColor = true;
            logInButton.Click += logInButton_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(userNameText);
            Controls.Add(logInButton);
            Controls.Add(userNameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(passwordText);
            Name = "LogInForm";
            Text = "Log In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userNameLabel;
        private Label passwordLabel;
        private TextBox userNameText;
        private TextBox passwordText;
        private Button logInButton;
    }
}