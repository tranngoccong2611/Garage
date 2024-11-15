using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class CustomerInteraction
{
    public string nameUser { get; set; }
    public string Call { get; set; }
    public DateTime date { get; set; }
    public string nameStaff { get; set; }
    public string Role { get; set; }
    public string note { get; set; }

}
public class HistoryServices : CustomerInteraction
{

    public string brand { get; set; }
    public string model { get; set; }
    public string LicensePlate { get; set; }
}
    
namespace Garage.Forms.MainForm.Dictionary
{
    public class ServiceCustomer
    {
        private readonly GaraOtoDbContext _db;
        public ServiceCustomer(GaraOtoDbContext context) {
            _db = context;
        }
        public List<CustomerInteraction> ListCustomerInteraction() {
            List<CustomerInteraction> ListCustomerInteraction = _db.CSKH.Join(_db.NguoiDung, cskh => cskh.NguoiDungID, u => u.NguoiDungID, (cskh, u) => new
            {
                cskh.NhanVienID,
                cskh.PhuongThucLienHe,
                cskh.NoiDungTraoDoi,
                userName=u.HoTen,
                cskh.NgayChamSoc
            }).Join(_db.NhanVien, temp => temp.NhanVienID, nv => nv.NhanVienID, (temp, nv) =>
            new
            {
                temp.PhuongThucLienHe,
                temp.NoiDungTraoDoi,
               temp.userName,
                temp.NgayChamSoc,
              
                nv.ChucVuID,
                nv.HoTen,
            }).Join(_db.ChucVu, t => t.ChucVuID, cv => cv.ChucVuID, (t, cv) => new
            CustomerInteraction { 
                Call=t.PhuongThucLienHe,
                note=t.NoiDungTraoDoi,
                nameUser=t.userName,
                nameStaff=t.HoTen,
                Role=cv.TenChucVu,
                date=t.NgayChamSoc??new DateTime(2023,1,1),
            }
          
            ).ToList();
            return ListCustomerInteraction;        
        }
        public List<HistoryServices> ListHistoryServices()
        {

            List<HistoryServices> lists = _db.LichSuDichVu.Join(_db.DSDonBaoDuongXe, ls => ls.DonBaoDuongID, ds => ds.DonBaoDuongID
            ,
            (ls, ds) => new
            {
                ls.NhanVienID,
                ls.GhiChu,
                ls.DichVuID,
                ds.XeID,
                ds.NgayBaoDuong
            }

            ).Join(_db.XeOTo, temp => temp.XeID, c => c.XeID, (temp, c) => new
            {
                temp.NhanVienID,
                temp.GhiChu,
                temp.DichVuID,
                temp.NgayBaoDuong,
                c.Model,
                c.HangXe,
                c.MauSac,
                c.BienSoXe,
                c.NguoiDungID
            }).Join(_db.NguoiDung, t => t.NguoiDungID, u => u.NguoiDungID, (t, u) => new
            {
                t.NhanVienID,
                t.GhiChu,
                t.DichVuID,
                t.NgayBaoDuong,
                t.Model,
                t.HangXe,
                t.MauSac,
                t.BienSoXe,
                UserName = u.HoTen,
                call = u.SoDienThoai
            }).Join(_db.NhanVien, p => p.NhanVienID, nv => nv.NhanVienID, (p, nv) => new
            {

                p.GhiChu,
                p.DichVuID,
                p.NgayBaoDuong,
                p.Model,
                p.HangXe,
                p.MauSac,
                p.BienSoXe,
                p.UserName,
                p.call,
                NameStaff = nv.HoTen,
                nv.ChucVuID,

            }).Join(_db.ChucVu, o => o.ChucVuID, cv => cv.ChucVuID, (o, cv) => new
            {
                o.GhiChu,
                o.DichVuID,
                o.NgayBaoDuong,
                o.Model,
                o.BienSoXe,
                o.HangXe,
                o.MauSac,
                o.UserName,
                o.NameStaff,
                o.call,
                cv.TenChucVu,
            }).Join(_db.DichVu, k => k.DichVuID, dv => dv.DichVuID, (k, dv) => new HistoryServices {
                nameStaff=k.NameStaff,
                nameUser=k.UserName,
                date=k.NgayBaoDuong?? new DateTime(2023,1,1),
                Call=k.call,
                brand=k.HangXe,
                model=k.Model,
                note=k.GhiChu,
                Role=k.TenChucVu,
                LicensePlate=k.BienSoXe,

            
            }).ToList();
            return lists;
        }
    }
}
