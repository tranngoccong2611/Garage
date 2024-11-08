using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class XeOTo
    {
        public int XeID { get; set; }
        public int? NguoiDungID { get; set; }
        public string BienSoXe { get; set; }
        public string HangXe { get; set; }
        public string Model { get; set; }
        public short? NamSanXuat { get; set; }
        public string MauSac { get; set; }
        public string HinhAnh { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
