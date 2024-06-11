namespace WinFormsTest3
{
    partial class WelcomeForm
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
            ss2 = new Label();
            ss1 = new Label();
            SuspendLayout();
            // 
            // ss2
            // 
            ss2.AutoSize = true;
            ss2.Location = new Point(415, 275);
            ss2.Name = "ss2";
            ss2.Size = new Size(145, 15);
            ss2.TabIndex = 3;
            ss2.Text = "Aby rozpocząć, zaloguj się";
            // 
            // ss1
            // 
            ss1.AutoSize = true;
            ss1.Location = new Point(372, 251);
            ss1.Name = "ss1";
            ss1.Size = new Size(239, 15);
            ss1.TabIndex = 2;
            ss1.Text = "Witaj w prostym komunikatorze tekstowym!";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 541);
            Controls.Add(ss2);
            Controls.Add(ss1);
            Name = "WelcomeForm";
            Text = "WelcomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ss2;
        private Label ss1;
    }
}