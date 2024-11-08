using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class HoaDon
    {
        public int HoaDonID { get; set; }
        public int? NguoiDungID { get; set; }
        public DateTime? NgayGiaoDich { get; set; }
        public decimal SoTien { get; set; }
        public string LoaiGiaoDich { get; set; }
        public string GhiChu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
