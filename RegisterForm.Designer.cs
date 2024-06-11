namespace WinFormsTest3
{
    partial class RegisterForm
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
            userNameText = new TextBox();
            passwordText = new TextBox();
            passwordLabel = new Label();
            nameText = new TextBox();
            nameLabel = new Label();
            surnameText = new TextBox();
            surnameLabel = new Label();
            confirmButton = new Button();
            passwordRequirementLabel = new Label();
            showPasswordButton = new Button();
            SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(383, 204);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(111, 15);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "Nazwa użytkownika";
            // 
            // userNameText
            // 
            userNameText.Location = new Point(500, 201);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(100, 23);
            userNameText.TabIndex = 1;
            // 
            // passwordText
            // 
            passwordText.Location = new Point(500, 230);
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.Size = new Size(100, 23);
            passwordText.TabIndex = 3;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(457, 233);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(37, 15);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Hasło";
            // 
            // nameText
            // 
            nameText.Location = new Point(500, 274);
            nameText.Name = "nameText";
            nameText.Size = new Size(100, 23);
            nameText.TabIndex = 5;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(464, 277);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(30, 15);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Imię";
            // 
            // surnameText
            // 
            surnameText.Location = new Point(500, 303);
            surnameText.Name = "surnameText";
            surnameText.Size = new Size(100, 23);
            surnameText.TabIndex = 7;
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(437, 306);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(57, 15);
            surnameLabel.TabIndex = 6;
            surnameLabel.Text = "Nazwisko";
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(525, 332);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 8;
            confirmButton.Text = "Potwierdz";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // passwordRequirementLabel
            // 
            passwordRequirementLabel.AutoSize = true;
            passwordRequirementLabel.Location = new Point(500, 256);
            passwordRequirementLabel.Name = "passwordRequirementLabel";
            passwordRequirementLabel.Size = new Size(277, 15);
            passwordRequirementLabel.TabIndex = 9;
            passwordRequirementLabel.Text = "Hasło musi zawierać min 5 znaków, max 19 znaków";
            // 
            // showPasswordButton
            // 
            showPasswordButton.Location = new Point(606, 230);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(86, 23);
            showPasswordButton.TabIndex = 10;
            showPasswordButton.Text = "Pokaż hasło";
            showPasswordButton.UseVisualStyleBackColor = true;
            showPasswordButton.MouseDown += showPasswordButton_MouseDown;
            showPasswordButton.MouseUp += showPasswordButton_MouseUp;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(showPasswordButton);
            Controls.Add(passwordRequirementLabel);
            Controls.Add(confirmButton);
            Controls.Add(surnameText);
            Controls.Add(surnameLabel);
            Controls.Add(nameText);
            Controls.Add(nameLabel);
            Controls.Add(passwordText);
            Controls.Add(passwordLabel);
            Controls.Add(userNameText);
            Controls.Add(userNameLabel);
            Name = "RegisterForm";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userNameLabel;
        private TextBox userNameText;
        private TextBox passwordText;
        private Label passwordLabel;
        private TextBox nameText;
        private Label nameLabel;
        private TextBox surnameText;
        private Label surnameLabel;
        private Button confirmButton;
        private Label passwordRequirementLabel;
        private Button showPasswordButton;
    }
}