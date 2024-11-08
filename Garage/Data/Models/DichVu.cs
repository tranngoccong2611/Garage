using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class DichVu
    {
        public int DichVuID { get; set; }
        public required string TenDichVu { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
    }

}
