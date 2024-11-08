
using Garage.Forms;
using Garage.Forms.Style;



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

        #region

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            UsernameTbl = new TextBox();
            PasswordTbl = new TextBox();
            UserSign = new Button();
            AdminLog = new Label();

            // Form Properties
            ClientSize = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";

            // Panel Properties
            panel1.Dock = DockStyle.Fill;
            panel1.BackColor = Color.LightGray;

            // Title Label
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Text = "Login";
            label1.Location = new Point(170, 30);

            // Username TextBox
            UsernameTbl.Location = new Point(120, 80);
            UsernameTbl.Size = new Size(160, 30);
            UsernameTbl.PlaceholderText = "Username";

            // Password TextBox
            PasswordTbl.Location = new Point(120, 130);
            PasswordTbl.Size = new Size(160, 30);
            PasswordTbl.PasswordChar = '*';
            PasswordTbl.PlaceholderText = "Password";

            // Sign In Button
            UserSign.Text = "Sign In";
            UserSign.Size = new Size(160, 40);
            UserSign.Location = new Point(120, 180);
            UserSign.BackColor = Color.CornflowerBlue;
            UserSign.ForeColor = Color.White;
            UserSign.FlatStyle = FlatStyle.Flat;
            UserSign.FlatAppearance.BorderSize = 0;
            UserSign.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Admin Label
            AdminLog.AutoSize = true;
            AdminLog.Text = "Login as Admin";
            AdminLog.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            AdminLog.ForeColor = Color.Blue;
            AdminLog.Location = new Point(155, 240);
            AdminLog.Cursor = Cursors.Hand;

            // Adding Controls to Panel
            panel1.Controls.Add(label1);
            panel1.Controls.Add(UsernameTbl);
            panel1.Controls.Add(PasswordTbl);
            panel1.Controls.Add(UserSign);
            panel1.Controls.Add(AdminLog);
            Controls.Add(panel1);

            // Event Handlers
            UserSign.Click += UserSign_Click;
            AdminLog.Click += AdminLog_Click;
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox PasswordTbl;
        private TextBox UsernameTbl;
        private Label label2;
        private Button UserSign;
        
        private Label AdminLog;
    }
}
