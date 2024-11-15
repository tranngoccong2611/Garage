using Garage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Staff
{
    public string Image { get; set; }
    public string Name { get; set; } 
    public string Role { get; set; }
    public DateTime JoinDate { get; set; }
    public string address { get; set; }
    public DateTime? OutDate { get; set; }
    public bool statusWork { get; set; }
}
namespace Garage.Forms.MainForm.Dictionary
{
    public class GetStaff
    {
        private readonly GaraOtoDbContext _db;



        public GetStaff(GaraOtoDbContext db)
        {
            _db = db;

        }
        public List<Staff> GetStaffListWork()
        {
            List<Staff> staffList = _db.NhanVien
                .Where(nv => nv.NgayNghiViec != null)
                .Join(_db.ChucVu, nv => nv.ChucVuID, cv => cv.ChucVuID, (nv, cv) => new Staff
                {
                    Image = nv.HinhAnh,
                    Name = nv.HoTen,
                    Role = cv.TenChucVu,
                    JoinDate = nv.NgayVaoLam,
                    OutDate = null, 
                    address = nv.DiaChi,
                    statusWork = true,
                })
                .ToList();

            return staffList;
        }
        public List<Staff> GetStaffListUnWork()
        {
            List<Staff> staffList = _db.NhanVien
                .Where(nv => nv.NgayNghiViec == null)
                .Join(_db.ChucVu, nv => nv.ChucVuID, cv => cv.ChucVuID, (nv, cv) => new Staff
                {
                    Image = nv.HinhAnh,
                    Name = nv.HoTen,
                    Role = cv.TenChucVu,
                    JoinDate = nv.NgayVaoLam,
                    OutDate = null,
                    address = nv.DiaChi,
                    statusWork = true,
                })
                .ToList();

            return staffList;
        }
        public List<Staff> GetStaffListAll()
        {
            List<Staff> staffList = _db.NhanVien
                .Join(_db.ChucVu, nv => nv.ChucVuID, cv => cv.ChucVuID, (nv, cv) => new Staff
                {
                    Image = nv.HinhAnh,
                    Name = nv.HoTen,
                    Role = cv.TenChucVu,
                    JoinDate = nv.NgayVaoLam,
                    OutDate = null,
                    address = nv.DiaChi,
                    statusWork = true,
                })
                .ToList();

            return staffList;
        }

    }
}
