using System;
using System.Security.Cryptography;
using System.Text;

namespace Garage.Common.Utils.Security
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                // Chuyển hash thành chuỗi hex uppercase
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
