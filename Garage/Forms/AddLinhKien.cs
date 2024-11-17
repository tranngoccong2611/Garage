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
using Garage.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.EntityFrameworkCore;

namespace Garage.Forms
{
    public partial class AddLinhKien : Form
    {
        private bool isUpdate = false;

        private GaraOtoDbContext _context;
        private LinhKien linhKien;
        private int id;
        public AddLinhKien(GaraOtoDbContext context, int existingLinhKienId = 0)
        {
            _context = context;
            InitializeComponent();
            id = existingLinhKienId;


            try
            {
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

                    this.Text = "Cập nhật thông tin linh kiện";

                    // Đổ dữ liệu vào TextBox
                    txtLinhKienID.Text = linhKien.LinhKienID.ToString();
                    txtLinhKienID.ReadOnly = true;
                    txtTenLinhKien.Text = linhKien.TenLinhKien;
                    txtSoLuong.Text = linhKien.SoLuong.ToString();
                    txtGia.Text = linhKien.Gia.ToString();
                    txtMoTa.Text = linhKien.MoTa;


                    if (!string.IsNullOrEmpty(linhKien.HinhAnh) && File.Exists(linhKien.HinhAnh))
                    {
                        pictureBoxHinhAnh.Image = Image.FromFile(linhKien.HinhAnh);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(linhKien.HinhAnh) || !File.Exists(linhKien.HinhAnh))
                        {
                            pictureBoxHinhAnh.Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png"); // Thay bằng ảnh trong Resources
                        }
                    }


                }
                else
                {
                    this.Text = "Thêm linh kiện mới";
                    txtLinhKienID.Text = (countParts + 1).ToString();
                    txtLinhKienID.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}");
            }
            pictureBoxHinhAnh.Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png"); // Thay bằng ảnh trong Resources

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string hinhAnhPath = pictureBoxHinhAnh.ImageLocation;

                    if (string.IsNullOrEmpty(hinhAnhPath))
                    {
                        hinhAnhPath = "D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png";
                    }

                    if (isUpdate)
                    {
                        if (linhKien != null)
                        {
                            linhKien.TenLinhKien = txtTenLinhKien.Text;
                            linhKien.SoLuong = int.Parse(txtSoLuong.Text);
                            linhKien.Gia = decimal.Parse(txtGia.Text);
                            linhKien.MoTa = txtMoTa.Text;
                            linhKien.HinhAnh = hinhAnhPath;

                            _context.Entry(linhKien).State = EntityState.Modified;
                        }
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
                    }

                    // Đảm bảo changes được lưu vào database
                    _context.SaveChanges();

                    // Đợi một chút để đảm bảo database đã được cập nhật
                    Task.Delay(100).Wait();

                    this.DialogResult = DialogResult.OK;
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
                    pictureBoxHinhAnh.ImageLocation = openFileDialog.FileName; // Ghi nhớ đường dẫn
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

            // Sửa phần kiểm tra hình ảnh
            if (!isUpdate) // Nếu đang thêm mới
            {
                if (pictureBoxHinhAnh.Image == null)
                {
                    pictureBoxHinhAnh.Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png");
                }
            }
            else // Nếu đang cập nhật
            {
                if (linhKien != null && (string.IsNullOrEmpty(linhKien.HinhAnh) || !File.Exists(linhKien.HinhAnh)))
                {
                    pictureBoxHinhAnh.Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png");
                }
            }

            return true;
        }


        private void button4_Click(object sender, EventArgs e)

        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa linh kiện này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Tìm linh kiện cần xóa
                var linhKien = _context.LinhKien.Find(id);

                if (linhKien != null)
                {
                    // Xóa linh kiện
                    _context.LinhKien.Remove(linhKien);
                    _context.SaveChanges();

                    // Xóa hình ảnh nếu không phải là ảnh mặc định
                    string defaultImagePath = "D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png";
                    if (!string.IsNullOrEmpty(linhKien.HinhAnh) &&
                        File.Exists(linhKien.HinhAnh) &&
                        linhKien.HinhAnh != defaultImagePath)
                    {
                        try
                        {
                            File.Delete(linhKien.HinhAnh);
                        }
                        catch (Exception ex)
                        {
                            // Log lỗi xóa file nếu cần
                            Console.WriteLine($"Không thể xóa file ảnh: {ex.Message}");
                        }
                    }



                    MessageBox.Show("Xóa linh kiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy linh kiện cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
        };
           
        
    

