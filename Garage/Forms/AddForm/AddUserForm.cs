using Garage.Data;
using Garage.Data.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Garage.Forms.AddForm
{
    public partial class AddCustomerForm : Form
    {
        private readonly GaraOtoDbContext _context;

        private TextBox txtHoTen, txtSoDienThoai, txtEmail, txtDiaChi, txtHinhAnh;
        private ComboBox cmbGioiTinh, cmbChucVu;
        private DateTimePicker dtpNgaySinh;
        private Button btnSave;
        private NguoiDung user;
        private int _idUser;
        private bool isUpdate;
        public AddCustomerForm(GaraOtoDbContext context, int? idNguoiDung)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeFormComponents();
            isUpdate = idNguoiDung != null;
            _idUser = idNguoiDung ?? 0;

        }

        public NguoiDung getUser(int? id)
        {
            var user = _context.NguoiDung.FirstOrDefault(u => u.NguoiDungID == id);
            return user;
        }


        private void InitializeFormComponents()
        {
            this.Text = isUpdate ? "Cập nhập người dùng" : "Thêm người dùng mới";
            this.Size = new Size(400, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            user = getUser(_idUser);

            AddFormLabelsAndFields();
            AddSaveButton();
        }

        private void AddFormLabelsAndFields()
        {
            var lblHoTen = CreateLabel("Họ Tên:", new Point(20, 20));
            txtHoTen = CreateTextBox("txtHoTen", new Point(150, 20), 200);
            lblHoTen.Text = isUpdate ? user.HoTen : "";
            var lblGioiTinh = CreateLabel("Giới Tính:", new Point(20, 60));
            cmbGioiTinh = CreateComboBox("cmbGioiTinh", new Point(150, 60), 200);
            cmbGioiTinh.DataSource = _context.GioiTinh.ToList();
            cmbGioiTinh.DisplayMember = "TenGioiTinh";
            cmbGioiTinh.ValueMember = "GioiTinhID";

            var lblNgaySinh = CreateLabel("Ngày Sinh:", new Point(20, 100));
            dtpNgaySinh = new DateTimePicker { Name = "dtpNgaySinh", Location = new Point(150, 100), Width = 200 };

            var lblSoDienThoai = CreateLabel("Số Điện Thoại:", new Point(20, 140));
            txtSoDienThoai = CreateTextBox("txtSoDienThoai", new Point(150, 140), 200);

            var lblEmail = CreateLabel("Email:", new Point(20, 180));
            txtEmail = CreateTextBox("txtEmail", new Point(150, 180), 200);

            var lblChucVu = CreateLabel("Chức Vụ:", new Point(20, 220));
            cmbChucVu = CreateComboBox("cmbChucVu", new Point(150, 220), 200);
            cmbChucVu.DataSource = _context.ChucVu.ToList();
            cmbChucVu.DisplayMember = "TenChucVu";
            cmbChucVu.ValueMember = "ChucVuID";

            var lblDiaChi = CreateLabel("Địa Chỉ:", new Point(20, 260));
            txtDiaChi = CreateTextBox("txtDiaChi", new Point(150, 260), 200);

            var lblHinhAnh = CreateLabel("Hình Ảnh:", new Point(20, 300));
            txtHinhAnh = CreateTextBox("txtHinhAnh", new Point(150, 300), 200);

            this.Controls.AddRange(new Control[]
            {
                lblHoTen, txtHoTen, lblGioiTinh, cmbGioiTinh, lblNgaySinh, dtpNgaySinh,
                lblSoDienThoai, txtSoDienThoai, lblEmail, txtEmail, lblChucVu, cmbChucVu,
                lblDiaChi, txtDiaChi, lblHinhAnh, txtHinhAnh
            });
        }

        private void AddSaveButton()
        {
            btnSave = new Button { Text = "Lưu", Location = new Point(150, 340), Width = 100 };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private Label CreateLabel(string text, Point location)
        {
            return new Label { Text = text, Location = location };
        }

        private TextBox CreateTextBox(string name, Point location, int width)
        {
            return new TextBox { Name = name, Location = location, Width = width };
        }

        private ComboBox CreateComboBox(string name, Point location, int width)
        {
            return new ComboBox { Name = name, Location = location, Width = width };
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                // chạy câu lệnh cập nhập dữ liệu 
            }
            // chạy câu lưu thêm người dùng và lưu cơ sở dữ liệu
            if (ValidateForm())
            {
                try
                {
                    var nhanVien = new NhanVien
                    {
                        HoTen = txtHoTen.Text,
                        GioiTinhID = (int)cmbGioiTinh.SelectedValue,
                        NgaySinh = dtpNgaySinh.Value,
                        SoDienThoai = txtSoDienThoai.Text,
                        Email = txtEmail.Text,
                        ChucVuID = (int)cmbChucVu.SelectedValue,
                        DiaChi = txtDiaChi.Text,
                        HinhAnh = txtHinhAnh.Text
                    };

                    _context.NhanVien.Add(nhanVien);
                    _context.SaveChanges();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // AddCustomerForm
            // 
            ClientSize = new Size(887, 573);
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddCustomerForm";
            Load += AddCustomerForm_Load;
            ResumeLayout(false);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || !Regex.IsMatch(txtHoTen.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Họ tên không được để trống và chỉ chứa chữ cái.");
                return false;
            }

            if (cmbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }

            if (!Regex.IsMatch(txtSoDienThoai.Text, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải từ 10-11 chữ số.");
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            if (cmbChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.");
                return false;
            }

            return true;
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
