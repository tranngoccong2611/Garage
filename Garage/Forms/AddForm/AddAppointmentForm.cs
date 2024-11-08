using Garage.Data;
using Garage.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Garage.Forms.AddForm
{
    public partial class AddAppointmentForm : Form
    {
        private readonly GaraOtoDbContext _context;

        public AddAppointmentForm(GaraOtoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
            LoadCustomers(); // Load customers to populate the combo box
        }

        private void InitializeComponent()
        {
            this.Text = "Đặt Lịch Hẹn";

            // Initialize fields and button
            var customerLabel = new Label { Text = "Khách Hàng", Left = 10, Top = 20 };
            var customerComboBox = new ComboBox { Left = 120, Top = 20, Width = 200 };
            var dateLabel = new Label { Text = "Ngày Hẹn", Left = 10, Top = 60 };
            var dateTimePicker = new DateTimePicker { Left = 120, Top = 60, Width = 200 };
            var addButton = new Button { Text = "Đặt Lịch", Left = 120, Top = 100 };

            addButton.Click += (s, e) =>
            {
                int customerId = (int)customerComboBox.SelectedValue; // Ensure SelectedValue is valid
                DateTime selectedDate = dateTimePicker.Value; // Get the selected date
                AddAppointment(customerId, selectedDate); // Call the method with correct parameters
            };

            this.Controls.Add(customerLabel);
            this.Controls.Add(customerComboBox);
            this.Controls.Add(dateLabel);
            this.Controls.Add(dateTimePicker);
            this.Controls.Add(addButton);
        }

        private void LoadCustomers()
        {
            // Load customers from the database
            var customers = _context.NguoiDung.Select(c => new
            {
                c.NguoiDungID, // Assuming ID is the primary key
                FullName = c.HoTen // Assuming you have properties for first and last name
            }).ToList();

            // Assuming you have a ComboBox control for customer selection
            var customerComboBox = this.Controls.OfType<ComboBox>().FirstOrDefault();
            if (customerComboBox != null)
            {
                customerComboBox.DataSource = customers;
                customerComboBox.DisplayMember = "FullName"; // Display full name in the dropdown
                customerComboBox.ValueMember = "ID"; // Use ID as the value
            }
        }

        private void AddAppointment(int customerId, DateTime appointmentDate)
        {
            if (customerId > 0) // Ensure a valid customer ID is selected
            {
                var newAppointment = new DatLichBaoDuongXe
                {
                    NguoiDungID = customerId, // Use the selected customer ID
                    NgayDatLich = appointmentDate
                };
                _context.DatLichBaoDuongXe.Add(newAppointment);
                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
