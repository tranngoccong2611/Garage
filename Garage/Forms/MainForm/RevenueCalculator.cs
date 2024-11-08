using Garage.Data;
using Garage.Data.Models;
using Microsoft.EntityFrameworkCore;
public class RevenueInfo
{
    public decimal NowRevenueMonth { get; set; }
    public decimal Tile { get; set; }
    public decimal TinhDoanhThuLinhKienTheoThangNam { get; set; }
    public decimal TinhDoanhThuDichVuTheoThangNam { get; set; }
    public decimal SoDonDatLichBaoDuong { get; set; }
    public List<ListChartServices> TotalRevenueRevenueList { get; set; }
}

public class UserWithOrder
{
    public NguoiDung NguoiDung { get; set; }
    public DatLichBaoDuongXe DatLichBaoDuongXe { get; set; }
}

public class RevenueCalculator
{
    private readonly GaraOtoDbContext _contextOptions;

    public RevenueCalculator(GaraOtoDbContext contextOptions)
    {
        _contextOptions = contextOptions ?? throw new ArgumentNullException(nameof(contextOptions));
    }

    public decimal TinhDoanhThuLinhKienTheoThangNam(int year)
    {
        // Ensure _contextOptions is the instance of GaraOtoDbContext injected via DI
       
        // Calculate revenue based on the specified year and month
        var revenue = _contextOptions.HoaDon
    .Where(hd => hd.NgayGiaoDich.HasValue &&
                
                 hd.NgayGiaoDich.Value.Year == year)
    .Join(_contextOptions.HoaDonLinhKien,
          hd => hd.HoaDonID,
          hdlk => hdlk.HoaDonID,
          (hd, hdlk) => hdlk)
    .Join(_contextOptions.LinhKien,
          hdlk => hdlk.LinhKienID,
          lk => lk.LinhKienID,
          (hdlk, lk) => new { hdlk.SoLuong, lk.Gia }) // Project necessary fields
    .Sum(item => item.SoLuong * item.Gia); // Calculate total revenue

        return revenue;

    }


    public int SoDonDatLichBaoDuong(int year)
    {
        int numOrder = _contextOptions.DatLichBaoDuongXe
            .Where(dl => dl.NgayDatLich.Year == year).ToList()
            .Count();

        return numOrder;
    }

    public decimal TinhDoanhThuDichVuTheoThangNam(int year)
    {

        decimal totalRevenue = _contextOptions.LichSuDichVu.Where(lsdv=>lsdv.NgayThucHien.HasValue&&lsdv.NgayThucHien.Value.Year==year)
        .Join(_contextOptions.DichVu,
            lsdv => lsdv.DichVuID, // Join condition on `DichVuID`
            dv => dv.DichVuID, // Join condition on `DichVuID`
            (lsdv, dv) => dv) // Select `DichVu` for further processing
        .Sum(dv => dv.Gia);
       

        return totalRevenue;

    }
    public List<UserWithOrder> GetListUserDashBoard(int year)
    {
        var lists = _contextOptions.DatLichBaoDuongXe
            .Where(dl => dl.NgayDatLich.Year == year) // Filter by the year
            .Join(_contextOptions.NguoiDung, // Join with NguoiDung
                dl => dl.NguoiDungID, // Join condition for DatLichBaoDuongXe
                u => u.NguoiDungID, // Join condition for NguoiDung
                (dl, u) => new UserWithOrder { NguoiDung = u, DatLichBaoDuongXe = dl }).AsNoTracking() // Select both NguoiDung and DatLichBaoDuongXe objects
            .Take(10).ToList() // Limit the results to 5 records
            ; // Execute the query and convert it to a list

        return lists; // Return the list of UserWithOrder objects
    }



    
    public decimal TinhTongDoanhThuTheoThangNam(int year)
    {
        var nowRevenue = TinhDoanhThuDichVuTheoThangNam(year) + TinhDoanhThuLinhKienTheoThangNam(year);
       
        return nowRevenue;
    }
    public int SoVanDeGiaiQuet(int year)
    {
        int soVanDes = _contextOptions.DSDonBaoDuongXe.Where(ds => ds.NgayBaoDuong.HasValue && ds.NgayBaoDuong.Value.Year == year).Count();
        return soVanDes;
    }
    public int GetUserInYear(int year)
    {
        int numUser=_contextOptions.NguoiDung.Where(nd=>nd.NgayThamGia.HasValue&&nd.NgayThamGia.Value.Year==year).Count();
            return numUser;
    }
    public List<ServicesRevenue> TotalRevenueRevenueList()
    {
        var listServices = _contextOptions.LichSuDichVu
            .GroupBy(ls => new { ls.DichVu.DichVuID, ls.DichVu.TenDichVu }) // Group by service ID and name
            .Select(g => new ServicesRevenue
            {
                id = g.Key.DichVuID,
                name = g.Key.TenDichVu,
                value =(int) g.Sum(ls => ls.DichVu.Gia) // Sum up the total price for each service
            })
            .ToList();

        return listServices;
    }

    public ResRevenue TileNowToMonth(int year)
    {
        decimal tile;
        decimal nowYear = TinhTongDoanhThuTheoThangNam(year);
        decimal lastYear = TinhTongDoanhThuTheoThangNam(year - 1);
        int numIssuel = SoVanDeGiaiQuet(year);
        int numIssuelLastYear = SoVanDeGiaiQuet(year-1);
        decimal tileIssuel;
        int countUser=GetUserInYear(year);
        int countUserLastYear=GetUserInYear(year-1);
        decimal tileUser;
        int numOrder = SoDonDatLichBaoDuong(year);
        int numOrderLastYear = SoDonDatLichBaoDuong(year - 1);
      
        decimal tileOrder;

        if (lastYear == 0)
        {
            return new ResRevenue
            {
                tile = 1,
                revenue = nowYear, // Assuming revenue here is a decimal
            };
        }

        tile = nowYear / lastYear;



        tileIssuel =  numIssuelLastYear ==0?  1: (decimal) numIssuel / numIssuelLastYear;
      tileUser=countUserLastYear==0?1: (decimal) countUser / countUserLastYear;
        tileOrder=numOrderLastYear==0?1: (decimal) numOrder / numOrderLastYear;
        return new ResRevenue
        {
            tile = tile,
            revenue = nowYear, // Store nowMonth as decimal for revenue
            tileIssuel=tileIssuel,
            numIssues=numIssuel,
            tileUser=tileUser,
            countUser=countUser,
            tileOrder=tileOrder,
            numOrders=numOrder,
        };
    }
}
    public class ResRevenue
    {
        public decimal revenue { get; set; }  // Changed to decimal
        public decimal tile { get; set; }
    public decimal tileIssuel { get; set; }
    public int numIssues { get; set; }
    public int countUser { get; set; }
    public decimal tileUser { get; set; }
    public int numOrders { get; set; }
    public decimal tileOrder { get; set; }
}
public class ListChartServices
{ 
    public ServicesRevenue ServicesRevenue { get; set; }    
}
public class ServicesRevenue { 
    public string name { get; set; }
    public int value { get; set; }
    public int id { get; set; }
    
}
