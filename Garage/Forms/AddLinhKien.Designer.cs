namespace Garage.Forms
{
    partial class AddLinhKien
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 104);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã linh kiện";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(298, 20);
            label2.Name = "label2";
            label2.Size = new Size(380, 47);
            label2.TabIndex = 1;
            label2.Text = "Thêm Hoặc Cập Nhật Linh Kiện";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 386);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 2;
            label3.Text = "Mô tả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 174);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 3;
            label4.Text = "Tên linh kiện";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 239);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 4;
            label5.Text = "Số lượng ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 318);
            label6.Name = "label6";
            label6.Size = new Size(31, 20);
            label6.TabIndex = 5;
            label6.Text = "Giá";
            // 
            // txtLinhKienID
            // 
            txtLinhKienID.Location = new Point(189, 104);
            txtLinhKienID.Name = "txtLinhKienID";
            txtLinhKienID.Size = new Size(220, 27);
            txtLinhKienID.TabIndex = 6;
            // 
            // txtTenLinhKien
            // 
            txtTenLinhKien.Location = new Point(189, 167);
            txtTenLinhKien.Name = "txtTenLinhKien";
            txtTenLinhKien.Size = new Size(220, 27);
            txtTenLinhKien.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(189, 239);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(220, 27);
            txtSoLuong.TabIndex = 8;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(189, 315);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(220, 27);
            txtGia.TabIndex = 9;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(189, 379);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(220, 27);
            txtMoTa.TabIndex = 10;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(717, 105);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 11;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(248, 445);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(523, 445);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(94, 29);
            btnDong.TabIndex = 13;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            // 
            // pictureBoxHinhAnh
            // 
            pictureBoxHinhAnh.Location = new Point(678, 174);
            pictureBoxHinhAnh.Name = "pictureBoxHinhAnh";
            pictureBoxHinhAnh.Size = new Size(211, 189);
            pictureBoxHinhAnh.TabIndex = 14;
            pictureBoxHinhAnh.TabStop = false;
            // 
            // AddLinhKien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 523);
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
            Name = "AddLinhKien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddLinhKien";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}