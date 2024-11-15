using Garage.Common.Enum;
using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Forms.MainForm.Dictionary
{
    public class ListBooking
    {
        private readonly GaraOtoDbContext _db;



        public ListBooking(GaraOtoDbContext db)
        {
            _db = db;

        }
        public List<DatLichBaoDuongXe> GetListMaintaince()
        {
            StatusCarMaintaince status = StatusCarMaintaince.Pending;
            string statusName = status.GetStatusName();
            // Lấy ngày hôm nay
            DateTime today = DateTime.Today;

            // Tính số ngày trong tuần (0: Chủ nhật, 1: Thứ 2, ..., 6: Thứ 7)
            int dayOfWeek = (int)today.DayOfWeek;

            // Nếu hôm nay là Chủ Nhật (0), ta cần điều chỉnh để tính từ Thứ 2
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }

            // Tính ngày Thứ 2 của tuần hiện tại
            DateTime startOfWeek = today.AddDays(-dayOfWeek + 1); // Lùi lại (dayOfWeek - 1) ngày để tới Thứ 2
                                                                  // Tính ngày Chủ Nhật của tuần hiện tại
            DateTime endOfWeek = startOfWeek.AddDays(6); // Cộng thêm 6 ngày để tới Chủ Nhật
            List<DatLichBaoDuongXe> listMaintaince=_db.DatLichBaoDuongXe.Where(l=>l.NgayDatLich>=startOfWeek && l.NgayDatLich<=endOfWeek&&l.TrangThai==statusName).ToList();

            return listMaintaince;

        }
        public void UpdateDatabase()
        {


        }

    }
}
