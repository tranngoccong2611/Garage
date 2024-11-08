using Garage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage.Forms.MainForm
{
    public partial class VehicleManagementForm : Form
    {
        private readonly GaraOtoDbContext _context;
        private DataGridView vehicleGrid;
        private TextBox searchBox;
        private ComboBox typeComboBox;
        private Label headerLabel; // Add a label for the header

        public VehicleManagementForm( )
        {
            
            InitializeComponents();
            LoadVehicleData();
        }

        private void InitializeComponents()
        {
            // Initialize Label for header text
            headerLabel = new Label
            {
                Text = "Quản lý xe",
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40 // Adjust height as necessary
            };

            // Initialize DataGridView for displaying vehicles
            vehicleGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            vehicleGrid.DoubleClick += VehicleGrid_DoubleClick;

            // Initialize TextBox for search functionality
            searchBox = new TextBox
            {
                PlaceholderText = "Tìm kiếm xe...",
                Dock = DockStyle.Top
            };
            searchBox.TextChanged += SearchBox_TextChanged;

            // Initialize ComboBox for filtering vehicle types
            typeComboBox = new ComboBox
            {
                Dock = DockStyle.Top
            };
            typeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;

            // Adding controls to the form
            Controls.Add(vehicleGrid);
            Controls.Add(searchBox);
            Controls.Add(typeComboBox);
            Controls.Add(headerLabel); // Add the header label to the form
        }

        private async void LoadVehicleData()
        {
            try
            {
                var vehicles = await _context.XeOTo
                    .Select(v => new
                    {
                        // Select vehicle details (adjust the properties as needed)
                        v.XeID,
                        v.HangXe,
                        v.Model,
                        v.NamSanXuat,
                        v.HinhAnh
                    })
                    .ToListAsync();

                vehicleGrid.DataSource = vehicles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu xe: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            // Implement search logic here based on searchBox.Text
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement filter logic here based on selected type
        }

        private void VehicleGrid_DoubleClick(object sender, EventArgs e)
        {
            ShowEditVehicleForm(); // Call to edit the selected vehicle
        }

        private void ShowAddVehicleForm()
        {
            // Logic for adding a vehicle
        }

        private void ShowEditVehicleForm()
        {
            // Logic for editing a vehicle
        }

        private void DeleteVehicle()
        {
            // Logic for deleting a vehicle
        }
    }
}
