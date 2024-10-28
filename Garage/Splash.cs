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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 10;
            progressBar.Value = startP;
            PersontageLbl.Text = $"{startP}" + "%";
            if (progressBar.Value == 100)
            {
                progressBar.Value = 0;
                timer1.Stop();
                Billing obj = new Billing();
                obj.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
