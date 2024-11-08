using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Forms.MainForm
{
    public partial class SquarePartsForm : Form
    {
        public SquarePartsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblPartName = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSavePart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(20, 20);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(57, 13);
            this.lblPartName.TabIndex = 0;
            this.lblPartName.Text = "Tên linh kiện:";
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(100, 20);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(200, 20);
            this.txtPartName.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 60);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 13);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(100, 60);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // btnSavePart
            // 
            this.btnSavePart.Location = new System.Drawing.Point(100, 100);
            this.btnSavePart.Name = "btnSavePart";
            this.btnSavePart.Size = new System.Drawing.Size(75, 23);
            this.btnSavePart.TabIndex = 4;
            this.btnSavePart.Text = "Lưu";
            this.btnSavePart.UseVisualStyleBackColor = true;
            this.btnSavePart.Click += new System.EventHandler(this.btnSavePart_Click);
            // 
            // PartsForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.btnSavePart);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.lblPartName);
            this.Name = "PartsForm";
            this.Text = "Quản lý linh kiện";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblPartName;
        private TextBox txtPartName;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnSavePart;

        private void btnSavePart_Click(object sender, EventArgs e)
        {
            // Logic to save part data goes here
            string partName = txtPartName.Text;
            string quantity = txtQuantity.Text;

            MessageBox.Show($"Linh kiện được lưu:\nTên: {partName}\nSố lượng: {quantity}");
        }
    }
}
