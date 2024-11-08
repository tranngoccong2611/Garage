using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class TheoDoiBaoDuong
    {
        public int TheoDoiID { get; set; }
        public int? DonBaoDuongID { get; set; }
        public string VanDe { get; set; }
        public bool? DaGiaiQuyet { get; set; }
        public string CachGiaiQuyet { get; set; }

        public virtual DSDonBaoDuongXe DonBaoDuong { get; set; }
    }
}
