using Garage.Data;
using Garage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Forms.AddForm
{
    public partial class AddVehicleForm : Form
    {
        private readonly GaraOtoDbContext _context;

        public AddVehicleForm(GaraOtoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Thêm Xe";
            // Initialize fields and button
            var makeLabel = new Label { Text = "Hãng Xe", Left = 10, Top = 20 };
            var makeTextBox = new TextBox { Left = 120, Top = 20, Width = 200 };
            var modelLabel = new Label { Text = "Mẫu Xe", Left = 10, Top = 60 };
            var modelTextBox = new TextBox { Left = 120, Top = 60, Width = 200 };
            var addButton = new Button { Text = "Thêm", Left = 120, Top = 100 };
            addButton.Click += (s, e) => AddVehicle(makeTextBox.Text, modelTextBox.Text);
            this.Controls.Add(makeLabel);
            this.Controls.Add(makeTextBox);
            this.Controls.Add(modelLabel);
            this.Controls.Add(modelTextBox);
            this.Controls.Add(addButton);
        }

        private void AddVehicle(string make, string model)
        {
            if (!string.IsNullOrWhiteSpace(make) && !string.IsNullOrWhiteSpace(model))
            {
                var newVehicle = new XeOTo { HangXe = make, Model = model };
                _context.XeOTo.Add(newVehicle);
                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Các trường không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
