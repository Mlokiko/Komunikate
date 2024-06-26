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
            info1Label = new Label();
            info2Label = new Label();
            info3Label = new Label();
            unBlockFriendButton = new Button();
            SuspendLayout();
            // 
            // deleteFriendButton
            // 
            deleteFriendButton.Location = new Point(482, 387);
            deleteFriendButton.Name = "deleteFriendButton";
            deleteFriendButton.Size = new Size(136, 23);
            deleteFriendButton.TabIndex = 10;
            deleteFriendButton.Text = "Usuń znajomego";
            deleteFriendButton.UseVisualStyleBackColor = true;
            deleteFriendButton.Click += deleteFriendButton_Click;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(365, 193);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(111, 15);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Nazwa użytkownika";
            // 
            // addFriendButton
            // 
            addFriendButton.Location = new Point(482, 270);
            addFriendButton.Name = "addFriendButton";
            addFriendButton.Size = new Size(136, 23);
            addFriendButton.TabIndex = 5;
            addFriendButton.Text = "Dodaj znajomego";
            addFriendButton.UseVisualStyleBackColor = true;
            addFriendButton.Click += addFriendButton_Click;
            // 
            // blockFriendButton
            // 
            blockFriendButton.Location = new Point(482, 329);
            blockFriendButton.Name = "blockFriendButton";
            blockFriendButton.Size = new Size(136, 23);
            blockFriendButton.TabIndex = 8;
            blockFriendButton.Text = "Zablokuj znajomego";
            blockFriendButton.UseVisualStyleBackColor = true;
            blockFriendButton.Click += blockFriendButton_Click;
            // 
            // checkFriendStatusButton
            // 
            checkFriendStatusButton.Location = new Point(482, 241);
            checkFriendStatusButton.Name = "checkFriendStatusButton";
            checkFriendStatusButton.Size = new Size(136, 23);
            checkFriendStatusButton.TabIndex = 4;
            checkFriendStatusButton.Text = "Sprawdz status";
            checkFriendStatusButton.UseVisualStyleBackColor = true;
            checkFriendStatusButton.Click += checkFriendStatusButton_Click;
            // 
            // userNameText
            // 
            userNameText.Location = new Point(482, 190);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(136, 23);
            userNameText.TabIndex = 2;
            // 
            // info1Label
            // 
            info1Label.AutoSize = true;
            info1Label.Location = new Point(482, 216);
            info1Label.Name = "info1Label";
            info1Label.Size = new Size(151, 15);
            info1Label.TabIndex = 3;
            info1Label.Text = "Wielkość liter ma znaczenie";
            // 
            // info2Label
            // 
            info2Label.AutoSize = true;
            info2Label.Location = new Point(463, 296);
            info2Label.Name = "info2Label";
            info2Label.Size = new Size(186, 15);
            info2Label.TabIndex = 6;
            info2Label.Text = "Wysyła zaproszenie do znajomych";
            // 
            // info3Label
            // 
            info3Label.AutoSize = true;
            info3Label.Location = new Point(386, 311);
            info3Label.Name = "info3Label";
            info3Label.Size = new Size(354, 15);
            info3Label.TabIndex = 7;
            info3Label.Text = "Gdy użytkownik i do nas wysłał zaproszenie, dodaje do znajomych";
            // 
            // unBlockFriendButton
            // 
            unBlockFriendButton.Location = new Point(482, 358);
            unBlockFriendButton.Name = "unBlockFriendButton";
            unBlockFriendButton.Size = new Size(136, 23);
            unBlockFriendButton.TabIndex = 9;
            unBlockFriendButton.Text = "Odblokuj znajomego";
            unBlockFriendButton.UseVisualStyleBackColor = true;
            unBlockFriendButton.Click += unBlockFriendButton_Click;
            // 
            // FriendsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(unBlockFriendButton);
            Controls.Add(info3Label);
            Controls.Add(info2Label);
            Controls.Add(info1Label);
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
        private Label info1Label;
        private Label info2Label;
        private Label info3Label;
        private Button unBlockFriendButton;
    }
}