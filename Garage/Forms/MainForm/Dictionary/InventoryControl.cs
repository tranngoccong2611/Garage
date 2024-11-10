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

namespace Garage.Forms.MainForm
{
    public partial class InventoryControl : UserControl
    {
        private readonly GaraOtoDbContext _db;
        
        public InventoryControl(GaraOtoDbContext context, TransactionInventory inventory)
        {
            _db = context;
            _inventory = inventory;
            InitializeComponent();
            
        }

      

    
    }
}
