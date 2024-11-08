using DocumentFormat.OpenXml.Spreadsheet;
using Garage.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;

namespace Garage.Forms.MainForm
{
    partial class DashBoard : Form
    {
        private System.ComponentModel.IContainer components = null;
        public event Action<string> ButtonClicked;
        private Panel headerPanel;
        private Panel mainContentPanel;
        private Panel sidebarPanel;
        private Panel lblLogo;
        private Panel menuPanel;
        private TextBox searchBox;
        private Panel dropdownPanel;
        private Label dropdownLabel;
        private FlowLayoutPanel statsPanel;
      

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.Text = "Dashboard";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 245, 245);
        }
      
        private void SetupLayout()
        {
            // Sidebar Panel
            sidebarPanel = new Panel
            {
                Width = 250,
                Dock = DockStyle.Left,
                BackColor = Color.White
            };
            Image logoImage = Image.FromFile(@"D:\btlWinform\Garage\Garage\Resources\Images\logo_garage.png");
            lblLogo = new Panel
            {
                BackgroundImage = logoImage,
                BackgroundImageLayout = ImageLayout.Stretch, 
                Height = 120,  // Set height of the panel
                Width = 200,  // Set width of the panel
                Location = new Point(25, 20), // Set position of the panel within the sidebar
            };
            dropdownPanel = new Panel();
            dropdownPanel.Size = new System.Drawing.Size(200, 250);
            dropdownPanel.Location = new System.Drawing.Point(SystemInformation.WorkingArea.Width-250, 60);
            dropdownPanel.BackColor = System.Drawing.Color.White;
            dropdownPanel.BorderStyle = BorderStyle.FixedSingle;
            dropdownPanel.Visible = false; // Đặt ban đầu là ẩn

            // Thêm label vào panel dropdown
            dropdownLabel = new Label();
            dropdownLabel.Text = "No information available.";
            dropdownLabel.Size = new System.Drawing.Size(180, 80);
            dropdownLabel.Location = new System.Drawing.Point(10, 10);
            dropdownPanel.Controls.Add(dropdownLabel);
            dropdownLabel.ForeColor = System.Drawing.Color.Black;

            // Thêm nút và panel vào form
          
            this.Controls.Add(dropdownPanel);
       
            // Add the panel to the sidebar
            sidebarPanel.Controls.Add(lblLogo);
            // Menu Panel
            SetupMenuPanel();
            InitializeHeader();
            SetupMainContentPanel();
            Controls.Add(headerPanel);
        
            Controls.Add(mainContentPanel);
            Controls.Add(sidebarPanel);
        }
        private void SetupMainContentPanel()
        {
            // Main Content Panel
            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,

            };

            // Stats Panel
            statsPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new System.Drawing.Point(10, 100),
                Height = 120,
                BackColor = Color.Transparent,
            };
            var res = _revenueCalculator.TileNowToMonth(2024);

           
            // Example usage:
            AddStatCard("Total Sales", res.revenue.ToString("C", new CultureInfo("en-US")), $"{((res.tile - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tile - 1) * 100):0.00}% from last month");

            AddStatCard("New Customers", res.countUser.ToString(), $"{((res.tileUser - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileUser - 1) * 100):0.00}% from last year");
            AddStatCard("Resolve Issues", res.numIssues.ToString(), $"{((res.tileIssuel - 1) * 100 > 0 ? "↑" : "↓")} {Math.Abs((res.tileIssuel - 1) * 100):0.00}% from last year");

            // Add Controls to Main Content Panel
            mainContentPanel.Controls.Add(statsPanel);
            mainContentPanel.Controls.Add(InitialChartLayout());
            mainContentPanel.Controls.Add(InitializeFooter());

            // Add Main Content Panel to Form Controls
            Controls.Add(mainContentPanel);
        }

    

        private void SetupMenuPanel()
        {
            menuPanel = new Panel
            {
                Top = 170,
                Left = 0,
                Width = sidebarPanel.Width,
                Height = Height,
                AutoScroll = true
            };

            string[] menuItems = new string[] {
        "Dashboard", "Inventory", "Repair Tracker",
        "Customers", "Bookings", "Staff Management"
    };

            int buttonTop = 0;
            foreach (string item in menuItems)
            {
                Button menuButton = CreateMenuButton(item, buttonTop);
                if (item == "Dashboard")
                {
                    lastClickedButton = menuButton;
                    menuButton.BackColor = Color.FromArgb(250, 204, 21); // Active color for Dashboard
                    menuButton.ForeColor = Color.White;
                }

                menuPanel.Controls.Add(menuButton);
                buttonTop += menuButton.Height + 5;
            }

            sidebarPanel.Controls.Add(menuPanel);
        }

        private Button lastClickedButton = null; // To track the last clicked button

        private Button CreateMenuButton(string text, int top)
        {
            Button button = new Button
            {
                Text = text,
                Width = sidebarPanel.Width - 20,
                Height = 45,
                Left = 10,
                Top = top,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            button.FlatAppearance.BorderSize = 0;
            button.BackColor = (text == "Dashboard") ? Color.FromArgb(250, 204, 21) : Color.White;
            button.ForeColor = (text == "Dashboard") ? Color.White : Color.FromArgb(64, 64, 64);

            // Hover effect
            button.MouseEnter += (s, e) =>
            {
                if (button != lastClickedButton) // Don't highlight if it's the last clicked button
                    button.BackColor = Color.FromArgb(249, 250, 251);

                button.ForeColor = Color.White; // Text stays white on hover
            };

            button.MouseLeave += (s, e) =>
            {
                if (button != lastClickedButton) // Don't revert if it's the last clicked button
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.FromArgb(64, 64, 64); // Default text color
                }
            };

            // Click event for the button
            button.Click += (s, e) =>
            {
                if (lastClickedButton == button)
                {
                    // If this button is already active, do nothing
                    return;
                }

                // Reset the previous active button's color if it exists
                if (lastClickedButton != null && lastClickedButton != button)
                {
                    lastClickedButton.BackColor = Color.White;
                    lastClickedButton.ForeColor = Color.FromArgb(64, 64, 64); // Default text color
                }

                // Set the current button as active
                button.BackColor = Color.FromArgb(250, 204, 21); // Active background color
                button.ForeColor = Color.White; // Active text color

                // Update the last clicked button
               
                lastClickedButton = button;
                switch (text)
                {
                    case "Dashboard":
                        // Do something for option 1
                        MessageBox.Show("Option 1 clicked");
                        break;
                    case "Inventory":
                        // Do something for option 2
                        MessageBox.Show("Option 2 clicked");
                        break;
                    case "Repair Tracker":
                        // Do something for option 3
                        MessageBox.Show("Option 3 clicked");
                        break;
                    case "Customers":
                        // Do something for option 3
                        MessageBox.Show("Option 3 clicked");
                        break;
                    case "Bookings":
                        // Do something for option 3
                        MessageBox.Show("Option 3 clicked");
                        break;
                    case "Staff Management":
                        // Do something for option 3
                        MessageBox.Show("Option 3 clicked");
                        break;
                    default:
                        MessageBox.Show($"{text} clicked");
                        break;
                }
            };

            return button;
        }

        private void InitializeHeader()
        {
            // Panel chứa Header
            headerPanel = new Panel
            {
                Width = this.Width,
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(10, 10, 10, 10)
            };

            // Welcome message label
            Label welcomeLabel = new Label
            {
                Text = "Hi, User\nLet's check your average today",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(25, 15),
                Width = 200,
                Height = 60,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
            };
            headerPanel.Controls.Add(welcomeLabel);

          

            // PictureBox for the user icon (positioned at the far right of headerPanel)
            PictureBox pbUser = new PictureBox
            {
                Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\logout.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 30,
                Height = 30,
            };

            // Thêm PictureBox vào headerPanel
            headerPanel.Controls.Add(pbUser);
            pbUser.Click += pbUser_Click;
         
            // PictureBox for the notification icon (positioned to the left of the user icon)
            PictureBox pbNotifications = new PictureBox
            {
                Image = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\notification.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 30,
                Height = 30,
                Location = new Point(pbUser.Left - 60, 25)  // Positioned left of the user icon
            };
            pbNotifications.Click += pbNotifications_Click;
            pbNotifications.MouseEnter += pbNotifications_MouseEnter;
            pbNotifications.MouseLeave += pbNotifications_MouseLeave;
            // Đăng ký sự kiện Resize cho headerPanel
            headerPanel.Resize += (s, e) =>
            {
                // Cập nhật vị trí của pbUser mỗi khi headerPanel thay đổi kích thước
                pbUser.Location = new Point(headerPanel.Width - pbUser.Width - 30, 25); // 10 là khoảng cách từ cạnh phải

                // Cập nhật vị trí của pbNotifications để nó nằm bên trái pbUser
                pbNotifications.Location = new Point(pbUser.Left - pbNotifications.Width - 20, 25); // 10 là khoảng cách giữa pbNotifications và pbUser
            };

       
            headerPanel.Controls.Add(pbNotifications);
            headerPanel.Controls.Add(pbUser);

            // Add the header panel to the form
            this.Controls.Add(headerPanel);

        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Sự kiện khi click vào icon người dùng
        private void pbNotifications_MouseEnter(object sender, EventArgs e)
        {
            dropdownPanel.Visible = true;  // Hiển thị panel
        }

        // Khi người dùng rời chuột ra khỏi nút
        private void pbNotifications_MouseLeave(object sender, EventArgs e)
        {
            dropdownPanel.Visible = false;  // Ẩn panel
        }

        // Khi người dùng click vào nút
        private void pbNotifications_Click(object sender, EventArgs e)
        {
            // Toggle dropdown visibility khi click
            dropdownPanel.Visible = !dropdownPanel.Visible;
        }

        // Sự kiện khi click vào icon thông báo
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
            mainContentPanel.Resize += (s, e) =>
            {
                // Cập nhật chiều rộng của statsPanel khi mainContentPanel thay đổi kích thước
                statsPanel.Width = mainContentPanel.ClientSize.Width - 20;

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
        private Panel InitialChartLayout()
        {
            var mainLayout = new TableLayoutPanel
            {
                Location = new Point(20, 250),
                ColumnCount = 2,
                RowCount = 2,
                AutoSize = false,
                Dock = DockStyle.None,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            mainContentPanel.Resize += (s, e) =>
            {
                mainLayout.Width = mainContentPanel.ClientSize.Width - 40;
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

            // Add title
            chart.Titles.Add(new Title("Monthly Revenue", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            Series series = new Series
            {
                Name = "Revenue",
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(250, 204, 21),
                BorderWidth = 0
            };

            // Add sample data
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
              
                .Sum(x => x.Revenue)*100;
             decimal restotal= totalRevenue + totalParts;
            
           
            // Add data points with custom colors
            DataPoint servicesPoint = new DataPoint();
            servicesPoint.SetValueY(totalRevenue/restotal);
            servicesPoint.Color = Color.FromArgb(250, 204, 21);
            servicesPoint.Label = $"Services ({((totalRevenue / restotal) * 100):F2}%)";
            series.Points.Add(servicesPoint);

            DataPoint partsPoint = new DataPoint();
            partsPoint.SetValueY((totalParts/restotal));
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

                yPosition +=35;  // Increase yPosition for the next label, considering label height
                index++;  // Increment color index for the next color
            }

        
        chart.Controls.Add(colorLegendPanel);  // Assuming you're working in a Windows Form
            return chart;
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




        private Panel InitializeFooter()
        {
            // Tạo một Panel cho footer
            var footerPanel = new Panel
            {
                Width = this.Width - 250,
                Dock = DockStyle.Bottom,
                Height = 80, // Chiều cao của footer
                BackColor = System.Drawing.Color.White // Màu nền của footer
            };

            // Thêm Label vào footer
            var footerLabel = new Label
            {
                Text = "© 2024 Garage Management System. All rights reserved. | Contact: info@garage.com | Follow us on social media.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter, // Căn giữa văn bản
                AutoSize = false,
                ForeColor = System.Drawing.Color.Black
            };

            // Thêm Label vào Panel
            footerPanel.Controls.Add(footerLabel);

            // Trả về Panel footer
            return footerPanel;
        }
        private void OpenDashBoard(object sender, EventArgs e)
        {
            // Logic to open the dashboard
        }

      
    }
}
