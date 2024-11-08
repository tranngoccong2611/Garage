using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class HoaDonLinhKien
    {
        public int HoaDonLinhKienID { get; set; }
        public int? HoaDonID { get; set; }
        public int? LinhKienID { get; set; }
        public int SoLuong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual LinhKien LinhKien { get; set; }
    }
}
