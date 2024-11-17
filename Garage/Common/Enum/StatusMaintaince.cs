using Garage.Common.Enum;
using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.Common.Enum
{
    public enum StatusMaintaince
    {
        DONE = 0,
        TODO = 1,
        FAILED = 2,
    }

    public enum StatusCarMaintaince
    {
        Pending = 0,    // Chờ xác nhận
        Approve = 1,   // Đã xác nhận
        Reject = 2,     // Từ chối
        Completed = 3   // Đã nhận xe
    }
}

public static class BookingCar
{
   
    public static void UpdateBookingStatus(int bookingId, GaraOtoDbContext context,StatusCarMaintaince newStatus)
    {
       
            DatLichBaoDuongXe booking = context.DatLichBaoDuongXe.Where(i=>i.DatLichBaoDuongID==bookingId).FirstOrDefault();
            if (booking != null)
            {
                string statusName = newStatus.GetStatusName(); // Sửa cách gọi extension method
                booking.TrangThai = statusName; // Giả sử TrangThai là string trong DB
            MessageBox.Show(""+statusName);
                context.SaveChanges();
            }
        
    }

    // Thêm phương thức để lấy StatusCarMaintaince từ string
    public static StatusCarMaintaince GetStatusFromString(string status)
    {
        if (Enum.TryParse<StatusCarMaintaince>(status, true, out StatusCarMaintaince result))
        {
            return result;
        }
        return StatusCarMaintaince.Pending; // Trả về giá trị mặc định
    }
}

public static class StatusMaintainceExtensions
{
    public static string ToFriendlyString(this StatusMaintaince status)
    {
        switch (status)
        {
            case StatusMaintaince.DONE:
                return "Done";
            case StatusMaintaince.TODO:
                return "To Do";
            case StatusMaintaince.FAILED:
                return "Failed";
            default:
                return "Unknown";
        }
    }
}

public static class StatusCarMaintainceExtensions
{
    private static readonly Dictionary<StatusCarMaintaince, string> _statusNames = new Dictionary<StatusCarMaintaince, string>
    {
        { StatusCarMaintaince.Pending, "Pending" },
        { StatusCarMaintaince.Approve, "Approve" },
        { StatusCarMaintaince.Reject, "Reject" },
        { StatusCarMaintaince.Completed, "Completed" }
    };

    public static string GetStatusName(this StatusCarMaintaince status)
    {
        return _statusNames.ContainsKey(status) ? _statusNames[status] : "Unknown";
    }

    // Thêm phương thức để lấy StatusCarMaintaince từ tên
    public static StatusCarMaintaince GetStatusFromName(string statusName)
    {
        var status = _statusNames.FirstOrDefault(x => x.Value.Equals(statusName, StringComparison.OrdinalIgnoreCase));
        return status.Key;
    }

    // Lấy tất cả trạng thái có thể
    public static Dictionary<StatusCarMaintaince, string> GetAllStatuses()
    {
        return _statusNames;
    }
}