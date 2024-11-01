using System;
using System.Windows.Forms;

namespace Garage
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

       

        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.CheckBox termsCheckBox;
        private System.Windows.Forms.Button signUpButton;

        private void signUpButton_Click(object sender, EventArgs e)
        {
            // Implement registration logic here
            MessageBox.Show("Sign up button clicked!");
        }
    }
}