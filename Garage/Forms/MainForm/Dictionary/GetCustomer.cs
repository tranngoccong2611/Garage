using Garage.Data;
using Garage.Data.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Users
{
    public string ImageUser { get; set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Address { get; set; }
    public int numsOrders { get; set; }
    public int totalMoneyUse { get; set; }
    public string phoneNumber { get; set; } 

}
namespace Garage.Forms.MainForm.Dictionary
{
    public class GetCustomer
    {
        private readonly GaraOtoDbContext _dbContext;
        public GetCustomer(GaraOtoDbContext context) {
            _dbContext = context;

        }
        public int GetOrders(int idUser)
        {
            int orders=0;
            if (idUser == null) {
                return 0;
            } 
            List<int> listCarOfUser=_dbContext.XeOTo.Where(c=>c.NguoiDungID == idUser).Select(c=>c.XeID).ToList();
        foreach (int carID in listCarOfUser) {
                orders += _dbContext.DSDonBaoDuongXe.Where(ds => ds.XeID == carID).Count();
               
            }

            return orders;
        }
        public List<Users> GetUsers(string phoneNumber)
        {
            var lists=GetAllUsers();
            var users =lists.Where(item=>item.phoneNumber==phoneNumber).ToList();
         
            return users;
        }
        public decimal GetTotalMoneyUseServices(int userID) {
            decimal totalMoneyUse=0 ;
            if (userID == null)
            {
                return 0;
            }
            List<int> listCarOfUser = _dbContext.XeOTo.Where(c => c.NguoiDungID == userID).Select(c => c.XeID).ToList();
            foreach (int idCar in listCarOfUser)
            {
                List<int> listMaintainceID = _dbContext.DSDonBaoDuongXe.Where(ds => ds.XeID == idCar).Select(c=>c.DonBaoDuongID).ToList();
                foreach(int idMaintaince in listMaintainceID) {
                   
                       int DichVuID = _dbContext.LichSuDichVu.Where(ls => ls.DonBaoDuongID == idMaintaince).Select(ls => ls.DichVuID).FirstOrDefault()??0;
                    if (DichVuID == 0) { return 0; }
                    totalMoneyUse += _dbContext.DichVu
                        .Where(dv => dv.DichVuID == DichVuID)
                        .Select(dv => dv.Gia)
                        .FirstOrDefault();
                }
            }
            return totalMoneyUse;
        }
        public decimal GetTotalParts(int userID) {
            decimal totalMoney = 0;

            if (userID == null)
            {
                return 0;
            }

            // Lấy danh sách ID của các hóa đơn cho người dùng cụ thể
            List<int> listIDHoaDon = _dbContext.HoaDon
                .Where(hd => hd.NguoiDungID == userID)
                .Select(hd => hd.HoaDonID)
                .ToList();

            foreach (var idHoaDon in listIDHoaDon)
            {
          
                decimal moneyForPart = _dbContext.HoaDon
                    .Where(hd => hd.HoaDonID == idHoaDon)
                    .Join(
                        _dbContext.HoaDonLinhKien,
                        hd => hd.HoaDonID,
                        hdlk => hdlk.HoaDonID,
                        (hd, hdlk) => new { hdlk.LinhKienID, hdlk.SoLuong }
                    )
                    .Join(
                        _dbContext.LinhKien,
                        temp => temp.LinhKienID,
                        lk => lk.LinhKienID,
                        (temp, lk) => temp.SoLuong * lk.Gia 
                    )
                    .Sum(); 

              
                totalMoney += moneyForPart;
            }

            return totalMoney;
        }
        public decimal GetTotalSpent(int userID)
        {
            
            decimal totalSpentPart = GetTotalParts(userID);
            decimal totalSpentServices = GetTotalMoneyUseServices(userID);
            return totalSpentServices + totalSpentPart;
        }
        public List<Users> GetAllUsers()
        {
            // Lấy danh sách tất cả người dùng từ database
            var userList = _dbContext.NguoiDung
                .Select(u => new
                {
                    u.NguoiDungID,
                    u.HoTen,
                    u.Email,
                    u.DiaChi,
                    u.HinhAnh,
                    u.SoDienThoai
                })
                .ToList();

            // Tạo danh sách thực thể Users
            List<Users> users = new List<Users>();

            foreach (var user in userList)
            {
                int orders = GetOrders(user.NguoiDungID); // Số đơn hàng của người dùng
                decimal totalMoneyUse = GetTotalSpent(user.NguoiDungID); // Tổng tiền đã chi tiêu

                // Thêm vào danh sách
                users.Add(new Users
                {
                    phoneNumber = user.SoDienThoai.ToString(),
                    UserName = user.HoTen,
                    Mail = user.Email,
                    Address = user.DiaChi,
                    ImageUser = user.HinhAnh,
                    numsOrders = orders,
                    totalMoneyUse = (int)totalMoneyUse // Ép kiểu nếu cần
                });
            }

            return users;
        }
       
    }
}
