using Garage.Data;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Garage.Forms.MainForm.Dictionary
{
    partial class DashboardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel mainContentPanelDashboard;
        private readonly RevenueCalculator _revenueCalculator;
        private readonly GaraOtoDbContext _dbContext;
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            // 
            // DashboardControl
            // 
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 245, 245);
            Name = "DashboardControl";
           
            
            SetupDashboardMainContentPanel();
         


        }

        public void SetupDashboardMainContentPanel()
        {
            // Main Content Panel
            mainContentPanelDashboard = new Panel
            {
               
                AutoScroll = true,
                BackColor = Color.Transparent,
               Dock = DockStyle.Fill,
               
            };

            // Stats Panel
            statsPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new System.Drawing.Point(20, 50),
                Height = 120,
                BackColor = Color.Transparent,
            };
            var res = _revenueCalculator.TileNowToMonth(2024);


            // Example usage:
            AddStatCard("Total Sales", res.revenue.ToString("C", new CultureInfo("en-US")), $"{((res.tile - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tile - 1) * 100):0.00}% from last year");

            AddStatCard("New Customers", res.countUser.ToString(), $"{((res.tileUser - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileUser - 1) * 100):0.00}% from last year");
            AddStatCard("Resolve Issues", res.numIssues.ToString(), $"{((res.tileIssuel - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileIssuel - 1) * 100):0.00}% from last year");

            // Add Controls to Main Content Panel

            mainContentPanelDashboard.Controls.Add( statsPanel );
            mainContentPanelDashboard.Controls.Add(InitialChartLayout());
            mainContentPanelDashboard.Controls.Add(InitializeFooter());

            // Add Main Content Panel to Form Controls
            Controls.Add(mainContentPanelDashboard);
        }
        private Panel InitialChartLayout()
        {
            var mainLayout = new TableLayoutPanel
            {
                Location = new Point(20, 200),
                ColumnCount = 2,
                RowCount = 2,
                AutoSize = false,
                Dock = DockStyle.None,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            mainContentPanelDashboard.Resize += (s, e) =>
            {
                mainLayout.Width = mainContentPanelDashboard.ClientSize.Width - 40;
                mainLayout.Height = 800; // Fixed height for the layout
            };

            // Set column and row styles with specific percentages
            mainLayout.ColumnStyles.Clear();
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));

            mainLayout.RowStyles.Clear();
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // Add charts with proper sizing
            mainLayout.Controls.Add(CreateMonthlyRevenueChart(), 0, 0);
            mainLayout.Controls.Add(CreateServicePartsChart(), 1, 0);
            mainLayout.Controls.Add(AddRecentOrdersGrid(), 0, 1);
            mainLayout.Controls.Add(CreateServiceRevenueChart(), 1, 1);

            return mainLayout;
        }

        private void InitializeStatsPanel()
        {
            statsPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new System.Drawing.Point(10, 10),
                Height = 120,
                BackColor = Color.Transparent,
            };

            var res = _revenueCalculator.TileNowToMonth(2024);

            AddStatCard("Total Sales", res.revenue.ToString("C", new CultureInfo("en-US")),
                $"{((res.tile - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tile - 1) * 100):0.00}% from last year");

            AddStatCard("New Customers", res.countUser.ToString(),
                $"{((res.tileUser - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileUser - 1) * 100):0.00}% from last year");

            AddStatCard("Resolve Issues", res.numIssues.ToString(),
                $"{((res.tileIssuel - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileIssuel - 1) * 100):0.00}% from last year");

            this.Controls.Add(statsPanel);

            // Handle resize
            this.Resize += (s, e) =>
            {
                statsPanel.Width = this.ClientSize.Width - 20;
                foreach (Control control in statsPanel.Controls)
                {
                    if (control is Panel card)
                    {
                        card.Width = (statsPanel.ClientSize.Width - 60) / 3;
                    }
                }
            };
        }

    

  
        private void AddStatCard(string title, string value, string comparison)
        {
            Panel card = new Panel
            {
                Height = 100,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            // Add shadow effect
            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid);
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 15),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(15, 40),
                AutoSize = true
            };

            Label comparisonLabel = new Label
            {
                Text = comparison,
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 70),
                ForeColor = comparison.Contains("↑") ? Color.Green : Color.Red,
                AutoSize = true
            };
            mainContentPanelDashboard.Resize += (s, e) =>
            {
                // Cập nhật chiều rộng của statsPanel khi mainContentPanel thay đổi kích thước
                statsPanel.Width = mainContentPanelDashboard.ClientSize.Width - 20;

                // Cập nhật lại chiều rộng của từng card
                foreach (Control control in statsPanel.Controls)
                {
                    if (control is Panel card)
                    {
                        card.Width = (statsPanel.ClientSize.Width - 60) / 3;  // Chia đều cho 3 card trong hàng
                    }
                }
            };

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(comparisonLabel);
            statsPanel.Controls.Add(card);
        }
        private Panel AddRecentOrdersGrid()
        {
            // Initialize the panel
            Panel ordersPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            // Title label for the panel
            Label ordersTitle = new Label
            {
                Text = "Recent Orders",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30
            };

            // Initialize the DataGridView
            DataGridView ordersGrid = new DataGridView
            {
                Location = new Point(15, 50),
                Width = ordersPanel.Width - 30,
                Height = ordersPanel.Height - 35,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,

                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom

            };
            ordersGrid.DefaultCellStyle.SelectionBackColor = ordersGrid.DefaultCellStyle.BackColor;
            ordersGrid.DefaultCellStyle.SelectionForeColor = ordersGrid.DefaultCellStyle.ForeColor;


            // Define columns for the DataGridView (only the columns we want to display)
            ordersGrid.Columns.AddRange(new DataGridViewColumn[]
            {
        new DataGridViewTextBoxColumn { Name = "OrderId", HeaderText = "Order ID" },
        new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "Customer" },
        new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" },
        new DataGridViewTextBoxColumn { Name = "Time", HeaderText = "Time" },
        new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone" }
            });

            // Retrieve the list of orders with full details
            var ordersList = _revenueCalculator.GetListUserDashBoard(2024);

            // Loop through each item and add only the selected properties to the DataGridView
            foreach (var order in ordersList)
            {
                ordersGrid.Rows.Add(
                    order.DatLichBaoDuongXe.DatLichBaoDuongID,                      // Order ID
                    order.NguoiDung.HoTen,                 // Customer
                    order.DatLichBaoDuongXe.NgayDatLich.ToString("dd/MM/yyyy"), // Date formatted
                    order.DatLichBaoDuongXe.ThoiGianDatLich,                       // Status
                    order.NguoiDung.SoDienThoai                         // Amount
                );
            }

            // Add the title and DataGridView to the panel
            ordersPanel.Controls.Add(ordersTitle);
            ordersPanel.Controls.Add(ordersGrid);

            return ordersPanel;
        }
    
      
        private Chart CreateServicePartsChart()
        {
            var chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var chartArea = new ChartArea();
            chartArea.BackColor = Color.White;
            chart.ChartAreas.Add(chartArea);

            // Add title
            chart.Titles.Add(new Title("Services vs Parts", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            var series = new Series
            {
                Name = "Services and Parts",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "{0}%"
            };
            decimal totalRevenue = _contextOptions.LichSuDichVu
          .Join(_contextOptions.DichVu,
              lsdv => lsdv.DichVuID, // Join condition on `DichVuID`
              dv => dv.DichVuID, // Join condition on `DichVuID`
              (lsdv, dv) => dv) // Select `DichVu` for further processing
          .Sum(dv => dv.Gia); // Sum the `Gia` column from `DichVu`
            decimal totalParts = _contextOptions.HoaDonLinhKien
                .Join(_contextOptions.HoaDon, hl => hl.HoaDonID, hd => hd.HoaDonID, (hl, hd) => new { hl, hd })
                .Join(_contextOptions.LinhKien, combined => combined.hl.LinhKienID, lk => lk.LinhKienID, (combined, lk) => new
                {
                    Revenue = combined.hl.SoLuong * lk.Gia,
                    NgayGiaoDich = combined.hd.NgayGiaoDich // Add the date field here
                })

                .Sum(x => x.Revenue) * 100;
            decimal restotal = totalRevenue + totalParts;


            // Add data points with custom colors
            DataPoint servicesPoint = new DataPoint();
            servicesPoint.SetValueY(totalRevenue / restotal);
            servicesPoint.Color = Color.FromArgb(250, 204, 21);
            servicesPoint.Label = $"Services ({((totalRevenue / restotal) * 100):F2}%)";
            series.Points.Add(servicesPoint);

            DataPoint partsPoint = new DataPoint();
            partsPoint.SetValueY((totalParts / restotal));
            partsPoint.Color = Color.FromArgb(99, 102, 241);
            partsPoint.Label = $"Parts ({((totalParts / restotal) * 100):F2}%)";
            series.Points.Add(partsPoint);

            chart.Series.Add(series);
            return chart;
        }

        private Chart CreateServiceRevenueChart()
        {
            var chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Create the chart area
            var chartArea = new ChartArea();
            chartArea.BackColor = Color.White;

            // Modify the position of the chart area (moving it to the left)
            chartArea.Position = new ElementPosition(0, 10, 70, 80); // Left position (0), Width (70%)

            chart.ChartAreas.Add(chartArea);

            // Add title
            chart.Titles.Add(new Title("Service Revenue Breakdown", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            var series = new Series
            {
                Name = "Service Revenue",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "{0}%"
            };

            var lists = _revenueCalculator.TotalRevenueRevenueList();

            // Define an array of predefined colors
            Color[] colors = new Color[]
            {
        Color.FromArgb(250, 204, 21),   // Yellow
        Color.FromArgb(255, 99, 71),    // Tomato Red
        Color.FromArgb(135, 206, 250),  // Light Sky Blue
        Color.FromArgb(144, 238, 144),  // Light Green
        Color.FromArgb(255, 182, 193),  // Light Pink
        Color.FromArgb(255, 182, 100)   // Light Orange
            };

            int colorCount = colors.Length;
            int index = 0;

            foreach (var list in lists)
            {
                DataPoint service = new DataPoint();
                service.SetValueY(list.value); // Set value based on list item

                // Assign color in sequence
                service.Color = colors[index % colorCount];

                // Set label with percentage
                decimal total = lists.Sum(x => x.value);
                decimal percentage = (list.value / total) * 100;
                service.Label = $"{percentage:F2}%";
                if (list.value / (decimal)total > 0.05m) // If the value is less than 5%
                {
                    service.LabelAngle = 0; // Horizontal label for small values
                    service.LabelBackColor = Color.Transparent; // Set transparent background if needed
                    service.LabelBorderColor = Color.Transparent; // Remove border if needed
                }
                else
                {
                    service.LabelAngle = 90; // Rotate labels for larger values
                }
                series.Points.Add(service);

                index++;
            }
            chart.Series.Add(series);
            Panel colorLegendPanel = new Panel();
            colorLegendPanel.Dock = DockStyle.Right;  // Place the legend panel to the right of the chart
            colorLegendPanel.Width = 105;  // Width of the legend panel
            colorLegendPanel.BackColor = Color.White;

            int yPosition = 20;  // Vertical position for the first color legend item

            foreach (var list in lists)
            {
                // Create a label for each color
                Label colorLabel = new Label
                {
                    Text = list.name,  // Display the service name
                    ForeColor = Color.Black,  // Text color (to contrast with the color)
                    Width = 100,  // Width for the label (fixed width)
                    Height = 0,  // Set initial height to 0
                    TextAlign = ContentAlignment.TopLeft,  // Align text to the top-left for wrapping
                    AutoSize = true,  // Automatically adjust height based on text content
                    Location = new Point(15, yPosition + 70)  // Position the label vertically
                };

                // Create a small color panel next to the label
                Panel showColor = new Panel
                {
                    Width = 15,
                    Height = 15,
                    Location = new Point(3, yPosition + 70),
                    BackColor = colors[index % colorCount]  // Set the background color based on the sequence
                };

                colorLegendPanel.Controls.Add(showColor);
                colorLegendPanel.Controls.Add(colorLabel);

                yPosition += 35;  // Increase yPosition for the next label, considering label height
                index++;  // Increment color index for the next color
            }


            chart.Controls.Add(colorLegendPanel);  // Assuming you're working in a Windows Form
            return chart;
        }


        private Chart CreateMonthlyRevenueChart()
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;
            chart.ChartAreas.Add(chartArea);

            chart.Titles.Add(new Title("Monthly Revenue", Docking.Top,
                new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            Series series = new Series
            {
                Name = "Revenue",
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(250, 204, 21),
                BorderWidth = 0
            };

            // Add sample data (you might want to replace this with real data)
            series.Points.AddXY("Jan", 5000);
            series.Points.AddXY("Feb", 6000);
            series.Points.AddXY("Mar", 4500);
            series.Points.AddXY("Apr", 7000);
            series.Points.AddXY("May", 8000);
            series.Points.AddXY("Jun", 5500);
            series.Points.AddXY("Jul", 9000);

            chart.Series.Add(series);
            return chart;
        }

        private Panel InitializeFooter()
        {
            var footerPanel = new Panel
            {
                Width = this.Width,
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.White
            };

            var footerLabel = new Label
            {
                Text = "© 2024 Garage Management System. All rights reserved. | Contact: info@garage.com | Follow us on social media.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                ForeColor = Color.Black
            };

            footerPanel.Controls.Add(footerLabel);
            return footerPanel;
        }
        #endregion
    }
}
