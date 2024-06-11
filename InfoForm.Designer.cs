namespace WinFormsTest3
{
    partial class InfoForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 225);
            label1.Name = "label1";
            label1.Size = new Size(183, 15);
            label1.TabIndex = 0;
            label1.Text = "Standardowe IP serwera: 127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 249);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 1;
            label2.Text = "Standardowy Port: 5432 ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(294, 275);
            label3.Name = "label3";
            label3.Size = new Size(232, 15);
            label3.TabIndex = 2;
            label3.Text = "Standardowa nazwa bazy danych: postgres";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(294, 300);
            label4.Name = "label4";
            label4.Size = new Size(401, 15);
            label4.TabIndex = 3;
            label4.Text = "Standardowo aplikacja automatycznie łączy się z podanym wyżej serwerem";
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InfoForm";
            Text = "Info";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}