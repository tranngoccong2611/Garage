using DocumentFormat.OpenXml.Drawing.Diagrams;
using Garage.Data;
using Garage.Data.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class IUnresolveIssue
{
    public int DonBaoDuongId { get; set; }
    public int XeId { get; set; }
    public DateTime NgayBaoDuong { get; set; }
    public TimeSpan ThoiGianBaoDuong { get; set; }
    public string MucTieu { get; set; }
    public string VanDe { get; set; }
    public bool TrangThaiDaGiaiQuyet { get; set; }
    public string GhiChu { get; set; }
    public int DichVuId { get; set; }
    public int NhanVienID { get; set; }
    public string HoTenNhanVien { get; set; }
    public string ChucVu { get; set; }
    public int ChucVuId { get;  set; }
}
public class IResolveIssue : IUnresolveIssue
{
    public string HangXe { get; set; }
    public string MoHinhXe { get; set; }
    public string BienXe { get; set; }
    public int IDUser { get; set; }
    public string TenUser { get; set; }
    public string DiaChi { get; set; }
    public string Sdt { get; set; }
}


namespace Garage.Forms.MainForm.Dictionary
{
    public class RepairTrackerUtils
    {
        private readonly GaraOtoDbContext _db;

   
      
        public RepairTrackerUtils(GaraOtoDbContext db) {
            _db = db;

        }
        public List<IResolveIssue> getRepairListResolveByPhone(string call)
        {
            // First query: Get user's cars based on phone number
            var userCars = _db.NguoiDung
                .Where(u => u.SoDienThoai == call)
                .Join(
                    _db.XeOTo,
                    user => user.NguoiDungID,
                    car => car.NguoiDungID,
                    (user, car) => new {
                        UserId = user.NguoiDungID,
                        TenKhachHang = user.HoTen,
                        DiaChi = user.DiaChi,
                        SoDienThoai = user.SoDienThoai,
                        XeId = car.XeID,
                        HangXe = car.HangXe,
                        Model = car.Model,
                        BienSoXe = car.BienSoXe
                    }
                )
                .ToList(); 




            var ListResolve = _db.TheoDoiBaoDuong
                .Where(td => td.DaGiaiQuyet == true)
                .Join(
                    _db.DSDonBaoDuongXe,
                    td => td.DonBaoDuongID,
                    ds => ds.DonBaoDuongID,
                    (td, ds) => new { td, ds }
                )
                .Join(
                    _db.LichSuDichVu,
                    tmp => tmp.ds.DonBaoDuongID,
                    lsdv => lsdv.DonBaoDuongID,
                    (tmp, lsdv) => new { tmp, lsdv }
                )
                .Join(
                    _db.NhanVien,
                    t => t.lsdv.NhanVienID,
                    nv => nv.NhanVienID,
                    (t, nv) => new { t, nv }
                ).Join(_db.ChucVu,
                    tm => tm.nv.ChucVuID,
                    cv => cv.ChucVuID,
                    (tm, cv) => new { tm, cv })
                .Join(_db.XeOTo, p => p.tm.t.tmp.ds.XeID, c => c.XeID, (p, c) => new { p, c })
                .Join(_db.NguoiDung, o => o.c.NguoiDungID, u => u.NguoiDungID, (o, u) => new { o, u })
                .Select(temp => new IResolveIssue
                {
                    DonBaoDuongId = temp.o.p.tm.t.tmp.td.DonBaoDuongID ?? 1,
                    XeId = temp.o.p.tm.t.tmp.ds.XeID ?? 1,
                    NgayBaoDuong = temp.o.p.tm.t.tmp.ds.NgayBaoDuong ?? new DateTime(2023, 1, 1),
                    ThoiGianBaoDuong = temp.o.p.tm.t.tmp.ds.ThoiGianBaoDuong ?? new TimeSpan(9, 0, 0),
                    MucTieu = temp.o.p.tm.t.tmp.ds.MucTieuBaoDuong ?? "",
                    VanDe = temp.o.p.tm.t.tmp.td.VanDe,
                    TrangThaiDaGiaiQuyet = temp.o.p.tm.t.tmp.td.DaGiaiQuyet ?? false,
                    GhiChu = temp.o.p.tm.t.lsdv.GhiChu ?? "",
                    DichVuId = temp.o.p.tm.t.lsdv.DichVuID ?? 1,
                    NhanVienID = temp.o.p.tm.t.lsdv.NhanVienID ?? 1,
                    HoTenNhanVien = temp.o.p.tm.nv.HoTen ?? "",
                    ChucVu = temp.o.p.cv.TenChucVu,
                    ChucVuId = temp.o.p.cv.ChucVuID,
                    BienXe = temp.o.c.BienSoXe,
                    HangXe = temp.o.c.HangXe,
                    MoHinhXe = temp.o.c.Model,
                    IDUser = temp.u.NguoiDungID,
                    TenUser = temp.u.HoTen,
                    DiaChi = temp.u.DiaChi,
                    Sdt = temp.u.SoDienThoai,
                })
                .GroupBy(x => x.DonBaoDuongId) // hoặc nhóm theo các thuộc tính khác
                .Select(g => g.First()) // Lấy phần tử đầu tiên trong mỗi nhóm
                .ToList();
       
            List<IResolveIssue> lists = new List<IResolveIssue>();
            foreach (var userCar in userCars)
            {
                lists.AddRange(ListResolve.Where(i => i.XeId == userCar.XeId));
            }
            return lists;
        }



        public List<IResolveIssue> getRepairListUnResolveByPhone(string call)
        {
            var userCars = _db.NguoiDung
                 .Where(u => u.SoDienThoai == call)
                 .Join(
                     _db.XeOTo,
                     user => user.NguoiDungID,
                     car => car.NguoiDungID,
                     (user, car) => new {
                         UserId = user.NguoiDungID,
                         TenKhachHang = user.HoTen,
                         DiaChi = user.DiaChi,
                         SoDienThoai = user.SoDienThoai,
                         XeId = car.XeID,
                         HangXe = car.HangXe,
                         Model = car.Model,
                         BienSoXe = car.BienSoXe
                     }
                 )
                 .ToList();
            var ListUnResolve = _db.TheoDoiBaoDuong
               .Where(td => td.DaGiaiQuyet == false)
               .Join(
                   _db.DSDonBaoDuongXe,
                   td => td.DonBaoDuongID,
                   ds => ds.DonBaoDuongID,
                   (td, ds) => new { td, ds }
               )
               .Join(
                   _db.LichSuDichVu,
                   tmp => tmp.ds.DonBaoDuongID,
                   lsdv => lsdv.DonBaoDuongID,
                   (tmp, lsdv) => new { tmp, lsdv }
               )
               .Join(
                   _db.NhanVien,
                   t => t.lsdv.NhanVienID,
                   nv => nv.NhanVienID,
                   (t, nv) => new { t, nv }
               ).Join(_db.ChucVu,
                   tm => tm.nv.ChucVuID,
                   cv => cv.ChucVuID,
                   (tm, cv) => new { tm, cv })
               .Join(_db.XeOTo, p => p.tm.t.tmp.ds.XeID, c => c.XeID, (p, c) => new { p, c })
               .Join(_db.NguoiDung, o => o.c.NguoiDungID, u => u.NguoiDungID, (o, u) => new { o, u })
               .Select(temp => new IResolveIssue
               {
                   DonBaoDuongId = temp.o.p.tm.t.tmp.td.DonBaoDuongID ?? 1,
                   XeId = temp.o.p.tm.t.tmp.ds.XeID ?? 1,
                   NgayBaoDuong = temp.o.p.tm.t.tmp.ds.NgayBaoDuong ?? new DateTime(2023, 1, 1),
                   ThoiGianBaoDuong = temp.o.p.tm.t.tmp.ds.ThoiGianBaoDuong ?? new TimeSpan(9, 0, 0),
                   MucTieu = temp.o.p.tm.t.tmp.ds.MucTieuBaoDuong ?? "",
                   VanDe = temp.o.p.tm.t.tmp.td.VanDe,
                   TrangThaiDaGiaiQuyet = temp.o.p.tm.t.tmp.td.DaGiaiQuyet ?? false,
                   GhiChu = temp.o.p.tm.t.lsdv.GhiChu ?? "",
                   DichVuId = temp.o.p.tm.t.lsdv.DichVuID ?? 1,
                   NhanVienID = temp.o.p.tm.t.lsdv.NhanVienID ?? 1,
                   HoTenNhanVien = temp.o.p.tm.nv.HoTen ?? "",
                   ChucVu = temp.o.p.cv.TenChucVu,
                   ChucVuId = temp.o.p.cv.ChucVuID,
                   BienXe = temp.o.c.BienSoXe,
                   HangXe = temp.o.c.HangXe,
                   MoHinhXe = temp.o.c.Model,
                   IDUser = temp.u.NguoiDungID,
                   TenUser = temp.u.HoTen,
                   DiaChi = temp.u.DiaChi,
                   Sdt = temp.u.SoDienThoai,
               })
               .GroupBy(x => x.DonBaoDuongId) // hoặc nhóm theo các thuộc tính khác
               .Select(g => g.First()) // Lấy phần tử đầu tiên trong mỗi nhóm
               .ToList();
            List<IResolveIssue> lists = new List<IResolveIssue>();
            foreach (var userCar in userCars)
            {
                lists.AddRange(ListUnResolve.Where(i => i.XeId == userCar.XeId));
            }
            return lists;

        }
        public List<IResolveIssue> getRepairListUnResolve()
        {
            // First query: Get user's cars based on phone number
            

            var ListUnResolve = _db.TheoDoiBaoDuong
                .Where(td => td.DaGiaiQuyet == false)
                .Join(
                    _db.DSDonBaoDuongXe,
                    td => td.DonBaoDuongID,
                    ds => ds.DonBaoDuongID,
                    (td, ds) => new { td, ds }
                )
                .Join(
                    _db.LichSuDichVu,
                    tmp => tmp.ds.DonBaoDuongID,
                    lsdv => lsdv.DonBaoDuongID,
                    (tmp, lsdv) => new { tmp, lsdv }
                )
                .Join(
                    _db.NhanVien,
                    t => t.lsdv.NhanVienID,
                    nv => nv.NhanVienID,
                    (t, nv) => new { t, nv }
                ).Join(_db.ChucVu,
                    tm => tm.nv.ChucVuID,
                    cv => cv.ChucVuID,
                    (tm, cv) => new { tm, cv })
                .Join(_db.XeOTo, p => p.tm.t.tmp.ds.XeID, c => c.XeID, (p, c) => new { p, c })
                .Join(_db.NguoiDung, o => o.c.NguoiDungID, u => u.NguoiDungID, (o, u) => new { o, u })
                .Select(temp => new IResolveIssue
                {
                    DonBaoDuongId = temp.o.p.tm.t.tmp.td.DonBaoDuongID ?? 1,
                    XeId = temp.o.p.tm.t.tmp.ds.XeID ?? 1,
                    NgayBaoDuong = temp.o.p.tm.t.tmp.ds.NgayBaoDuong ?? new DateTime(2023, 1, 1),
                    ThoiGianBaoDuong = temp.o.p.tm.t.tmp.ds.ThoiGianBaoDuong ?? new TimeSpan(9, 0, 0),
                    MucTieu = temp.o.p.tm.t.tmp.ds.MucTieuBaoDuong ?? "",
                    VanDe = temp.o.p.tm.t.tmp.td.VanDe,
                    TrangThaiDaGiaiQuyet = temp.o.p.tm.t.tmp.td.DaGiaiQuyet ?? false,
                    GhiChu = temp.o.p.tm.t.lsdv.GhiChu ?? "",
                    DichVuId = temp.o.p.tm.t.lsdv.DichVuID ?? 1,
                    NhanVienID = temp.o.p.tm.t.lsdv.NhanVienID ?? 1,
                    HoTenNhanVien = temp.o.p.tm.nv.HoTen ?? "",
                    ChucVu = temp.o.p.cv.TenChucVu,
                    ChucVuId = temp.o.p.cv.ChucVuID,
                    BienXe = temp.o.c.BienSoXe,
                    HangXe = temp.o.c.HangXe,
                    MoHinhXe = temp.o.c.Model,
                    IDUser = temp.u.NguoiDungID,
                    TenUser = temp.u.HoTen,
                    DiaChi = temp.u.DiaChi,
                    Sdt = temp.u.SoDienThoai,
                })
                .GroupBy(x => x.DonBaoDuongId) // hoặc nhóm theo các thuộc tính khác
                .Select(g => g.First()) // Lấy phần tử đầu tiên trong mỗi nhóm
                .ToList();
            return ListUnResolve;
           
        }
        public List<IResolveIssue> getRepairTrackerListResolve()
        {
            var ListResolve = _db.TheoDoiBaoDuong
                .Where(td => td.DaGiaiQuyet == true)
                .Join(
                    _db.DSDonBaoDuongXe,
                    td => td.DonBaoDuongID,
                    ds => ds.DonBaoDuongID,
                    (td, ds) => new { td, ds }
                )
                .Join(
                    _db.LichSuDichVu,
                    tmp => tmp.ds.DonBaoDuongID,
                    lsdv => lsdv.DonBaoDuongID,
                    (tmp, lsdv) => new { tmp, lsdv }
                )
                .Join(
                    _db.NhanVien,
                    t => t.lsdv.NhanVienID,
                    nv => nv.NhanVienID,
                    (t, nv) => new { t, nv }
                ).Join(_db.ChucVu,
                    tm => tm.nv.ChucVuID,
                    cv => cv.ChucVuID,
                    (tm, cv) => new { tm, cv })
                .Join(_db.XeOTo, p => p.tm.t.tmp.ds.XeID, c => c.XeID, (p, c) => new { p, c })
                .Join(_db.NguoiDung, o => o.c.NguoiDungID, u => u.NguoiDungID, (o, u) => new { o, u })
                .Select(temp => new IResolveIssue
                {
                    DonBaoDuongId = temp.o.p.tm.t.tmp.td.DonBaoDuongID ?? 1,
                    XeId = temp.o.p.tm.t.tmp.ds.XeID ?? 1,
                    NgayBaoDuong = temp.o.p.tm.t.tmp.ds.NgayBaoDuong ?? new DateTime(2023, 1, 1),
                    ThoiGianBaoDuong = temp.o.p.tm.t.tmp.ds.ThoiGianBaoDuong ?? new TimeSpan(9, 0, 0),
                    MucTieu = temp.o.p.tm.t.tmp.ds.MucTieuBaoDuong ?? "",
                    VanDe = temp.o.p.tm.t.tmp.td.VanDe,
                    TrangThaiDaGiaiQuyet = temp.o.p.tm.t.tmp.td.DaGiaiQuyet ?? false,
                    GhiChu = temp.o.p.tm.t.lsdv.GhiChu ?? "",
                    DichVuId = temp.o.p.tm.t.lsdv.DichVuID ?? 1,
                    NhanVienID = temp.o.p.tm.t.lsdv.NhanVienID ?? 1,
                    HoTenNhanVien = temp.o.p.tm.nv.HoTen ?? "",
                    ChucVu = temp.o.p.cv.TenChucVu,
                    ChucVuId = temp.o.p.cv.ChucVuID,
                    BienXe = temp.o.c.BienSoXe,
                    HangXe = temp.o.c.HangXe,
                    MoHinhXe = temp.o.c.Model,
                    IDUser = temp.u.NguoiDungID,
                    TenUser = temp.u.HoTen,
                    DiaChi = temp.u.DiaChi,
                    Sdt = temp.u.SoDienThoai,
                })
                .GroupBy(x => x.DonBaoDuongId) // hoặc nhóm theo các thuộc tính khác
                .Select(g => g.First()) // Lấy phần tử đầu tiên trong mỗi nhóm
                .ToList();

            return ListResolve;
        }

    }
}
