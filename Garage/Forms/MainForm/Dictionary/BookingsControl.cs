using DocumentFormat.OpenXml.InkML;
using Garage.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms.MainForm.Dictionary
{
    public partial class BookingsControl : UserControl
    {
        private GaraOtoDbContext _db;
        private ListBooking _bookings;
        public BookingsControl(ListBooking bookings,GaraOtoDbContext db)
        {
           _db=db?? throw new ArgumentNullException(nameof(db));
            _bookings = bookings??new ListBooking(_db);
            InitializeComponent();
          
        }
        // Danh sách bảo dưỡng xe, mỗi xe sẽ có một thời gian bảo dưỡng trong tuần

    }
       
}
