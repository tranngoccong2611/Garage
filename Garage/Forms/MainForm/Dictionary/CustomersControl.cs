using Garage.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms.MainForm.Dictionary
{
    public partial class CustomersControl : UserControl
    {
        private readonly GaraOtoDbContext _db;
        private GetCustomer _getCutomer;
        private ListBooking _bookings;
        public CustomersControl(GetCustomer getCutomer,GaraOtoDbContext db,ListBooking booking)
        {
            _db = db;
            _bookings = booking;
            _getCutomer = getCutomer;
            InitializeComponent();
           
        
        }
    }
}
public static class GraphicsExtensions
{
    public static void AddRoundedRectangle(this GraphicsPath path, Rectangle rect, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(rect.Location, size);

        path.AddArc(arc, 180, 90);
        arc.X = rect.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = rect.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
    }
}