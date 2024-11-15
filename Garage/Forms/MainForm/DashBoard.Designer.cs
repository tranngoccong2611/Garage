using DocumentFormat.OpenXml.Spreadsheet;
using Garage.Data;
using Garage.Forms.MainForm.Dictionary;
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
 
        private Panel headerPanel;
        private Panel mainContentPanel;
        private Panel sidebarPanel;
        private Panel lblLogo;
        private Panel menuPanel;
     
        private Panel dropdownPanel;
        private Label dropdownLabel;

     

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
            Controls.Add(sidebarPanel);
        
        }
    
  
        private void SetupMainContentPanel()
        {
            // Main Content Panel
            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,    // Đảm bảo panel này chiếm toàn bộ không gian còn lại
                AutoScroll = true,
                BackColor = Color.Transparent,
            };

            // Khởi tạo DashboardControl và thiết lập nó để chiếm toàn bộ diện tích
            //DashboardControl dashboardControl = new DashboardControl(_revenueCalculator, _contextOptions);
            DashboardControl inven = new DashboardControl(_revenueCalculator,_contextOptions);
            // Đảm bảo dashboardControl fill toàn bộ mainContentPanel
            mainContentPanel.Controls.Add(inven);   
           inven.Dock = DockStyle.Fill;
            // Thêm mainContentPanel vào Controls của form để nó hiển thị
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
                    SetButtonActiveStyle(menuButton); // Use method to set active style
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
                if (button != lastClickedButton)
                    button.BackColor = Color.FromArgb(249, 250, 251);

                button.ForeColor = Color.White;
            };

            button.MouseLeave += (s, e) =>
            {
                if (button != lastClickedButton)
                {
                    ResetButtonStyle(button);
                }
            };

            // Click event for the button
            button.Click += (s, e) =>
            {
                if (lastClickedButton == button) return;

                // Reset the previous active button's color if it exists
                if (lastClickedButton != null)
                {
                    ResetButtonStyle(lastClickedButton);
                }

                // Set the current button as active
                SetButtonActiveStyle(button);
                lastClickedButton = button;

                // Load the corresponding control into mainContentPanel
                LoadControlForMenu(text);
            };

            return button;
        }

        private void SetButtonActiveStyle(Button button)
        {
            button.BackColor = Color.FromArgb(250, 204, 21);
            button.ForeColor = Color.White;
        }

        private void ResetButtonStyle(Button button)
        {
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void LoadControlForMenu(string text)
        {
            switch (text)
            {
                case "Dashboard":
                    DisplayControl(new DashboardControl(_revenueCalculator,_contextOptions));
                    break;
                case "Inventory":
                    DisplayControl(new InventoryControl(_contextOptions,_transactionInventory));
                    break;
                case "Repair Tracker":
                    DisplayControl(new RepairTrackerControl(_contextOptions,trackerRepairUtils));
                    break;
                case "Customers":
                    DisplayControl(new BookingsControl());
                    break;
                case "Bookings":
                    DisplayControl(new CustomersControl());
                    break;
                case "Staff Management":
                    DisplayControl(new StaffManagementControl());
                    break;
                  
                default:
                    MessageBox.Show($"{text} clicked");
                    break;
            }
        }

        private void DisplayControl(UserControl control)
        {
            mainContentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            AutoSize = true;
            AutoScroll = true;
            Width = SystemInformation.WorkingArea.Width - 200;
            Height = Height;
            mainContentPanel.Controls.Add(control);
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
      
    }
}
