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
        private bool isUpdate = false;
        private int _existingNhanVienID;
        private GaraOtoDbContext _context;
        private NhanVien user;
        // Constructor nhận các tham số từ DI
        public AddNhanVien(GaraOtoDbContext context, int existingNhanVienId = 0)
        {
            InitializeComponent();
            _context = context;
            _existingNhanVienID = existingNhanVienId;

       
            if (existingNhanVienId != 0)
            {
                isUpdate = true;
            }
            if (isUpdate)
            {
                user = _context.NhanVien.Where(u => u.NhanVienID == existingNhanVienId).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần cập nhật.");
                    return;
                }
                // Cập nhật dữ liệu nhân viên nếu là chế độ cập nhật
                this.Text = "Cập nhật thông tin nhân viên";
                // Đổ dữ liệu của nhân viên vào các TextBox
                txtHoTen.Text = user.HoTen;
                txtEmail.Text = user.Email;
                txtSoDienThoai.Text = user.SoDienThoai;
                txtDiaChi.Text = user.DiaChi;

                if (user.NgaySinh.HasValue)
                {
                    dtpNgaySinh.Value = user.NgaySinh.Value.Date;
                }

                if (!string.IsNullOrEmpty(user.HinhAnh) && System.IO.File.Exists(user.HinhAnh))
                {
                    pictureBoxHinhAnh.Image = Image.FromFile(user.HinhAnh);
                }
                else
                {
                    pictureBoxHinhAnh.Image = Properties.Resources.logo; // Ảnh mặc định từ tài nguyên
                }

            }
            else
            {
                this.Text = "Thêm nhân viên mới";
            }
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của hình ảnh được chọn
                    string imagePath = openFileDialog.FileName;

                    // Đường dẫn thư mục Images trong Resources
                    string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images");

                    // Kiểm tra nếu thư mục chưa tồn tại thì tạo mới
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Lấy tên tệp hình ảnh (tên file, không bao gồm đường dẫn)
                    string fileName = Path.GetFileName(imagePath);

                    // Tạo đường dẫn mới để lưu hình ảnh
                    string newFilePath = Path.Combine(directoryPath, fileName);

                    // Sao chép hình ảnh vào thư mục mới
                    File.Copy(imagePath, newFilePath, true);

                    // Hiển thị hình ảnh lên PictureBox
                    pictureBoxHinhAnh.Image = Image.FromFile(newFilePath);

                    // Lưu đường dẫn vào cơ sở dữ liệu (Ví dụ: lưu đường dẫn vào thuộc tính HinhAnh của NhanVien)
                    user.HinhAnh = $"Resources/Images/{fileName}"; // Lưu đường dẫn tương đối vào cơ sở dữ liệu
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
                    string hinhAnhPath = pictureBoxHinhAnh.Image != null ? user.HinhAnh : "default.jpg";

                    if (isUpdate)
                    {
                        user.HoTen = txtHoTen.Text;
                        user.Email = txtEmail.Text;
                        user.SoDienThoai = txtSoDienThoai.Text;
                        user.DiaChi = txtDiaChi.Text;
                        user.NgaySinh = dtpNgaySinh.Value;
                        user.GioiTinhID = (int)cmbGioiTinh.SelectedValue;
                        user.ChucVuID = (int)cmbChucVu.SelectedValue;
                        user.HinhAnh = hinhAnhPath;

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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
