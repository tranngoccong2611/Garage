using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Models
{
    public class CSKH
    {
        public int CSKHID { get; set; }
        public int? NguoiDungID { get; set; }
        public int? NhanVienID { get; set; }
        public DateTime? NgayChamSoc { get; set; }
        public string PhuongThucLienHe { get; set; }
        public string NoiDungTraoDoi { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
