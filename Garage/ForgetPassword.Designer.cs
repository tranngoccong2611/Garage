
namespace Garage
{
    partial class ForgetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label labelNewPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxNewPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonResetPassword;
        private Panel panelTitle;
        private Panel panelContent;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Text = "Forget Password";

            // Title Panel
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Height = 60;

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Reset Your Password";
            titleLabel.ForeColor = System.Drawing.Color.White;
            titleLabel.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panelTitle.Controls.Add(titleLabel);
            this.Controls.Add(this.panelTitle);

            // Content Panel
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;

            // Initialize labels, textboxes, and button
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.buttonResetPassword = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // labelNewPassword
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(50, 30);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(90, 15);
            this.labelNewPassword.TabIndex = 0;
            this.labelNewPassword.Text = "New Password:";

            // labelConfirmPassword
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(50, 80);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(104, 15);
            this.labelConfirmPassword.TabIndex = 1;
            this.labelConfirmPassword.Text = "Confirm Password:";

            // textBoxNewPassword
            this.textBoxNewPassword.Location = new System.Drawing.Point(200, 27);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(200, 23);
            this.textBoxNewPassword.TabIndex = 2;

            // textBoxConfirmPassword
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(200, 77);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(200, 23);
            this.textBoxConfirmPassword.TabIndex = 3;

            // buttonResetPassword
            this.buttonResetPassword.Location = new System.Drawing.Point(200, 120);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(100, 30);
            this.buttonResetPassword.TabIndex = 4;
            this.buttonResetPassword.Text = "Reset Password";
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);

            // Adding controls to the content panel
            this.panelContent.Controls.Add(this.buttonResetPassword);
            this.panelContent.Controls.Add(this.textBoxConfirmPassword);
            this.panelContent.Controls.Add(this.textBoxNewPassword);
            this.panelContent.Controls.Add(this.labelConfirmPassword);
            this.panelContent.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.panelContent);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
