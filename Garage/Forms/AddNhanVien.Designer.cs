namespace Garage.Forms
{
    partial class AddNhanVien
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            cmbGioiTinh = new ComboBox();
            txtEmail = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            label9 = new Label();
            txtDiaChi = new TextBox();
            btnLuu = new Button();
            btnDong = new Button();
            btnChonAnh = new Button();
            pictureBoxHinhAnh = new PictureBox();
            cmbChucVu = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 52);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "HoTen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 106);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Giới tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 160);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 3;
            label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 209);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 4;
            label5.Text = "Số điện thoại";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 259);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(416, 53);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 6;
            label7.Text = "Chức vụ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 308);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 7;
            label8.Tag = "";
            label8.Text = "Địa chỉ";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(150, 53);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(219, 23);
            txtHoTen.TabIndex = 9;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(150, 206);
            txtSoDienThoai.Margin = new Padding(3, 2, 3, 2);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(219, 23);
            txtSoDienThoai.TabIndex = 12;
            // 
            // cmbGioiTinh
            // 
            cmbGioiTinh.FormattingEnabled = true;
            cmbGioiTinh.Location = new Point(150, 103);
            cmbGioiTinh.Margin = new Padding(3, 2, 3, 2);
            cmbGioiTinh.Name = "cmbGioiTinh";
            cmbGioiTinh.Size = new Size(219, 23);
            cmbGioiTinh.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 251);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 23);
            txtEmail.TabIndex = 14;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(150, 152);
            dtpNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(219, 23);
            dtpNgaySinh.TabIndex = 18;
            // 
            // label9
            // 
            label9.BackColor = Color.LightPink;
            label9.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.LimeGreen;
            label9.Location = new Point(141, 7);
            label9.Name = "label9";
            label9.Size = new Size(418, 34);
            label9.TabIndex = 20;
            label9.Text = "Thêm Hoặc Cập Nhật Thông Tin Nhân Viên";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(150, 300);
            txtDiaChi.Margin = new Padding(3, 2, 3, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(215, 23);
            txtDiaChi.TabIndex = 21;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(141, 354);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(82, 22);
            btnLuu.TabIndex = 23;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(403, 354);
            btnDong.Margin = new Padding(3, 2, 3, 2);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(82, 22);
            btnDong.TabIndex = 24;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(416, 106);
            btnChonAnh.Margin = new Padding(3, 2, 3, 2);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(82, 22);
            btnChonAnh.TabIndex = 25;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // pictureBoxHinhAnh
            // 
            pictureBoxHinhAnh.Location = new Point(513, 106);
            pictureBoxHinhAnh.Margin = new Padding(3, 2, 3, 2);
            pictureBoxHinhAnh.Name = "pictureBoxHinhAnh";
            pictureBoxHinhAnh.Size = new Size(192, 217);
            pictureBoxHinhAnh.TabIndex = 26;
            pictureBoxHinhAnh.TabStop = false;
            // 
            // cmbChucVu
            // 
            cmbChucVu.FormattingEnabled = true;
            cmbChucVu.Location = new Point(513, 52);
            cmbChucVu.Margin = new Padding(3, 2, 3, 2);
            cmbChucVu.Name = "cmbChucVu";
            cmbChucVu.Size = new Size(192, 23);
            cmbChucVu.TabIndex = 28;
            // 
            // AddNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightPink;
            ClientSize = new Size(727, 423);
            Controls.Add(cmbChucVu);
            Controls.Add(pictureBoxHinhAnh);
            Controls.Add(btnChonAnh);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(txtDiaChi);
            Controls.Add(label9);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtEmail);
            Controls.Add(cmbGioiTinh);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtHoTen);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddNhanVien";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private ComboBox cmbGioiTinh;
        private TextBox txtEmail;
        private DateTimePicker dtpNgaySinh;
        private Label label9;
        private TextBox txtDiaChi;
        private Button btnLuu;
        private Button btnDong;
        private Button btnChonAnh;
        private PictureBox pictureBoxHinhAnh;
        private ComboBox cmbChucVu;
    }
}