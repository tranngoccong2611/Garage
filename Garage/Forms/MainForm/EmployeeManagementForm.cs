using Garage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms.MainForm
{
    public partial class EmployeeManagementForm : Form
    {
        private readonly GaraOtoDbContext _context;
        private DataGridView employeeGrid;
        private TextBox searchBox;
        private ComboBox roleComboBox;
        private Panel contentPanel; // Main panel for adding controls

        public EmployeeManagementForm(GaraOtoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            InitializeComponents();
            LoadEmployeeData();
        }

        private void InitializeComponents()
        {
            // Initialize content panel
            contentPanel = new Panel { Dock = DockStyle.Fill };
            Controls.Add(contentPanel); // Add the content panel to the form

            // Search panel setup
            var toolPanel = new Panel { Dock = DockStyle.Top, Height = 60 };
            searchBox = new TextBox { PlaceholderText = "Tìm kiếm nhân viên...", Width = 200 };
            roleComboBox = new ComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            // Adding buttons
            var addButton = new Button { Text = "Thêm nhân viên", Width = 120 };
            addButton.Click += (s, e) => ShowAddEmployeeForm();
            var editButton = new Button { Text = "Sửa", Width = 100 };
            editButton.Click += (s, e) => ShowEditEmployeeForm();
            var deleteButton = new Button { Text = "Xóa", Width = 100, BackColor = Color.Red };
            deleteButton.Click += (s, e) => DeleteEmployee();

            // Layout for buttons
            var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 400 };
            buttonPanel.Controls.AddRange(new Control[] { searchBox, roleComboBox, addButton, editButton, deleteButton });
            toolPanel.Controls.Add(buttonPanel);

            // Employee Grid setup
            employeeGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            employeeGrid.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên nhân viên", DataPropertyName = "TenNhanVien", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Vai trò", DataPropertyName = "VaiTro", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Số điện thoại", DataPropertyName = "SoDienThoai", Width = 150 }
            });

            // Add panels to content panel
            contentPanel.Controls.Add(toolPanel);
            contentPanel.Controls.Add(employeeGrid);

            // Event bindings
            searchBox.TextChanged += (s, e) => FilterEmployees();
            roleComboBox.SelectedIndexChanged += (s, e) => FilterEmployees();
            LoadRoles();
        }

        private async void LoadRoles()
        {
            try
            {
                // Kiểm tra xem _context có được khởi tạo không
                if (_context == null)
                {
                    MessageBox.Show("Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra lại cấu hình.");
                    return;
                }

                // Fetch roles from the database asynchronously
                var roles = await _context.ChucVu
                    .Select(r => r.TenChucVu) // Đảm bảo rằng TenChucVu là thuộc tính chính xác
                    .ToListAsync();

                // Kiểm tra kết quả trả về
                if (roles == null || !roles.Any())
                {
                    MessageBox.Show("Không có dữ liệu vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Bind roles to the ComboBox
                roleComboBox.DataSource = null; // Đặt về null để tránh lỗi gán lại
                roleComboBox.DataSource = roles;
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết hơn nếu cần
                Console.WriteLine(ex);
                MessageBox.Show($"Lỗi khi tải vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadEmployeeData()
        {
            try
            {
                var employees = await _context.NhanVien
                    .Select(e => new { MaNhanVien = e.NhanVienID, TenNhanVien = e.HoTen, VaiTro = e.ChucVu.TenChucVu, SoDienThoai = e.SoDienThoai })
                    .ToListAsync();

                employeeGrid.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FilterEmployees()
        {
            try
            {
                var query = _context.NhanVien.AsQueryable();

                if (!string.IsNullOrEmpty(searchBox.Text))
                {
                    query = query.Where(e => e.HoTen.Contains(searchBox.Text));
                }

                if (roleComboBox.SelectedIndex > 0)
                {
                    var selectedRole = roleComboBox.SelectedItem.ToString();
                    query = query.Where(e => e.ChucVu.TenChucVu == selectedRole);
                }

                var filteredEmployees = await query
                    .Select(e => new { MaNhanVien = e.NhanVienID, TenNhanVien = e.HoTen, VaiTro = e.ChucVu.TenChucVu, SoDienThoai = e.SoDienThoai })
                    .ToListAsync();

                employeeGrid.DataSource = filteredEmployees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAddEmployeeForm() { /* Show form to add employee */ }
        private void ShowEditEmployeeForm() { /* Show form to edit employee */ }
        private void DeleteEmployee() { /* Logic to delete employee */ }

        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
