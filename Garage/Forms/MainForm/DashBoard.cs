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
        private FlowLayoutPanel quickActionsPanel;
      
        private System.Windows.Forms.Timer refreshTimer;
        private bool refreshing = false;

        public DashBoard(GaraOtoDbContext context, IServiceScopeFactory scope, RevenueCalculator revenueCalculator)
        {
            _contextOptions = context ?? throw new ArgumentNullException(nameof(context));
            _scopeFactory = scope ?? throw new ArgumentNullException(nameof(scope));
            _revenueCalculator = new RevenueCalculator(context);

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

        // Sửa lại phương thức OpenEmployeeForm
  
       
        private void Logout(object? sender, EventArgs e)
        {
            this.Hide();
        }

        private void OpenCustomerCareForm(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenMaintenanceOrderTrackingForm(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenSparePartsForm(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenMaintenanceScheduleForm(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenCustomerForm(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
      
   
    }
}
