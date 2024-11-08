using Garage.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Garage.Common.Utils.Security
{
    public class PasswordHashUpdater
    {
        private readonly GaraOtoDbContext _context;

        public PasswordHashUpdater(GaraOtoDbContext context)
        {
            _context = context;
        }

        public void UpdatePasswordHashes()
        {
            // Lấy tất cả admin trước, sau đó filter trong memory
            var admins = _context.Admin.ToList();

            // Lọc ra những admin cần update mật khẩu
            var adminsToUpdate = admins.Where(admin => !IsPasswordHashed(admin.MatKhau)).ToList();

            foreach (var admin in adminsToUpdate)
            {
                // Chỉ băm mật khẩu của những admin chưa được băm
                admin.MatKhau = PasswordHelper.HashPassword(admin.MatKhau);
            }

            // Chỉ lưu khi có thay đổi
            if (adminsToUpdate.Any())
            {
                _context.SaveChanges();
            }
        }

        private bool IsPasswordHashed(string password)
        {
            // Kiểm tra mật khẩu đã được băm chưa
            // Điều chỉnh logic này dựa trên định dạng hash của bạn
            return password.Length > 10;       // Độ dài chuẩn của BCrypt hash
        }
    }
}