using Garage.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class DatLichBaoDuongXe
    {
        public int DatLichBaoDuongID { get; set; }
        public int? NguoiDungID { get; set; }
        public int? XeID { get; set; }
        public DateTime NgayDatLich { get; set; }
        public TimeSpan ThoiGianDatLich { get; set; }
        public string TrangThai { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual XeOTo XeOTo { get; set; }
    }
}
