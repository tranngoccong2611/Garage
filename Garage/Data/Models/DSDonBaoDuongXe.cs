using Garage.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class DSDonBaoDuongXe
    {
        public int DonBaoDuongID { get; set; }
        public int? XeID { get; set; }
        public DateTime? NgayBaoDuong { get; set; }
        public TimeSpan? ThoiGianBaoDuong { get; set; }
        public string MucTieuBaoDuong { get; set; }
        public string TrangThaiXe {get;set;}
        public virtual XeOTo XeOTo { get; set; }
    }
}
