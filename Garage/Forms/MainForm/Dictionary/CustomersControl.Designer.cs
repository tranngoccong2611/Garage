using DocumentFormat.OpenXml.Spreadsheet;
using Garage.Common.Enum;
using Garage.Common.Extension;
using Garage.Common.Utils.Helper;
using Garage.Data;
using Garage.Data.Models;
using Garage.Forms.Style;
using GaraOto.Common.Utilities.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;

namespace Garage.Forms.MainForm.Dictionary
{
    partial class CustomersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button Customer;
        private Button Booking;
        private Button ExportExcel;
        private Button Weekly;
        private Button ExportPDF;
        private DataGridView gridviewUser;
        private DataGridView gridviewBook;
        private Panel  Wrap;
        private List<Users> listUsers;
        private Button AllBook;
        int widthSearchPanel = (SystemInformation.WorkingArea.Width - 250) * 5 / 6;
        private Panel searchPanel;
        private TextBox searchBox;
        private string searchQuery;
        private Label lblPageInfo;
        private int currentPage = 1;
        private int pageSize = 10; 
        private Panel suggestPanel;
        private const int MAX_SUGGESTIONS = 5;
        private const int SUGGESTION_ITEM_HEIGHT = 50;
        private int page=1;
        private List<Bookcar> listBookCar;
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
            listBookCar=_bookings.GetPersonList();
            components = new System.ComponentModel.Container();
            gridviewUser = new DataGridView();
            Wrap =new Panel();
            gridviewBook = new DataGridView();
             Wrap.Width = widthSearchPanel+20;
            listUsers = _getCutomer.GetAllUsers();
            Weekly = new Button();
            Wrap.Height = (int)(SystemInformation.WorkingArea.Height - 100) * 6 / 7;
             Wrap.Location = new Point((int)( (SystemInformation.WorkingArea.Width-250)- widthSearchPanel-20) /2,(int)(SystemInformation.WorkingArea.Height- (int)(SystemInformation.WorkingArea.Height - 100) * 4 / 5)/2-40);
            Controls.Add( Wrap);
            Wrap.Controls.Add( gridviewUser );
            Header();
            InitSearch(widthSearchPanel);
            GridViewUser();
            GridViewBook();
            InitTransactionParts(listUsers,gridviewUser);
         
        }
        private void Header()
        {
            Customer = new Button();
            Customer.Text = "Customer";
            Customer.Click += Customer_Click;
            Customer.Width = 70;
            Customer.Height = 40;
            Customer.BackColor=Color.White;
            Customer.Location = new System.Drawing.Point(20,20);
            Booking =new Button();
            Booking.Text = "Bookings";
            Booking.Width=70
                ; Booking.Height = 40;
            Booking.BackColor = Color.White;
            Booking.ForeColor = Color.Black;
            Customer.ForeColor = Color.Black;
            Customer.FlatStyle = FlatStyle.Flat;
            Customer.FlatAppearance.BorderSize = 0; // Xóa viền button
            Booking.FlatStyle = FlatStyle.Flat;
            Booking.FlatAppearance.BorderSize = 0; // Xóa viền button
           Booking.Click += Booking_click;
            Booking.Location = new Point(Customer.Right+20,Customer.Location.Y);

            ExportExcel=new Button();
            ExportExcel.Text = "Export To Excel";
            ExportExcel.Width = 150;
            ExportExcel.Height = 40;
            ExportExcel.BackColor = Color.ForestGreen;
            ExportExcel.Click += ExportExcel_Click;
            ExportExcel.ForeColor = Color.White;
            ExportExcel.Location = new System.Drawing.Point( Wrap.Width-150,Customer.Location.Y);

            AllBook = new Button();
            AllBook.Text = "all";
            AllBook.Width = 70;
            AllBook.Height = 40;
            AllBook.BackColor = Color.White;
            AllBook.ForeColor = Color.Black;
            AllBook.Location = new Point(Wrap.Width - 70, Customer.Location.Y);
            Weekly=new Button();
            Weekly.Text = "Weekly";
            Weekly.Width = 70;
            Weekly.Height = 40;
            Weekly.BackColor = Color.White;
            Weekly.ForeColor = Color.Black;
            Weekly.Location = new Point(AllBook.Left-100,AllBook.Location.Y);
            AllBook.Click += AllBook_Click;
             Wrap.Controls.Add(Customer);
            Weekly.Click += Weekly_Click;
             Wrap.Controls.Add(Booking);
             Wrap.Controls.Add(ExportExcel);
            
       
        }

        private void Weekly_Click(object sender, EventArgs e)
        {
           gridviewBook.Rows.Clear();
            listBookCar = _bookings.GetPersonList();
            InitBooking(listBookCar,gridviewBook);
        }

        private void AllBook_Click(object sender, EventArgs e)
        {
            gridviewBook.Rows.Clear();
            listBookCar = _bookings.getAll();
            InitBooking(listBookCar, gridviewBook);
        }

        private void GridViewBook()
        {
            gridviewBook.Width = widthSearchPanel;
            gridviewBook.Height = SystemInformation.WorkingArea.Height - 60 - 60 - 40;
            gridviewBook.Location = new Point(Customer.Location.X, Customer.Bottom + 10);

            gridviewBook.GridColor = Color.Gray;  // Đảm bảo không có đường kẻ giữa các ô
            gridviewBook.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            gridviewBook.Padding = new Padding(20);
            gridviewBook.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridviewBook.RowHeadersVisible = false;
            gridviewBook.AllowUserToAddRows = false;
            gridviewBook.AllowUserToDeleteRows = false;
            gridviewBook.ReadOnly = true;
            gridviewBook.ScrollBars = ScrollBars.None;
            gridviewBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridviewBook.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            gridviewBook.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridviewBook.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            gridviewBook.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            gridviewBook.ColumnHeadersHeight = 40;
            gridviewBook.RowsDefaultCellStyle.BackColor = Color.White;
            gridviewBook.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            gridviewBook.AllowUserToResizeRows = false;
            gridviewBook.AllowUserToResizeColumns = false;
            gridviewBook.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            gridviewBook.DefaultCellStyle.SelectionForeColor = gridviewBook.DefaultCellStyle.ForeColor;
            gridviewBook.BackgroundColor = Color.White;
            gridviewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridviewBook.MultiSelect = false;
            gridviewBook.ReadOnly = true;

            gridviewBook.RowTemplate.Height = 45;

           

            if (gridviewBook.Columns["No"] == null)
            {
                var sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "No";
                sttColumn.HeaderText = "No";
                sttColumn.Width = 30; // Adjust width for No column
                gridviewBook.Columns.Insert(0, sttColumn); // Insert at the first column
            }
           

            gridviewBook.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn { Name = "Customer Name", HeaderText = "Customer" },
                    new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone" },
                    new DataGridViewTextBoxColumn { Name = "Car", HeaderText = "Car" },
                    new DataGridViewTextBoxColumn { Name = "Time", HeaderText = "Time" },
                    new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" },
                });
          var Approve=  new DataGridViewButtonColumn
            {
                Name = "Approve",
                HeaderText = "Approve",
                Text = "Approve",
                UseColumnTextForButtonValue = true
            };
            var Reject = new DataGridViewButtonColumn
            {
                Name = "Reject",
                HeaderText = "Reject",
                Text = "Reject",
                UseColumnTextForButtonValue = true,
                Width = 80,
                
            };
            gridviewBook.Columns.Add(Approve);
            gridviewBook.Columns.Add(Reject);
            gridviewBook.ColumnHeadersHeight = 40;
            gridviewBook.CellClick += GridviewBook_CellClick;
            // Thêm sự kiện painting để tùy chỉnh hiển thị
         
            foreach (DataGridViewColumn column in gridviewBook.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa số liệu
            }
            foreach (DataGridViewRow row in gridviewBook.Rows)
            {
                var buttonCell = row.Cells["Approve"] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    // Tính toán chiều rộng và chiều cao của nút chiếm 3/4 chiều rộng và chiều cao của ô
                    int width = gridviewBook.Columns["Approve"].Width * 3 / 5; // Adjust width slightly for padding
                    int height = gridviewBook.RowTemplate.Height * 3 / 5; // Adjust height for better alignment

                    // Tính toán padding để căn giữa nút
                    int horizontalPadding = (gridviewBook.Columns["Approve"].Width - width) / 2;
                    int verticalPadding = (gridviewBook.RowTemplate.Height - height) / 2;

                    // Căn giữa nút trong cột "Update" với padding tính toán động
                    buttonCell.Style.Padding = new Padding(horizontalPadding, verticalPadding, horizontalPadding, verticalPadding);


                    buttonCell.Style.ForeColor = Color.Black;
                    buttonCell.Style.SelectionBackColor = Color.AliceBlue;
                    buttonCell.Style.SelectionForeColor = Color.Black;
                    buttonCell.Style.Font = new Font("Arial", 10); // Đặt font cho nút

                }
                var buttonCellReject = row.Cells["Reject"] as DataGridViewButtonCell;
                if (buttonCellReject != null)
                {
                    // Tính toán chiều rộng và chiều cao của nút chiếm 3/4 chiều rộng và chiều cao của ô
                    int width = gridviewBook.Columns["Reject"].Width * 3 / 5; // Adjust width slightly for padding
                    int height = gridviewBook.RowTemplate.Height * 3 / 5; // Adjust height for better alignment

                    // Tính toán padding để căn giữa nút
                    int horizontalPadding = (gridviewBook.Columns["Reject"].Width - width) / 2;
                    int verticalPadding = (gridviewBook.RowTemplate.Height - height) / 2;

                    // Căn giữa nút trong cột "Update" với padding tính toán động
                    buttonCellReject.Style.Padding = new Padding(horizontalPadding, verticalPadding, horizontalPadding, verticalPadding);


                    buttonCellReject.Style.ForeColor = Color.Black;
                    buttonCellReject.Style.SelectionBackColor = Color.AliceBlue;
                    buttonCellReject.Style.SelectionForeColor = Color.Black;
                    buttonCellReject.Style.Font = new Font("Arial", 10); // Đặt font cho nút

                }

            }

        }
      
        private void GridviewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải click vào cell nút không và có phải dòng hợp lệ không
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == gridviewBook.Columns["Approve"].Index)
            {
                // Xử lý click nút Approve
                Approve_Click(sender, e);
            }
            else if (e.ColumnIndex == gridviewBook.Columns["Reject"].Index)
            {
                // Xử lý click nút Reject
                Reject_Click(sender, e);
            }
            // Lấy ID của booking được chọn
          

            // Nếu trạng thái hiện tại không phải là Pending thì return
             
            
        }

  
    
    private void Approve_Click(object sender, EventArgs e)
        {   // Xử lý nút Approve
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn Approve booking này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                int bookingId = GetSelectedBookingId(); // Lấy ID từ dòng được chọn trong GridView
                MessageBox.Show(""+bookingId);
                BookingCar.UpdateBookingStatus(bookingId, _db, StatusCarMaintaince.Approve);
                LoadData(); // Refresh lại data
            }
        
          
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            int bookingId = GetSelectedBookingId();
            BookingCar.UpdateBookingStatus(bookingId, _db,StatusCarMaintaince.Completed);
            LoadData();
        }
            private void Reject_Click(object sender, EventArgs e)
            {
            // Xử lý nút Reject
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn Reject booking này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int bookingId = GetSelectedBookingId();
                BookingCar.UpdateBookingStatus(bookingId, _db,StatusCarMaintaince.Reject);
                LoadData(); // Refresh lại data
            }     
            
        }
     
        private void LoadData()
        {
            gridviewBook.Rows.Clear();
            listBookCar = _bookings.GetPersonList();
            InitBooking(listBookCar, gridviewBook);
        }
        private int GetSelectedBookingId()
        {

            var phone = gridviewBook.SelectedRows[0].Cells["Phone"].Value.ToString();

            int result = _db.DatLichBaoDuongXe
     .Where(x => x.NguoiDung.SoDienThoai == phone&&x.TrangThai==StatusCarMaintaince.Pending.GetStatusName())
     .Select(x => x.DatLichBaoDuongID)
     .FirstOrDefault();

            return result;        
          
        }
        private void Booking_click(object sender, EventArgs e)
        {
            gridviewBook.Rows.Clear();
           listBookCar=_bookings.GetPersonList();
            InitBooking(listBookCar,gridviewBook);
            Wrap.Controls.Add(Weekly);
            Wrap.Controls.Remove(gridviewUser);
            Wrap.Controls.Add(gridviewBook);
            Wrap.Controls.Remove(searchPanel);
            Wrap.Controls.Remove(ExportExcel);
            Wrap.Controls.Add(AllBook);
        }

        private void InitSearch(int widthSearchPanel)
        {
            searchPanel = new Panel
            {
                Width = widthSearchPanel,
                Location = new Point(Customer.Location.X,
                Customer.Bottom+10),
                Height = 60,
            };

            var searchContainer = new CustomPanel
            {
                Height = 40,
                Width = widthSearchPanel-20,
                Location = new Point(0, 10),
                BackColor = Color.White,
                BorderRadius = 8
            };

            Image searchImagePath = Image.FromFile(@"D:\btlWinform\Garage\Garage\Resources\Icons\icon_search.png");
            Panel icon = new Panel
            {
                BackgroundImage = searchImagePath,
                BackgroundImageLayout = ImageLayout.Stretch,
                Height = 25,
                Width = 25,
                Location = new Point(10, 10),
            };
            searchContainer.Controls.Add(icon);

            searchBox = new TextBox
            {
                Width = searchContainer.Width - 100,
                Height = 40,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(45, 10),
                PlaceholderText = "Search UserCar",
                Font = new Font("Segoe UI", 12)
            };
            Button btnImage = new Button();
            btnImage.Location = new Point(searchBox.Right + 20, 10);
            btnImage.Width = 20;
            btnImage.Height = 20;
            btnImage.FlatStyle = FlatStyle.Flat; // Loại bỏ các hiệu ứng 3D
            btnImage.FlatAppearance.BorderSize = 0; // Xóa đường viền
            btnImage.BackColor = Color.Transparent; // Nền trong suốt (nếu cần)
            btnImage.TabStop = false;
            // Tải ảnh và thay đổi kích thước
            using (Image originalImage = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\exit.png"))
            {
                Image resizedImage = new Bitmap(originalImage, new Size(20, 20));
                btnImage.Image = resizedImage;
            }

            // Căn giữa ảnh trong nút
            btnImage.ImageAlign = ContentAlignment.MiddleCenter;

            // Sự kiện click cho nút ảnh để xóa nội dung tìm kiếm
            btnImage.Click += (sender, e) =>
            {
                searchQuery = "";           // Xóa nội dung trong biến `searchQuery`
                searchBox.Text = "";
                // Xóa nội dung trong `searchBox`
                gridviewUser.Rows.Clear();

                
     
                listUsers = _getCutomer.GetAllUsers();
                InitTransactionParts(listUsers,gridviewUser);
              
            };
            searchContainer.Controls.Add(btnImage); // Thêm nút vào Form

            searchBox.TextChanged += SearchBox_TextChanged;



            searchPanel.Controls.Add(searchContainer);

            searchContainer.Controls.Add(searchBox);

             Wrap.Controls.Add(searchPanel);
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            searchQuery = searchBox.Text.Trim();
            if (searchQuery.Length >= 1) // Chỉ hiện gợi ý khi nhập ít nhất 1 ký tự
            {
                FilterIssues(searchQuery);
            }
            else if (suggestPanel != null &&  Wrap.Controls.Contains(suggestPanel))
            {
                 Wrap.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();

            }
        }
        private void FilterIssues(string searchQuery)
        {
            // Xóa panel gợi ý cũ nếu tồn tại
            if (suggestPanel != null &&  Wrap.Controls.Contains(suggestPanel))
            {
                 Wrap.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();
            }

            if (string.IsNullOrEmpty(searchQuery))
                return;
            suggestPanel = new Panel
            {
                Width = searchBox.Width,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(searchPanel.Location.X + 20, searchPanel.Bottom),
                AutoScroll = false,
                Height = 150
            };

            // Xử lý cuộn bằng con lăn chuột
            suggestPanel.MouseWheel += (sender, e) =>
            {
                // Kiểm tra hướng cuộn
                if (e.Delta > 0)
                {
                    // Cuộn lên
                    suggestPanel.Top += 10;
                }
                else
                {
                    // Cuộn xuống
                    suggestPanel.Top -= 10;
                }
            };

            // Lấy danh sách người dùng phù hợp với tìm kiếm
            var matchingUsers = _db.NguoiDung
                .Where(u => u.HoTen.ToLower().Contains(searchQuery.ToLower()) ||
                            u.SoDienThoai.Contains(searchQuery))
                .Take(MAX_SUGGESTIONS)
                .ToList();

            int yPos = 0;
            foreach (var user in matchingUsers)
            {
                Panel userItem = CreateSuggestionItem(user, yPos);
                suggestPanel.Controls.Add(userItem);
                yPos += SUGGESTION_ITEM_HEIGHT;
            }

            // Điều chỉnh chiều cao của panel gợi ý
            suggestPanel.Height = Math.Min(yPos, MAX_SUGGESTIONS * SUGGESTION_ITEM_HEIGHT);

             Wrap.Controls.Add(suggestPanel);
            suggestPanel.BringToFront();
        }
        private Panel CreateSuggestionItem(NguoiDung user, int yPosition)
        {
            Panel item = new Panel
            {
                Width = suggestPanel.Width - 4,
                Height = SUGGESTION_ITEM_HEIGHT,
                Location = new Point(2, yPosition),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            Label nameLabel = new Label
            {
                Text = user.HoTen,
                Font = new Font("Segoe UI", 11),
                Location = new Point(10, 5),
                AutoSize = true
            };

            Label phoneLabel = new Label
            {
                Text = user.SoDienThoai,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(10, 28),
                AutoSize = true
            };

            item.Controls.AddRange(new Control[] { nameLabel, phoneLabel });

            // Thêm hiệu ứng hover
            item.MouseEnter += (s, e) => item.BackColor = Color.FromArgb(240, 240, 240);
            item.MouseLeave += (s, e) => item.BackColor = Color.White;

            item.Click += (s, e) =>
            {
                searchBox.Text = $"{user.HoTen} - {user.SoDienThoai}";
                gridviewUser.Rows.Clear();
                listUsers = _getCutomer.GetUsers(user.SoDienThoai);
                InitTransactionParts(listUsers, gridviewUser);

                // Xóa và hủy suggestion panel
                if (Wrap.Controls.Contains(suggestPanel))
                {
                    Wrap.Controls.Remove(suggestPanel);
                    suggestPanel.Dispose();
                }
            };



            return item;
        }
      
        private void GridViewUser()
        {

            gridviewUser.Width = widthSearchPanel;
            gridviewUser.Height = SystemInformation.WorkingArea.Height-60-60-40;
            gridviewUser.Location=new Point(Customer.Location.X, searchPanel.Bottom+10);
       
            gridviewUser.GridColor = Color.Gray;  // Đảm bảo không có đường kẻ giữa các ô
            gridviewUser.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
  
            gridviewUser.Padding = new Padding(20);
            gridviewUser.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridviewUser.RowHeadersVisible = false;
            gridviewUser.AllowUserToAddRows = false;
            gridviewUser.AllowUserToDeleteRows = false;
            gridviewUser.ReadOnly = true;
            gridviewUser.ScrollBars = ScrollBars.None;
            gridviewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridviewUser.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            gridviewUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridviewUser.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray; 
            gridviewUser.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black; 
            gridviewUser.ColumnHeadersHeight = 40;
            gridviewUser.RowsDefaultCellStyle.BackColor = Color.White;  
            gridviewUser.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; 
            gridviewUser.AllowUserToResizeRows = false;
            gridviewUser.AllowUserToResizeColumns = false;
            gridviewUser.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            gridviewUser.DefaultCellStyle.SelectionForeColor = gridviewUser.DefaultCellStyle.ForeColor;
            gridviewUser.BackgroundColor = Color.White;
            gridviewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridviewUser.MultiSelect = false;
            gridviewUser.ReadOnly = true;

            gridviewUser.RowTemplate.Height = 45;
           
            if (gridviewUser.Columns["HinhAnh"] == null)
            {
                var imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "HinhAnh";
                imageColumn.HeaderText = "Image";
                imageColumn.Width = 60;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Customize image layout
                gridviewUser.Columns.Insert(0, imageColumn); // Insert at the first column
            }

            if (gridviewUser.Columns["No"] == null)
            {
                var sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "No";
                sttColumn.HeaderText = "No";
                sttColumn.Width = 30; // Adjust width for No column
                gridviewUser.Columns.Insert(0, sttColumn); // Insert at the first column
            }
            gridviewUser.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn { Name = "Customer Name", HeaderText = "Customer Name" },
                    new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email" },
                    new DataGridViewTextBoxColumn { Name = "Location", HeaderText = "Location" },
                    new DataGridViewTextBoxColumn { Name = "Orders", HeaderText = "Orders" },
                    new DataGridViewTextBoxColumn { Name = "Spent", HeaderText = "Spent" },
                });

            gridviewUser.ColumnHeadersHeight = 40;
        
        }
        private void InitTransactionParts(List<Users> listsDetail, DataGridView gridViewparts)
        {
    
            int index = 1;
            foreach (var item in listsDetail)
            {
                // Load the image for the part, handling missing or invalid paths
                Image partImage;
                try
                {
                    if (!string.IsNullOrEmpty(item.ImageUser) && File.Exists(item.ImageUser))
                    {
                        partImage = Image.FromFile(item.ImageUser);
                    }
                    else
                    {
                        partImage = Image.FromFile("D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png");

                    }

                    partImage = new Bitmap(partImage, new Size(50, 50));
                    partImage = ImageRouded.CreateRoundedImage(partImage, 10); // Assuming you have this method
                }
                catch
                {
                    partImage = new Bitmap(50, 50); // Default blank image if loading fails
                }

                // Add the row to the DataGridView
                gridViewparts.Rows.Add(index, partImage, item.UserName,item.Mail,item.Address,item.numsOrders,item.totalMoneyUse);
                index++;


            }
            // Ensure button column moves with the rows when scrolling
            gridViewparts.Refresh();
            

            // Disable sorting on all columns
            foreach (DataGridViewColumn column in gridViewparts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            foreach (DataGridViewColumn column in gridViewparts.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa số liệu
            }
         
            //gridViewparts.CellStateChanged += gridViewparts_CellStateChanged;
            gridViewparts.MouseWheel += (s, args) =>
            {
                // Kiểm tra nếu bảng có thể cuộn và xử lý cuộn chuột
                if (args.Delta > 0)
                {
                    // Cuộn lên
                    if (gridViewparts.FirstDisplayedScrollingRowIndex > 0)
                    {
                        gridViewparts.FirstDisplayedScrollingRowIndex -= 1;
                    }
                }
                else
                {
                    // Cuộn xuống
                    if (gridViewparts.FirstDisplayedScrollingRowIndex < gridViewparts.RowCount - 1)
                    {
                        gridViewparts.FirstDisplayedScrollingRowIndex += 1;
                    }
                }
            };
          
        }


        private void InitBooking(List<Bookcar> listsDetail, DataGridView gridViewparts)
        {

            int index = 1;
            foreach (var item in listsDetail)
            {
                // Load the image for the part, handling missing or invalid paths


                // Add the row to the DataGridView
                gridViewparts.Rows.Add(index,  item.nameCustomer, item.phone, item.Brand+item.Model, item.time,  DateOnly.FromDateTime(item.date??DateTime.Now));
                index++;


            }
            // Ensure button column moves with the rows when scrolling
            gridViewparts.Refresh();


            // Disable sorting on all columns
            foreach (DataGridViewColumn column in gridViewparts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            foreach (DataGridViewColumn column in gridViewparts.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa số liệu
            }

            //gridViewparts.CellStateChanged += gridViewparts_CellStateChanged;
            gridViewparts.MouseWheel += (s, args) =>
            {
                // Kiểm tra nếu bảng có thể cuộn và xử lý cuộn chuột
                if (args.Delta > 0)
                {
                    // Cuộn lên
                    if (gridViewparts.FirstDisplayedScrollingRowIndex > 0)
                    {
                        gridViewparts.FirstDisplayedScrollingRowIndex -= 1;
                    }
                }
                else
                {
                    // Cuộn xuống
                    if (gridViewparts.FirstDisplayedScrollingRowIndex < gridViewparts.RowCount - 1)
                    {
                        gridViewparts.FirstDisplayedScrollingRowIndex += 1;
                    }
                }
            };

        }



        private void ExportExcel_Click(object sender, EventArgs e)
        {
            // Ví dụ sử dụng
            var data = listUsers; // Lấy dữ liệu cần xuất
            string filePath = ExcelHelper.ExportToExcel(
                data,
                "DanhSachNguoiDung",
                @"D:\ExcelExports"
            );
            // File sẽ được lưu với tên kiểu: DanhSachNhanVien_20241116_143022.xlsx

            // Display a success message to the user
            MessageBox.Show("Excel file exported successfully!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            Wrap.Controls.Remove(gridviewBook);
            Wrap.Controls.Add(gridviewUser);
            Wrap.Controls.Add(searchPanel);
            Wrap.Controls.Add(ExportExcel);
            Wrap.Controls.Remove(AllBook);
            Wrap.Controls.Remove(Weekly);
        }
       
      
        #endregion
    }
}
