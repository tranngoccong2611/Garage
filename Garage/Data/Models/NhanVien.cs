using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Data.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        public int? GioiTinhID { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int? ChucVuID { get; set; }
        public string DiaChi { get; set; }
        public string HinhAnh { get; set; }
        public DateTime NgayVaoLam { get; set; } = new DateTime(2023, 1, 1);
        public DateTime? NgayNghi { get; set; }  // Cần thay đổi thành nullable

        public virtual GioiTinh GioiTinh { get; set; }
        public virtual ChucVu ChucVu { get; set; }
    }
}