using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Data.Services
{
    // DashboardService.cs
   
        public class DashboardService
        {
            private readonly GaraOtoDbContext _context;

            public DashboardService(GaraOtoDbContext context)
            {
                _context = context;
            }

            public async Task<(int TotalCars, int TotalUsers, int TodayAppointments)> GetDashboardStats()
            {
                return (
                    await _context.XeOTo.CountAsync(),
                    await _context.NguoiDung.CountAsync(),
                    await _context.DatLichBaoDuongXe.CountAsync(d => d.NgayDatLich.Date == DateTime.Today)
                );
            }

            public async Task<List<MonthlyStatistic>> GetMonthlyStatistics()
            {
                return await _context.DatLichBaoDuongXe
                    .GroupBy(x => new { x.NgayDatLich.Year, x.NgayDatLich.Month })
                    .Select(g => new MonthlyStatistic
                    {
                        Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                        Count = g.Count()
                    })
                    .OrderByDescending(x => x.Month)
                    .Take(6)
                    .OrderBy(x => x.Month)
                    .ToListAsync();
            }
        }

        public class MonthlyStatistic
        {
            public DateTime Month { get; set; }
            public int Count { get; set; }
        }
    
}
