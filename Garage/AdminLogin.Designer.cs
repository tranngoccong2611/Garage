namespace Garage
{
    partial class AdminLogin
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
            label4 = new Label();
            label3 = new Label();
            AdmSignIn = new Button();
            AdmPassTbl = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(103, 152);
            label4.Name = "label4";
            label4.Size = new Size(45, 18);
            label4.TabIndex = 24;
            label4.Text = "Back";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(2, 80);
            label3.Name = "label3";
            label3.Size = new Size(82, 18);
            label3.TabIndex = 23;
            label3.Text = "Password";
            // 
            // AdmSignIn
            // 
            AdmSignIn.BackColor = Color.Silver;
            AdmSignIn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdmSignIn.ForeColor = Color.Black;
            AdmSignIn.Location = new Point(90, 118);
            AdmSignIn.Name = "AdmSignIn";
            AdmSignIn.Size = new Size(77, 31);
            AdmSignIn.TabIndex = 22;
            AdmSignIn.Text = "Sign in";
            AdmSignIn.UseVisualStyleBackColor = false;
            AdmSignIn.Click += AdmSignIn_Click;
            // 
            // AdmPassTbl
            // 
            AdmPassTbl.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdmPassTbl.Location = new Point(90, 73);
            AdmPassTbl.Name = "AdmPassTbl";
            AdmPassTbl.Size = new Size(151, 25);
            AdmPassTbl.TabIndex = 21;
            AdmPassTbl.TextChanged += AdmPassTbl_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(80, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 31);
            label1.TabIndex = 25;
            label1.Text = "Admin";
            label1.Click += label1_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(533, 190);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(AdmSignIn);
            Controls.Add(AdmPassTbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button AdmSignIn;
        private TextBox AdmPassTbl;
        private Label label1;
    }
}