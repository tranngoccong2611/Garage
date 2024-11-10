using DocumentFormat.OpenXml.Drawing;
using Garage.Data;
using Garage.Data.Models;
using Garage.Forms.AddForm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.Forms.MainForm
{
    public partial class DashBoard : Form
    {
        private readonly GaraOtoDbContext _contextOptions;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly RevenueCalculator _revenueCalculator;
      private readonly TransactionInventory _transactionInventory;
      

      

        public DashBoard(GaraOtoDbContext context, IServiceScopeFactory scope, RevenueCalculator revenueCalculator,TransactionInventory inventory)
        {
            _contextOptions = context ?? throw new ArgumentNullException(nameof(context));
            _scopeFactory = scope ?? throw new ArgumentNullException(nameof(scope));
            _revenueCalculator = new RevenueCalculator(context);
            _transactionInventory = inventory;
            InitializeComponent();
            SetupLayout();
            this.MinimumSize = new Size(800, 600);
      
        }       
        private decimal GetTotalPartsSoldAmount()
        {
            // Sử dụng _contextOptions thay vì tạo context mới
            var totalAmount = _contextOptions.HoaDonLinhKien
                .Join(_contextOptions.LinhKien,
                    hlk => hlk.LinhKienID,
                    lk => lk.LinhKienID,
                    (hlk, lk) => new
                    {
                        Total = hlk.SoLuong * lk.Gia
                    })
                .Sum(x => x.Total);

            return totalAmount;
        }
        

       

        //Sửa lại phương thức GetTotalServiceInvoiceAmount
        private decimal GetTotalServiceInvoiceAmount()
        {
            // Sử dụng _contextOptions thay vì tạo context mới

            var total = _contextOptions.HoaDon
                .Join(_contextOptions.LichSuDichVu,
                      h => h.HoaDonID,
                      lsdv => lsdv.DonBaoDuongID,
                      (h, lsdv) => new { h.SoTien })
                .Sum(x => x.SoTien);

            return total;
        }

<<<<<<< HEAD
        // Sửa lại phương thức OpenEmployeeForm
  
=======
      
>>>>>>> b37bd4c2b01e1cd46d5816cf70437595a4b54121
       
        private void Logout(object? sender, EventArgs e)
        {
            this.Hide();
        }

      
      
   
    }
}
