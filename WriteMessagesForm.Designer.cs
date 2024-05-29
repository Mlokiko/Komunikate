namespace WinFormsTest3
{
    partial class WriteMessagesForm
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
            messageContentLabel = new Label();
            userNameText = new TextBox();
            sendButton = new Button();
            messageContentText = new RichTextBox();
            SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(227, 104);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(114, 15);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Nazwa użytkownika:";
            // 
            // messageContentLabel
            // 
            messageContentLabel.AutoSize = true;
            messageContentLabel.Location = new Point(210, 151);
            messageContentLabel.Name = "messageContentLabel";
            messageContentLabel.Size = new Size(131, 15);
            messageContentLabel.TabIndex = 2;
            messageContentLabel.Text = "Zawartość wiadomości:";
            // 
            // userNameText
            // 
            userNameText.Location = new Point(344, 101);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(199, 23);
            userNameText.TabIndex = 4;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(698, 416);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 6;
            sendButton.Text = "Wyślij";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // messageContentText
            // 
            messageContentText.Location = new Point(344, 151);
            messageContentText.Name = "messageContentText";
            messageContentText.Size = new Size(429, 233);
            messageContentText.TabIndex = 7;
            messageContentText.Text = "";
            // 
            // WriteMessagesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(messageContentText);
            Controls.Add(sendButton);
            Controls.Add(userNameText);
            Controls.Add(messageContentLabel);
            Controls.Add(userNameLabel);
            Name = "WriteMessagesForm";
            Text = "Write Messages";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userNameLabel;
        private Label messageContentLabel;
        private TextBox userNameText;
        private Button sendButton;
        private RichTextBox messageContentText;
    }
}