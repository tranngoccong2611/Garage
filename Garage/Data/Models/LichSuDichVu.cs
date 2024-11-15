using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class LichSuDichVu
    {
        public int LichSuDichVuID { get; set; }
        public int? DonBaoDuongID { get; set; }
        public int? NhanVienID { get; set; }
        public int? DichVuID { get; set; }
        public string GhiChu { get; set; }

        public virtual DSDonBaoDuongXe DonBaoDuong { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}
