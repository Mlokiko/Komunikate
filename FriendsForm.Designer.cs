﻿namespace WinFormsTest3
{
    partial class FriendsForm
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
            deleteFriendButton = new Button();
            userNameLabel = new Label();
            addFriendButton = new Button();
            blockFriendButton = new Button();
            checkFriendStatusButton = new Button();
            userNameText = new TextBox();
            SuspendLayout();
            // 
            // deleteFriendButton
            // 
            deleteFriendButton.Location = new Point(424, 236);
            deleteFriendButton.Name = "deleteFriendButton";
            deleteFriendButton.Size = new Size(136, 23);
            deleteFriendButton.TabIndex = 0;
            deleteFriendButton.Text = "Usuń znajomego";
            deleteFriendButton.UseVisualStyleBackColor = true;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(325, 188);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(111, 15);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Nazwa użytkownika";
            // 
            // addFriendButton
            // 
            addFriendButton.Location = new Point(424, 283);
            addFriendButton.Name = "addFriendButton";
            addFriendButton.Size = new Size(136, 23);
            addFriendButton.TabIndex = 2;
            addFriendButton.Text = "Dodaj znajomego";
            addFriendButton.UseVisualStyleBackColor = true;
            // 
            // blockFriendButton
            // 
            blockFriendButton.Location = new Point(424, 333);
            blockFriendButton.Name = "blockFriendButton";
            blockFriendButton.Size = new Size(136, 23);
            blockFriendButton.TabIndex = 3;
            blockFriendButton.Text = "Zablokuj znajomego";
            blockFriendButton.UseVisualStyleBackColor = true;
            // 
            // checkFriendStatusButton
            // 
            checkFriendStatusButton.Location = new Point(548, 184);
            checkFriendStatusButton.Name = "checkFriendStatusButton";
            checkFriendStatusButton.Size = new Size(109, 23);
            checkFriendStatusButton.TabIndex = 4;
            checkFriendStatusButton.Text = "Sprawdz status";
            checkFriendStatusButton.UseVisualStyleBackColor = true;
            checkFriendStatusButton.Click += checkFriendStatusButton_Click;
            // 
            // userNameText
            // 
            userNameText.Location = new Point(442, 185);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(100, 23);
            userNameText.TabIndex = 5;
            // 
            // FriendsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(userNameText);
            Controls.Add(checkFriendStatusButton);
            Controls.Add(blockFriendButton);
            Controls.Add(addFriendButton);
            Controls.Add(userNameLabel);
            Controls.Add(deleteFriendButton);
            Name = "FriendsForm";
            Text = "FriendsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button deleteFriendButton;
        private Label userNameLabel;
        private Button addFriendButton;
        private Button blockFriendButton;
        private Button checkFriendStatusButton;
        private TextBox userNameText;
    }
}