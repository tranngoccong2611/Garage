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
        private TransactionInventory _inventory;
      
        public InventoryControl(GaraOtoDbContext context, TransactionInventory inventory)
        {
           
                _db = context ?? throw new ArgumentNullException(nameof(context));
                _inventory = inventory ?? new TransactionInventory(_db); // Assign a default if null



            InitializeComponent();
            
            
        }

      

    
    }
}
