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
    public partial class DashboardControl : UserControl
    {
        private FlowLayoutPanel statsPanel;
     
        private GaraOtoDbContext _contextOptions;


        public DashboardControl(RevenueCalculator revenueCalculator, GaraOtoDbContext context)
        {
            _revenueCalculator = revenueCalculator ?? throw new ArgumentNullException(nameof(revenueCalculator));
            _contextOptions=context ?? throw new ArgumentNullException(nameof(_contextOptions));

            InitializeComponent();
        }

      
    }
}
