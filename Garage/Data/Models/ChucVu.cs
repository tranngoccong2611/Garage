using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class ChucVu
    {
        public int ChucVuID { get; set; }
        public required string TenChucVu { get; set; }
        public int MucLuong { get; set; }
    }
}
