using Garage.Data;
using Garage.Data.Models;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Garage.Forms
{
    public partial class AddNhanVien : Form
    {
        private bool isUpdate;
        private NhanVien existingNhanVien;
        private GaraOtoDbContext _context;

        // Constructor nhận các tham số từ DI
        public AddNhanVien(bool isUpdate, NhanVien existingNhanVien = null)
        {
            InitializeComponent();
            _context = new GaraOtoDbContext();
            this.isUpdate = isUpdate;
            this.existingNhanVien = existingNhanVien;

            // Cấu hình các ComboBox và các điều khiển khác
            cmbGioiTinh.Items.Add(new { Text = "Nam", Value = 1 });
            cmbGioiTinh.Items.Add(new { Text = "Nữ", Value = 2 });
            cmbGioiTinh.DisplayMember = "Text";
            cmbGioiTinh.ValueMember = "Value";

            cmbChucVu.Items.Add(new { Text = "Nhân viên", Value = 1 });
            cmbChucVu.Items.Add(new { Text = "Quản lý", Value = 2 });
            cmbChucVu.DisplayMember = "Text";
            cmbChucVu.ValueMember = "Value";

            if (isUpdate && existingNhanVien != null)
            {
                // Cập nhật dữ liệu nhân viên nếu là chế độ cập nhật
                this.Text = "Cập nhật thông tin nhân viên";
                // Đổ dữ liệu của nhân viên vào các TextBox
                txtHoTen.Text = existingNhanVien.HoTen;
                txtEmail.Text = existingNhanVien.Email;
                txtSoDienThoai.Text = existingNhanVien.SoDienThoai;
                txtDiaChi.Text = existingNhanVien.DiaChi;

                if (existingNhanVien.NgaySinh.HasValue)
                {
                    dtpNgaySinh.Value = existingNhanVien.NgaySinh.Value;
                }

                if (!string.IsNullOrEmpty(existingNhanVien.HinhAnh))
                {
                    pictureBoxHinhAnh.Image = Image.FromFile(existingNhanVien.HinhAnh);
                }

                cmbGioiTinh.SelectedValue = existingNhanVien.GioiTinhID;
                cmbChucVu.SelectedValue = existingNhanVien.ChucVuID;
            }
            else
            {
                this.Text = "Thêm nhân viên mới";
            }
        }
        // Mở hộp thoại để chọn ảnh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        // Lưu thông tin nhân viên khi người dùng nhấn "Lưu"
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string hinhAnhPath = pictureBoxHinhAnh.Image != null ? pictureBoxHinhAnh.ImageLocation : null;

                    if (isUpdate && existingNhanVien != null)
                    {
                        existingNhanVien.HoTen = txtHoTen.Text;
                        existingNhanVien.Email = txtEmail.Text;
                        existingNhanVien.SoDienThoai = txtSoDienThoai.Text;
                        existingNhanVien.DiaChi = txtDiaChi.Text;
                        existingNhanVien.NgaySinh = dtpNgaySinh.Value;
                        existingNhanVien.GioiTinhID = (int)cmbGioiTinh.SelectedValue;
                        existingNhanVien.ChucVuID = (int)cmbChucVu.SelectedValue;
                        existingNhanVien.HinhAnh = hinhAnhPath;

                        _context.SaveChanges();
                        MessageBox.Show("Cập nhật nhân viên thành công!");
                    }
                    else
                    {
                        var newNhanVien = new NhanVien
                        {
                            HoTen = txtHoTen.Text,
                            Email = txtEmail.Text,
                            SoDienThoai = txtSoDienThoai.Text,
                            DiaChi = txtDiaChi.Text,
                            NgaySinh = dtpNgaySinh.Value,
                            GioiTinhID = (int)cmbGioiTinh.SelectedValue,
                            ChucVuID = (int)cmbChucVu.SelectedValue,
                            HinhAnh = hinhAnhPath
                        };

                        _context.NhanVien.Add(newNhanVien);
                        _context.SaveChanges();
                        MessageBox.Show("Thêm nhân viên mới thành công!");
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        // Kiểm tra tính hợp lệ của các trường trong form
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text) || !Regex.IsMatch(txtSoDienThoai.Text, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return false;
            }

            if (cmbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }
            if (cmbChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            return true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
