using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class LinhKien
    {
   
        public int LinhKienID { get; set; }
    
        public  string TenLinhKien { get; set; }
     
        public int SoLuong { get; set; }
     
        public decimal Gia { get; set; }
     
        public  string MoTa { get; set; }
     
        public  string HinhAnh { get; set; }
    }
}
