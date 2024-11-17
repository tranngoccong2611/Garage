using DocumentFormat.OpenXml.VariantTypes;
using Garage.Common.Enum;
using Garage.Data;
using Garage.Data.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage.Forms.MainForm.Dictionary
{
    public class ListBooking
    {
        private readonly GaraOtoDbContext _db;



        public ListBooking(GaraOtoDbContext db)
        {
            _db = db;

        }
        public List<Bookcar> getListCarBookingInWeekyly()
        {
           
            DateTime today = DateTime.Today;
    

            // Xác định ngày trong tuần (1: Thứ 2, ..., 7: Chủ Nhật)
            int dayOfWeekNumber = today.DayOfWeek switch
            {
                DayOfWeek.Monday => 1,
                DayOfWeek.Tuesday => 2,
                DayOfWeek.Wednesday => 3,
                DayOfWeek.Thursday => 4,
                DayOfWeek.Friday => 5,
                DayOfWeek.Saturday => 6,
                DayOfWeek.Sunday => 7,
                _ => 0 // Trường hợp không hợp lệ
            };

            int dayNumber= dayOfWeekNumber == 0 ? 7 : dayOfWeekNumber;
            DateTime[] weekDays = new DateTime[7];
            HashSet<Position> usedPositions = new HashSet<Position>();
            for (int i = 0; i < 7; i++)
            {
                // Tính số ngày còn lại trong tuần (theo thứ Hai đến Chủ Nhật)
                int offset = (i + 1 - dayNumber) % 7;  // Tính toán sự chênh lệch ngày
                weekDays[i] = today.AddDays(offset);  // Cộng thêm số ngày tương ứng
            }
            List<Bookcar> lists = new List<Bookcar>();
            List<DatLichBaoDuongXe> listMaintaince = _db.DatLichBaoDuongXe.Where(l => (l.NgayDatLich >= weekDays[0] && l.NgayDatLich <= weekDays[6])&& (l.TrangThai ==StatusCarMaintaince.Approve.GetStatusName()||l.TrangThai==StatusCarMaintaince.Completed.GetStatusName() )).ToList();
            var results = listMaintaince.Join(_db.NguoiDung,
              item => item.NguoiDungID,
              user => user.NguoiDungID,
              (item, user) => new { item, user })
          .Join(_db.XeOTo,
              combined => combined.user.NguoiDungID,
              car => car.NguoiDungID,
              (combined, car) => new Bookcar
              {
                  nameCustomer = combined.user.HoTen,
                  Brand = car.HangXe,
                  Model = car.Model,
                  phone = combined.user.SoDienThoai,
                  time = combined.item.ThoiGianDatLich,
                  date = combined.item.NgayDatLich,
                  idBooking=combined.item.DatLichBaoDuongID,
                  status=combined.item.TrangThai,
                  
              }) // Nhóm theo các trường bạn muốn kiểm tra trùng lặp
      .GroupBy(x => new {
          x.nameCustomer,
          x.phone,
          x.date,
          x.time
      })
      // Chỉ lấy phần tử đầu tiên của mỗi nhóm
      .Select(g => g.First())
      .ToList();

            lists.AddRange(results);
            return lists;
        }
        public List<Bookcar> getAll() {
            StatusCarMaintaince status = StatusCarMaintaince.Pending;
            string statusName = status.GetStatusName();
            List<Bookcar> lists = new List<Bookcar>();
            List<DatLichBaoDuongXe> listMaintaince = _db.DatLichBaoDuongXe.Where(l => l.TrangThai == statusName).ToList();
            var results = listMaintaince.Join(_db.NguoiDung,
              item => item.NguoiDungID,
              user => user.NguoiDungID,
              (item, user) => new { item, user })
          .Join(_db.XeOTo,
              combined => combined.user.NguoiDungID,
              car => car.NguoiDungID,
              (combined, car) => new Bookcar
              {
                  nameCustomer = combined.user.HoTen,
                  Brand = car.HangXe,
                  Model = car.Model,
                  phone = combined.user.SoDienThoai,
                  time = combined.item.ThoiGianDatLich,
                  date = combined.item.NgayDatLich,
                  idBooking = combined.item.DatLichBaoDuongID,
                  status = combined.item.TrangThai,
              }) // Nhóm theo các trường bạn muốn kiểm tra trùng lặp
      .GroupBy(x => new {
          x.nameCustomer,
          x.phone,
          x.date,
          x.time
      })
      // Chỉ lấy phần tử đầu tiên của mỗi nhóm
      .Select(g => g.First())
      .ToList();

            lists.AddRange(results);
            return lists;

        }

        public List<DatLichBaoDuongXe> GetListMaintaince(params StatusCarMaintaince[] statuses)
        {
            // Tính ngày hôm nay
            DateTime today = DateTime.Today;

            // Xác định ngày đầu tuần (Thứ 2) và ngày cuối tuần (Chủ Nhật)
            int dayOfWeek = (int)today.DayOfWeek;
            if (dayOfWeek == 0) dayOfWeek = 7; // Chủ Nhật -> 7
            DateTime startOfWeek = today.AddDays(-dayOfWeek + 1); // Thứ 2
            DateTime endOfWeek = startOfWeek.AddDays(6);          // Chủ Nhật

            // Chuyển danh sách trạng thái sang dạng string (nếu cần so sánh chuỗi)
            var statusNames = statuses.Select(s => s.ToString()).ToList();

            // Truy vấn danh sách từ cơ sở dữ liệu
            List<DatLichBaoDuongXe> listMaintaince = _db.DatLichBaoDuongXe
                .Where(l => l.NgayDatLich >= startOfWeek &&
                            l.NgayDatLich <= endOfWeek &&
                            statusNames.Contains(l.TrangThai)) // Lọc theo trạng thái
                .ToList();

            return listMaintaince;
        }

        public List<Bookcar> GetPersonList(StatusCarMaintaince status = StatusCarMaintaince.Pending)
        {
            // Lấy danh sách trong tuần
            var listInWeek = GetListMaintaince(status);

            // Kết hợp dữ liệu từ listInWeek, _db.NguoiDung và _db.XeOTo
            var results = listInWeek.Join(_db.NguoiDung,
                item => item.NguoiDungID,
                user => user.NguoiDungID,
                (item, user) => new { item, user })
            .Join(_db.XeOTo,
                combined => combined.user.NguoiDungID,
                car => car.NguoiDungID,
                (combined, car) => new Bookcar
                {
                    idBooking = combined.item.DatLichBaoDuongID,
                    nameCustomer = combined.user.HoTen,
                    Brand = car.HangXe,
                    Model = car.Model,
                    phone = combined.user.SoDienThoai,
                    time = combined.item.ThoiGianDatLich,
                    date = combined.item.NgayDatLich,
                    status = combined.item.TrangThai,
                })
            .GroupBy(x => new
            {
                x.nameCustomer,
                x.phone,
                x.date,
                x.time
            })
            .Select(g => g.First())
            .ToList();

            return results;
        }


        public void UpdateDatabase()
        {


        }

    }
}
public class PersonBooking
{
    public string nameCustomer { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public DateTime? date { get; set; }
    public Time time { get; set; }
    public StatusMaintaince status { get; set; }
    public string Brand { get; set; }
    public string Model     { get; set; }
    public string Color     { get; set; }
    public string lienseCar { get; set; }
    public string methodResolve { get; set; }

    public StatusCarMaintaince recieveMaintainceCar { get; set; }
    public int PartID { get; set; }
    public int numParts { get; set; }
    public DateTime dateTransaction { get; set; }
    public string methodTakeCustomer { get; set; }
    public int CarID    { get; set; }

}
public class Bookcar
{
    public int idBooking    { get; set; }
    public string nameCustomer { get; set; }
    public string phone { get; set; }
    public DateTime? date { get; set; }
    public TimeSpan time { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string status { get; set; }
}