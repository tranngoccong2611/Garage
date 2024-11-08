using Garage.Common.Utils.Security;
using Garage.Data;
using Garage.Forms;
using Garage.Forms.MainForm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Garage
{
    public partial class Login : Form
    {
        private readonly GaraOtoDbContext _context;
        private readonly IServiceScopeFactory _scopeFactory;

        public Login(GaraOtoDbContext context, IServiceScopeFactory scopeFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
            InitializeComponent();
        }


        private void UserSign_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameTbl.Text.Trim();
                string password = PasswordTbl.Text.Trim();  // Người dùng nhập "123456"

                var admin = _context.Admin.FirstOrDefault(a => a.TenTaiKhoan == username);
                if (admin == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Debug: In ra các giá trị hash để kiểm tra
                string inputHash = PasswordHelper.HashPassword(password);
           

                if (PasswordHelper.VerifyPassword(password, admin.MatKhau))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    // Mở form mới
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dashBoard = scope.ServiceProvider.GetRequiredService<DashBoard>();
                        dashBoard.Show();
                    }
                }
                else
                {
                    MessageBox.Show("pass:",admin.MatKhau);

                    MessageBox.Show("passSql:", password);
                    MessageBox.Show("Sai mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đăng nhập admin chưa được implement.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
