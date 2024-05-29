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
            usersDataGridView = new DataGridView();
            messagesdDataGridView = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(usersDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(messagesdDataGridView);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(982, 541);
            splitContainer1.SplitterDistance = 327;
            splitContainer1.TabIndex = 0;
            // 
            // usersDataGridView
            // 
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Location = new Point(0, 0);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.Size = new Size(333, 541);
            usersDataGridView.TabIndex = 0;
            // 
            // messagesdDataGridView
            // 
            messagesdDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            messagesdDataGridView.Location = new Point(8, -3);
            messagesdDataGridView.Name = "messagesdDataGridView";
            messagesdDataGridView.Size = new Size(648, 541);
            messagesdDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 265);
            label1.Name = "label1";
            label1.Size = new Size(290, 15);
            label1.TabIndex = 0;
            label1.Text = "Wybierz użytkownika aby odczytać konwersacje z nim";
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
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)messagesdDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private DataGridView usersDataGridView;
        private DataGridView messagesdDataGridView;
    }
}