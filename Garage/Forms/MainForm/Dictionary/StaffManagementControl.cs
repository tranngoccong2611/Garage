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
    public partial class StaffManagementControl : UserControl
    {
        private readonly GaraOtoDbContext _dbContext;
        private GetStaff _getstaffs;
        public StaffManagementControl(GaraOtoDbContext context,GetStaff staffs)
        {
            _dbContext = context;
            _getstaffs = staffs;
            InitializeComponent();
        }
    }
}
