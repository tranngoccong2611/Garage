using DocumentFormat.OpenXml.Drawing;
using Garage.Data;
using Garage.Data.Models;
using Garage.Forms.MainForm.Dictionary;
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
        private ListBooking _bookings;
        private ServiceCustomer _customer;
        private RepairTrackerUtils trackerRepairUtils;
        private GetStaff _staff;
        private GetCustomer _getCustomer;

        public DashBoard(GaraOtoDbContext context, IServiceScopeFactory scope,GetStaff staff,GetCustomer getCustomer,ServiceCustomer customer, RevenueCalculator revenueCalculator,TransactionInventory inventory,RepairTrackerUtils tracker,ListBooking listbooking)
        {
            _contextOptions = context ?? throw new ArgumentNullException(nameof(context));
            _scopeFactory = scope ?? throw new ArgumentNullException(nameof(scope));
            _revenueCalculator = new RevenueCalculator(context);
            _transactionInventory = inventory;
            InitializeComponent();
            SetupLayout();
            this.MinimumSize = new Size(800, 600);
            trackerRepairUtils = tracker;
            _bookings = listbooking;
            _customer = customer;
            _staff = staff;
            _getCustomer = getCustomer;
      
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
   

            var total = _contextOptions.LichSuDichVu.Join(_contextOptions.DichVu,
                      lsdv => lsdv.DichVuID,
                      dv=>dv.DichVuID,
                      ( lsdv,dv) => new { dv.Gia })
                .Sum(x => x.Gia);

            return total;
        } 
        private void Logout(object? sender, EventArgs e)
        {
            this.Hide();
        }

      
      
   
    }
}
