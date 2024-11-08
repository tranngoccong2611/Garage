using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Forms.MainForm
{
  
        public partial class CustomerCareForm : Form
        {
            public CustomerCareForm()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                this.lblCustomerId = new System.Windows.Forms.Label();
                this.txtCustomerId = new System.Windows.Forms.TextBox();
                this.lblCareDetails = new System.Windows.Forms.Label();
                this.txtCareDetails = new System.Windows.Forms.TextBox();
                this.btnSaveCare = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // lblCustomerId
                // 
                this.lblCustomerId.AutoSize = true;
                this.lblCustomerId.Location = new System.Drawing.Point(20, 20);
                this.lblCustomerId.Name = "lblCustomerId";
                this.lblCustomerId.Size = new System.Drawing.Size(71, 13);
                this.lblCustomerId.TabIndex = 0;
                this.lblCustomerId.Text = "ID Khách Hàng:";
                // 
                // txtCustomerId
                // 
                this.txtCustomerId.Location = new System.Drawing.Point(100, 20);
                this.txtCustomerId.Name = "txtCustomerId";
                this.txtCustomerId.Size = new System.Drawing.Size(200, 20);
                this.txtCustomerId.TabIndex = 1;
                // 
                // lblCareDetails
                // 
                this.lblCareDetails.AutoSize = true;
                this.lblCareDetails.Location = new System.Drawing.Point(20, 60);
                this.lblCareDetails.Name = "lblCareDetails";
                this.lblCareDetails.Size = new System.Drawing.Size(65, 13);
                this.lblCareDetails.TabIndex = 2;
                this.lblCareDetails.Text = "Chi tiết chăm sóc:";
                // 
                // txtCareDetails
                // 
                this.txtCareDetails.Location = new System.Drawing.Point(100, 60);
                this.txtCareDetails.Multiline = true;
                this.txtCareDetails.Size = new System.Drawing.Size(200, 60);
                this.txtCareDetails.TabIndex = 3;
                // 
                // btnSaveCare
                // 
                this.btnSaveCare.Location = new System.Drawing.Point(100, 130);
                this.btnSaveCare.Name = "btnSaveCare";
                this.btnSaveCare.Size = new System.Drawing.Size(75, 23);
                this.btnSaveCare.TabIndex = 4;
                this.btnSaveCare.Text = "Lưu";
                this.btnSaveCare.UseVisualStyleBackColor = true;
                this.btnSaveCare.Click += new System.EventHandler(this.btnSaveCare_Click);
                // 
                // CustomerCareForm
                // 
                this.ClientSize = new System.Drawing.Size(320, 180);
                this.Controls.Add(this.btnSaveCare);
                this.Controls.Add(this.txtCareDetails);
                this.Controls.Add(this.lblCareDetails);
                this.Controls.Add(this.txtCustomerId);
                this.Controls.Add(this.lblCustomerId);
                this.Name = "CustomerCareForm";
                this.Text = "Chăm sóc khách hàng";
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            private Label lblCustomerId;
            private TextBox txtCustomerId;
            private Label lblCareDetails;
            private TextBox txtCareDetails;
            private Button btnSaveCare;

            private void btnSaveCare_Click(object sender, EventArgs e)
            {
                // Logic to save customer care data goes here
                string customerId = txtCustomerId.Text;
                string careDetails = txtCareDetails.Text;

                MessageBox.Show($"Chi tiết chăm sóc được lưu:\nID Khách Hàng: {customerId}\nChi tiết: {careDetails}");
            }
        }
    

}
