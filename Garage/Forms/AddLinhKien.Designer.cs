namespace Garage.Forms
{
    partial class AddLinhKien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public event EventHandler DataUpdated;
        private int countParts;
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
        private TransactionInventory _inventory;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            countParts = _context.LinhKien.Count();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtLinhKienID = new TextBox();
            txtTenLinhKien = new TextBox();
            txtSoLuong = new TextBox();
            txtGia = new TextBox();
            txtMoTa = new TextBox();
            btnChonAnh = new Button();
            btnLuu = new Button();
            btnDong = new Button();
            pictureBoxHinhAnh = new PictureBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 130);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã linh kiện";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(372, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(475, 59);
            label2.TabIndex = 1;
            label2.Text = "Thêm Hoặc Cập Nhật Linh Kiện";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 482);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 2;
            label3.Text = "Mô tả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 218);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 3;
            label4.Text = "Tên linh kiện";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 299);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 4;
            label5.Text = "Số lượng ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(95, 398);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(37, 25);
            label6.TabIndex = 5;
            label6.Text = "Giá";
            // 
            // txtLinhKienID
            // 
            txtLinhKienID.Location = new Point(236, 130);
            txtLinhKienID.Margin = new Padding(4);
            txtLinhKienID.Name = "txtLinhKienID";
            txtLinhKienID.ReadOnly = true;
            txtLinhKienID.Size = new Size(274, 31);
            txtLinhKienID.TabIndex = 6;
            txtLinhKienID.Text = (countParts + 1).ToString();
            // 
            // txtTenLinhKien
            // 
            txtTenLinhKien.Location = new Point(236, 209);
            txtTenLinhKien.Margin = new Padding(4);
            txtTenLinhKien.Name = "txtTenLinhKien";
            txtTenLinhKien.Size = new Size(274, 31);
            txtTenLinhKien.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(236, 299);
            txtSoLuong.Margin = new Padding(4);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(274, 31);
            txtSoLuong.TabIndex = 8;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(236, 394);
            txtGia.Margin = new Padding(4);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(274, 31);
            txtGia.TabIndex = 9;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(236, 474);
            txtMoTa.Margin = new Padding(4);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(274, 31);
            txtMoTa.TabIndex = 10;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(827, 130);
            btnChonAnh.Margin = new Padding(4);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(118, 36);
            btnChonAnh.TabIndex = 11;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(310, 556);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(118, 36);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(654, 556);
            btnDong.Margin = new Padding(4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(118, 36);
            btnDong.TabIndex = 13;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += BtnDong_Click;
            // 
            // pictureBoxHinhAnh
            // 
            pictureBoxHinhAnh.Location = new Point(827, 209);
            pictureBoxHinhAnh.Margin = new Padding(4);
            pictureBoxHinhAnh.Name = "pictureBoxHinhAnh";
            pictureBoxHinhAnh.Size = new Size(264, 236);
            pictureBoxHinhAnh.TabIndex = 14;
            pictureBoxHinhAnh.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(897, 557);
            button4.Name = "Del";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 15;
            button4.Text = "Xóa";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // AddLinhKien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1299, 654);
            Controls.Add(button4);
            Controls.Add(pictureBoxHinhAnh);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(btnChonAnh);
            Controls.Add(txtMoTa);
            Controls.Add(txtGia);
            Controls.Add(txtSoLuong);
            Controls.Add(txtTenLinhKien);
            Controls.Add(txtLinhKienID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "AddLinhKien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddLinhKien";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
       MessageBox.Show("Đang đóng form...");
            this.Close();
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox txtLinhKienID;
        private TextBox txtT;
        private PictureBox pictureBox1;
        private TextBox txtTenLinhKien;
        private TextBox txtSoLuong;
        private TextBox txtGia;
        private TextBox txtMoTa;
        private Button btnChonAnh;
        private Button btnLuu;
        private Button btnDong;
        private PictureBox pictureBoxHinhAnh;
        private Button button4;
    }
}