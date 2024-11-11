using Garage.Data.Models;
using Garage.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms
{
    public partial class AddLinhKien : Form
    {
        private bool isUpdate = false;
        private int _existingLinhKienID;
        private GaraOtoDbContext _context;
        private LinhKien linhKien;

        public AddLinhKien(GaraOtoDbContext context, int existingLinhKienId = 0)
        {
            InitializeComponent();
            _context = context;
            _existingLinhKienID = existingLinhKienId;

            if (existingLinhKienId != 0)
            {
                isUpdate = true;
            }
            if (isUpdate)
            {
                linhKien = _context.LinhKien.Where(lk => lk.LinhKienID == existingLinhKienId).FirstOrDefault();
                if (linhKien == null)
                {
                    MessageBox.Show("Không tìm thấy linh kiện cần cập nhật.");
                    return;
                }

                // Cập nhật dữ liệu linh kiện nếu là chế độ cập nhật
                this.Text = "Cập nhật thông tin linh kiện";

                // Đổ dữ liệu của linh kiện vào các TextBox
                txtLinhKienID.Text = linhKien.LinhKienID.ToString();
                txtTenLinhKien.Text = linhKien.TenLinhKien;
                txtSoLuong.Text = linhKien.SoLuong.ToString();
                txtGia.Text = linhKien.Gia.ToString();
                txtMoTa.Text = linhKien.MoTa;

                if (!string.IsNullOrEmpty(linhKien.HinhAnh))
                {
                    pictureBoxHinhAnh.Image = Image.FromFile(linhKien.HinhAnh); // Đặt ảnh linh kiện từ đường dẫn
                }
            }
            else
            {
                this.Text = "Thêm linh kiện mới";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string hinhAnhPath = pictureBoxHinhAnh.Image != null ? pictureBoxHinhAnh.ImageLocation : "default.jpg";

                    if (isUpdate)
                    {
                        linhKien.TenLinhKien = txtTenLinhKien.Text;
                        linhKien.SoLuong = int.Parse(txtSoLuong.Text);
                        linhKien.Gia = decimal.Parse(txtGia.Text);
                        linhKien.MoTa = txtMoTa.Text;
                        linhKien.HinhAnh = hinhAnhPath;

                        _context.SaveChanges();
                        MessageBox.Show("Cập nhật linh kiện thành công!");
                    }
                    else
                    {
                        var newLinhKien = new LinhKien
                        {
                            TenLinhKien = txtTenLinhKien.Text,
                            SoLuong = int.Parse(txtSoLuong.Text),
                            Gia = decimal.Parse(txtGia.Text),
                            MoTa = txtMoTa.Text,
                            HinhAnh = hinhAnhPath
                        };

                        _context.LinhKien.Add(newLinhKien);
                        _context.SaveChanges();
                        MessageBox.Show("Thêm linh kiện mới thành công!");
                        pictureBoxHinhAnh.Image = Image.FromFile("default.jpg"); // Đường dẫn tới ảnh mặc định
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
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
                    pictureBoxHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTenLinhKien.Text))
            {
                MessageBox.Show("Tên linh kiện không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text) || !decimal.TryParse(txtGia.Text, out _))
            {
                MessageBox.Show("Giá phải là một số hợp lệ.");
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
