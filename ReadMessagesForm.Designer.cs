namespace WinFormsTest3
{
    partial class ReadMessagesForm
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
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            labelFriends = new Label();
            findingFriendsButton = new Button();
            FriendsBox = new ListBox();
            friendNameTextBox = new TextBox();
            label2 = new Label();
            messagesdDataGridView = new DataGridView();
            listboxfriends = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)messagesdDataGridView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(labelFriends);
            splitContainer1.Panel1.Controls.Add(findingFriendsButton);
            splitContainer1.Panel1.Controls.Add(FriendsBox);
            splitContainer1.Panel1.Controls.Add(friendNameTextBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(messagesdDataGridView);
            splitContainer1.Size = new Size(982, 541);
            splitContainer1.SplitterDistance = 327;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(32, 441);
            label1.Name = "label1";
            label1.Size = new Size(261, 15);
            label1.TabIndex = 0;
            label1.Text = "Wybierz użytkownika, aby odczytać konwersacje";
            // 
            // labelFriends
            // 
            labelFriends.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelFriends.AutoSize = true;
            labelFriends.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelFriends.Location = new Point(29, 25);
            labelFriends.Name = "labelFriends";
            labelFriends.Size = new Size(108, 21);
            labelFriends.TabIndex = 4;
            labelFriends.Text = "Twoi znajomi:";
            // 
            // findingFriendsButton
            // 
            findingFriendsButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            findingFriendsButton.Location = new Point(29, 488);
            findingFriendsButton.Name = "findingFriendsButton";
            findingFriendsButton.Size = new Size(272, 23);
            findingFriendsButton.TabIndex = 3;
            findingFriendsButton.Text = "Znajdź wiadomości";
            findingFriendsButton.UseVisualStyleBackColor = true;
            findingFriendsButton.Click += button1_Click;
            // 
            // FriendsBox
            // 
            FriendsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FriendsBox.FormattingEnabled = true;
            FriendsBox.ItemHeight = 15;
            FriendsBox.Location = new Point(32, 59);
            FriendsBox.Name = "FriendsBox";
            FriendsBox.Size = new Size(272, 304);
            FriendsBox.TabIndex = 2;
            // 
            // friendNameTextBox
            // 
            friendNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            friendNameTextBox.Location = new Point(29, 459);
            friendNameTextBox.Name = "friendNameTextBox";
            friendNameTextBox.PlaceholderText = "Wpisz imię znajomego";
            friendNameTextBox.Size = new Size(272, 23);
            friendNameTextBox.TabIndex = 1;
            friendNameTextBox.TextAlign = HorizontalAlignment.Center;
            friendNameTextBox.TextChanged += textBox1_TextChanged;
            friendNameTextBox.Enter += textBox1_TextChanged;
            friendNameTextBox.KeyPress += textBox1_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(15, 517);
            label2.Name = "label2";
            label2.Size = new Size(633, 15);
            label2.TabIndex = 5;
            label2.Text = "(Gdy wybierzesz swoją nazwę użytkownika zostaną wyświetlone wszystkie wiadomości wysłane do Ciebie i przez Ciebie)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // messagesdDataGridView
            // 
            messagesdDataGridView.AllowUserToAddRows = false;
            messagesdDataGridView.AllowUserToDeleteRows = false;
            messagesdDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            messagesdDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            messagesdDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            messagesdDataGridView.Location = new Point(26, 25);
            messagesdDataGridView.Name = "messagesdDataGridView";
            messagesdDataGridView.ReadOnly = true;
            messagesdDataGridView.Size = new Size(597, 457);
            messagesdDataGridView.TabIndex = 3;
            // 
            // listboxfriends
            // 
            listboxfriends.Location = new Point(0, 0);
            listboxfriends.Name = "listboxfriends";
            listboxfriends.Size = new Size(120, 96);
            listboxfriends.TabIndex = 0;
            // 
            // ReadMessagesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(splitContainer1);
            Name = "ReadMessagesForm";
            Text = "Read Messages";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)messagesdDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listboxfriends;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox friendNameTextBox;
        private Button findingFriendsButton;
        private ListBox FriendsBox;
        private Label labelFriends;
        private DataGridView messagesdDataGridView;
        private Label label2;
    }
}