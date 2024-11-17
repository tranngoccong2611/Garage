using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class Staff
{
    public string Image { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Phone { get; set; }
    public int Id { get; set; }
    public int RoleId   { get; set; }
    public DateTime JoinDate { get; set; }
    public string address { get; set; }
    public DateTime? OutDate { get; set; }  // Changed to nullable to match the model
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

        // Phương thức chung để lấy danh sách nhân viên theo trạng thái nghỉ việc
        private List<Staff> GetStaffListByStatus(bool isWorking)
        {
            var query = _db.NhanVien
                .Where(nv => isWorking ? nv.NgayNghi == null : nv.NgayNghi != null)
                .Join(
                    _db.ChucVu,
                    nv => nv.ChucVuID,
                    cv => cv.ChucVuID,
                    (nv, cv) => new Staff
                    {
                        Id = nv.NhanVienID,
                        Image = nv.HinhAnh ?? "defaultImagePath",
                        Name = nv.HoTen ?? "No Name",
                        Role = cv.TenChucVu ?? "No Role",
                        JoinDate = nv.NgayVaoLam,  // This has a default value in the model
                        OutDate = nv.NgayNghi,     // This is nullable
                        address = nv.DiaChi ?? string.Empty,
                        Phone = nv.SoDienThoai ?? "No Phone",
                        RoleId = cv.ChucVuID,
                    }
                );

            return query.ToList();
        }

        // Lấy danh sách nhân viên đang làm việc
        public List<Staff> GetStaffListWork()
        {
            return GetStaffListByStatus(true);
        }

        // Lấy danh sách nhân viên đã nghỉ việc
        public List<Staff> GetStaffListUnWork()
        {
            return GetStaffListByStatus(false);
        }

        // Lấy tất cả nhân viên
        public List<Staff> GetStaffListAll()
        {
            var query = _db.NhanVien
                .Join(
                    _db.ChucVu,
                    nv => nv.ChucVuID,
                    cv => cv.ChucVuID,
                    (nv, cv) => new Staff
                    {
                        Id = nv.NhanVienID,
                        Image = nv.HinhAnh ?? "defaultImagePath",
                        Name = nv.HoTen ?? "No Name",
                        Role = cv.TenChucVu ?? "No Role",
                        JoinDate = nv.NgayVaoLam,  // Has default value 2023-01-01
                        OutDate = nv.NgayNghi,     // Nullable DateTime
                        address = nv.DiaChi ?? string.Empty,
                        Phone = nv.SoDienThoai ?? "No Phone",
                        RoleId = cv.ChucVuID,
                    }
                );

            return query.ToList();
        }

        // Lấy danh sách chức vụ
        public List<ChucVu> GetListRole()
        {
            return _db.ChucVu.ToList();
        }
    }
}