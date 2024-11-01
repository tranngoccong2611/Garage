using System;
using System.Drawing;
using System.Windows.Forms;
using Garage;
namespace Garage
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            rememberMeCheckBox = new CheckBox();
            forgotPasswordLinkLabel = new LinkLabel();
            signInButton = new Button();
            getStartedLinkLabel = new LinkLabel();
            logoPictureBox = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(71, 143);
            emailTextBox.Margin = new Padding(4, 5, 4, 5);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "Email or Username";
            emailTextBox.Size = new Size(427, 31);
            emailTextBox.TabIndex = 0;
            emailTextBox.TextChanged += emailTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(71, 196);
            passwordTextBox.Margin = new Padding(4, 5, 4, 5);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(427, 31);
            passwordTextBox.TabIndex = 1;
            // 
            // rememberMeCheckBox
            // 
            rememberMeCheckBox.AutoSize = true;
            rememberMeCheckBox.Location = new Point(71, 246);
            rememberMeCheckBox.Margin = new Padding(4, 5, 4, 5);
            rememberMeCheckBox.Name = "rememberMeCheckBox";
            rememberMeCheckBox.Size = new Size(154, 29);
            rememberMeCheckBox.TabIndex = 2;
            rememberMeCheckBox.Text = "Remember me";
            rememberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // forgotPasswordLinkLabel
            // 
            forgotPasswordLinkLabel.AutoSize = true;
            forgotPasswordLinkLabel.LinkColor = Color.Goldenrod;
            forgotPasswordLinkLabel.Location = new Point(291, 246);
            forgotPasswordLinkLabel.Margin = new Padding(4, 0, 4, 0);
            forgotPasswordLinkLabel.Name = "forgotPasswordLinkLabel";
            forgotPasswordLinkLabel.Size = new Size(154, 25);
            forgotPasswordLinkLabel.TabIndex = 3;
            forgotPasswordLinkLabel.TabStop = true;
            forgotPasswordLinkLabel.Text = "Forgot Password?";
            forgotPasswordLinkLabel.LinkClicked += ForgotPasswordLinkLabel_LinkClicked;
            // 
            // signInButton
            // 
            signInButton.BackColor = Color.Goldenrod;
            signInButton.FlatStyle = FlatStyle.Flat;
            signInButton.Location = new Point(71, 304);
            signInButton.Margin = new Padding(4, 5, 4, 5);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(429, 50);
            signInButton.TabIndex = 4;
            signInButton.Text = "Sign in";
            signInButton.UseVisualStyleBackColor = false;
            signInButton.Click += SignInButton_Click;
            // 
            // getStartedLinkLabel
            // 
            getStartedLinkLabel.AutoSize = true;
            getStartedLinkLabel.LinkColor = Color.Goldenrod;
            getStartedLinkLabel.Location = new Point(71, 385);
            getStartedLinkLabel.Margin = new Padding(4, 0, 4, 0);
            getStartedLinkLabel.Name = "getStartedLinkLabel";
            getStartedLinkLabel.Size = new Size(290, 25);
            getStartedLinkLabel.TabIndex = 7;
            getStartedLinkLabel.TabStop = true;
            getStartedLinkLabel.Text = "Don't have an account? Get Started";
            getStartedLinkLabel.LinkClicked += GetStartedLinkLabel_LinkClicked;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(233, 25);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(100, 39);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(161, 67);
            label1.Name = "label1";
            label1.Size = new Size(254, 54);
            label1.TabIndex = 8;
            label1.Text = "Lorem Ispum";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGoldenrodYellow;
            ClientSize = new Size(571, 502);
            Controls.Add(label1);
            Controls.Add(logoPictureBox);
            Controls.Add(getStartedLinkLabel);
            Controls.Add(signInButton);
            Controls.Add(forgotPasswordLinkLabel);
            Controls.Add(rememberMeCheckBox);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private CheckBox rememberMeCheckBox;
        private LinkLabel forgotPasswordLinkLabel;
        private Button signInButton;
        private LinkLabel getStartedLinkLabel;
        private PictureBox logoPictureBox;
        private Label label1;

        private void SignInButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login button clicked!");
        }

        private void ForgotPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword forgetpass=new ForgetPassword();
            forgetpass.Show();
        }

        private void GetStartedLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle email text change if necessary
        }
    }
}
