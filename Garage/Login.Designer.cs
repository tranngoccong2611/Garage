namespace Garage
{
    partial class Login
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
            panel1 = new Panel();
            AdminLog = new Label();
            label3 = new Label();
            label2 = new Label();
            UserSign = new Button();
            PasswordTbl = new TextBox();
            UsernameTbl = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(AdminLog);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(UserSign);
            panel1.Controls.Add(PasswordTbl);
            panel1.Controls.Add(UsernameTbl);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 304);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // AdminLog
            // 
            AdminLog.AutoSize = true;
            AdminLog.Font = new Font("Georgia", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            AdminLog.ForeColor = SystemColors.ButtonFace;
            AdminLog.Location = new Point(109, 255);
            AdminLog.Name = "AdminLog";
            AdminLog.Size = new Size(59, 18);
            AdminLog.TabIndex = 20;
            AdminLog.Text = "Admin";
            AdminLog.Click += AdminLog_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(3, 159);
            label3.Name = "label3";
            label3.Size = new Size(82, 18);
            label3.TabIndex = 19;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(3, 98);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 18;
            label2.Text = "Username";
            // 
            // UserSign
            // 
            UserSign.BackColor = Color.Silver;
            UserSign.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserSign.ForeColor = Color.Black;
            UserSign.Location = new Point(100, 200);
            UserSign.Name = "UserSign";
            UserSign.Size = new Size(77, 31);
            UserSign.TabIndex = 17;
            UserSign.Text = "Sign in";
            UserSign.UseVisualStyleBackColor = false;
            UserSign.Click += UserSign_Click;
            // 
            // PasswordTbl
            // 
            PasswordTbl.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordTbl.Location = new Point(91, 159);
            PasswordTbl.Name = "PasswordTbl";
            PasswordTbl.PasswordChar = '*';
            PasswordTbl.Size = new Size(151, 25);
            PasswordTbl.TabIndex = 6;
            // 
            // UsernameTbl
            // 
            UsernameTbl.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameTbl.Location = new Point(92, 96);
            UsernameTbl.Name = "UsernameTbl";
            UsernameTbl.Size = new Size(151, 25);
            UsernameTbl.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 31);
            label1.TabIndex = 4;
            label1.Text = "Login";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 304);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox PasswordTbl;
        private TextBox UsernameTbl;
        private Label label2;
        private Button UserSign;
        private Label label3;
        private Label AdminLog;
    }
}