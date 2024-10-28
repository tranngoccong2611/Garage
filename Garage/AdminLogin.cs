using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void AdmPassTbl_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdmSignIn_Click(object sender, EventArgs e)
        {
            if (AdmPassTbl.Text == "")
            {
                MessageBox.Show("Enter The Password!");
            }
            else if (AdmPassTbl.Text == "Password")
            {
                Analistic obj = new Analistic();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Admin Password!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
