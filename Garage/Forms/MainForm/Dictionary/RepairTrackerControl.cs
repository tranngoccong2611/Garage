using Garage.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms.MainForm.Dictionary
{
    public partial class RepairTrackerControl : UserControl
    {
        private readonly GaraOtoDbContext _context;
        private RepairTrackerUtils _trackerUtils;
        public RepairTrackerControl(GaraOtoDbContext context, RepairTrackerUtils trackerUtils)
        {
            // Kiểm tra null
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _trackerUtils = trackerUtils ?? throw new ArgumentNullException(nameof(trackerUtils));

            InitializeComponent();
            // Khởi tạo suggestionList nếu chưa có
            if (suggestionList == null)
            {
                suggestionList = new ListBox();
                // Set các thuộc tính cần thiết
                suggestionList.Visible = false;
                // Thêm vào control
                this.Controls.Add(suggestionList);
            }
        }
 

        
    }
    }
