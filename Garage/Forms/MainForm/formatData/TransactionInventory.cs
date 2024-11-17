using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//private class Transactions()
//{
    
//}
    public class TransactionInventory
{
    private readonly GaraOtoDbContext dbContext;
    public TransactionInventory(GaraOtoDbContext context) {
        dbContext = context;
    }

    public List<LinhKien> GetLinhKienList(int id = 0)
    {
        if (id !=0)
        {
            // Lấy danh sách theo ID nếu ID có giá trị
            return dbContext.LinhKien.Where(lk => lk.LinhKienID == id).ToList();
        }
        // Trả về toàn bộ danh sách nếu ID không có giá trị
        return dbContext.LinhKien.ToList();
    }


    public List<TransactionQuery> GetTransactionsByDate(DateTime startDate, DateTime endDate, int? id = null)
    {
        // Kiểm tra nếu startDate và endDate không phải là null và startDate nhỏ hơn endDate
        if (startDate > endDate)
        {
            MessageBox.Show("Start date must be less than or equal to end date.");
            return new List<TransactionQuery>();  // Return empty if dates are invalid
        }

        // Step 1: Define the base query
        var query = dbContext.HoaDon
            .Where(hd => hd.NgayGiaoDich >= startDate && hd.NgayGiaoDich <= endDate)  // Filter by date
            .Join(dbContext.HoaDonLinhKien,
                hd => hd.HoaDonID,
                hdlk => hdlk.HoaDonID,
                (hd, hdlk) => new { HoaDon = hd, HoaDonLinhKien = hdlk })
            .Join(dbContext.NguoiDung,
                temp => temp.HoaDon.NguoiDungID,
                nd => nd.NguoiDungID,
                (temp, nd) => new { temp, NguoiDung = nd })
            .Join(dbContext.LinhKien,
                tmp => tmp.temp.HoaDonLinhKien.LinhKienID,
                lk => lk.LinhKienID,
                (tmp, lk) => new TransactionQuery
                {
                    userId = tmp.NguoiDung.NguoiDungID,
                    anh = tmp.NguoiDung.HinhAnh,
                    ten = tmp.NguoiDung.HoTen,
                    tenLinhKien = lk.TenLinhKien,
                    soLuongLinhKien = tmp.temp.HoaDonLinhKien.SoLuong,
                    GiaTriHoaDon = tmp.temp.HoaDonLinhKien.SoLuong * lk.Gia,
                    NgayGiaoDich = tmp.temp.HoaDon.NgayGiaoDich ?? new DateTime(2023, 1, 1),
                    idLinhKien = lk.LinhKienID
                });

        // Step 2: Apply the id filter if it's provided
        if (id != null)
        {
            query = query.Where(lktp => lktp.idLinhKien == id);
        }

        // Step 3: Execute the query and return the results
        return query.ToList();
    }


}
public class TransactionQuery
{
    public int userId;
    public string anh;
    public string ten;
    public string tenLinhKien;
    public int soLuongLinhKien;
    public decimal GiaTriHoaDon;
    public DateTime NgayGiaoDich;
    public int idLinhKien;

}