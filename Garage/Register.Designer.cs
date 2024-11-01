namespace Garage
{
    partial class Register
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Register";
            
            
                this.firstNameTextBox = new System.Windows.Forms.TextBox();
                this.lastNameTextBox = new System.Windows.Forms.TextBox();
                this.emailTextBox = new System.Windows.Forms.TextBox();
                this.passwordTextBox = new System.Windows.Forms.TextBox();
                this.termsCheckBox = new System.Windows.Forms.CheckBox();
                this.signUpButton = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // firstNameTextBox
                // 
                this.firstNameTextBox.Location = new System.Drawing.Point(50, 50);
                this.firstNameTextBox.Name = "firstNameTextBox";
                this.firstNameTextBox.Size = new System.Drawing.Size(300, 25);
                this.firstNameTextBox.TabIndex = 0;
                this.firstNameTextBox.Text = "First name";
                // 
                // lastNameTextBox
                // 
                this.lastNameTextBox.Location = new System.Drawing.Point(50, 100);
                this.lastNameTextBox.Name = "lastNameTextBox";
                this.lastNameTextBox.Size = new System.Drawing.Size(300, 25);
                this.lastNameTextBox.TabIndex = 1;
                this.lastNameTextBox.Text = "Last name";
                // 
                // emailTextBox
                // 
                this.emailTextBox.Location = new System.Drawing.Point(50, 150);
                this.emailTextBox.Name = "emailTextBox";
                this.emailTextBox.Size = new System.Drawing.Size(300, 25);
                this.emailTextBox.TabIndex = 2;
                this.emailTextBox.Text = "Email";
                // 
                // passwordTextBox
                // 
                this.passwordTextBox.Location = new System.Drawing.Point(50, 200);
                this.passwordTextBox.Name = "passwordTextBox";
                this.passwordTextBox.PasswordChar = '*';
                this.passwordTextBox.Size = new System.Drawing.Size(300, 25);
                this.passwordTextBox.TabIndex = 3;
                this.passwordTextBox.Text = "Password";
                // 
                // termsCheckBox
                // 
                this.termsCheckBox.AutoSize = true;
                this.termsCheckBox.Location = new System.Drawing.Point(50, 250);
                this.termsCheckBox.Name = "termsCheckBox";
                this.termsCheckBox.Size = new System.Drawing.Size(272, 20);
                this.termsCheckBox.TabIndex = 4;
                this.termsCheckBox.Text = "By proceeding, you agree to the Terms and Conditions";
                this.termsCheckBox.UseVisualStyleBackColor = true;
                // 
                // signUpButton
                // 
                this.signUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
                this.signUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.signUpButton.Location = new System.Drawing.Point(50, 300);
                this.signUpButton.Name = "signUpButton";
                this.signUpButton.Size = new System.Drawing.Size(300, 30);
                this.signUpButton.TabIndex = 5;
                this.signUpButton.Text = "Sign up with email";
                this.signUpButton.UseVisualStyleBackColor = false;
                this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
                // 
                // RegistrationForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.ClientSize = new System.Drawing.Size(400, 350);
                this.Controls.Add(this.signUpButton);
                this.Controls.Add(this.termsCheckBox);
                this.Controls.Add(this.passwordTextBox);
                this.Controls.Add(this.emailTextBox);
                this.Controls.Add(this.lastNameTextBox);
                this.Controls.Add(this.firstNameTextBox);
                this.Name = "RegistrationForm";
                this.Text = "Create your ID";
                this.ResumeLayout(false);
                this.PerformLayout();
            
        }

        #endregion
    }
}