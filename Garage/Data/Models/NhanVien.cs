using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
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

        public virtual GioiTinh GioiTinh { get; set; }
        public virtual ChucVu ChucVu { get; set; }
    }
}
