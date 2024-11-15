using DocumentFormat.OpenXml.Wordprocessing;
using Garage.Common.Extension;
using Garage.Data.Models;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
public class LinhKienItem
{
    public int LinhKienId { get; set; }
    public string TenLinhKien { get; set; }

    public override string ToString()
    {
        return TenLinhKien; // Hiển thị tên linh kiện trong ComboBox
    }
}

namespace Garage.Forms.MainForm
{
    partial class InventoryControl
    {
        private System.ComponentModel.IContainer components = null;
        private TransactionInventory _inventory;
        private RoundedPanel mainContentParts;
        private Button Parts;
        private Button Transactions;
        private Button Add;
        private DataGridView gridViewparts;
        private Panel menuPartsPanel;
        private ComboBox listPartsBox;
        private List<LinhKien> lists;
        private List<TransactionQuery> listTransactionQUery;
        private List<LinhKien> AllList;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private DataGridView TransactionTables;
        private List<TransactionQuery> AlllistTransactionQUery;
        private Label PartsContent;
        private Label StartDate;
        private Label EndDate;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            startDate = new DateTimePicker();
            endDate = new DateTimePicker();
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.CustomFormat = "dd/MM/yyyy";
            startDate.MinDate = new DateTime(2023, 1, 1);
            startDate.MaxDate = DateTime.Now;
            startDate.Value = new DateTime(2023, 1, 1); // Đặt ngày mặc định là 1/1/2023
            startDate.Width = 150;
            startDate.ValueChanged += EndDate_Changed;
            endDate.Width = 150;
            startDate.DropDownAlign = LeftRightAlignment.Left;
            endDate.Format = DateTimePickerFormat.Custom;
            endDate.CustomFormat = "dd/MM/yyyy";
            endDate.MinDate = new DateTime(2023, 1, 1);
            endDate.MaxDate = DateTime.Now;
            endDate.ValueChanged += EndDate_Changed;
            endDate.DropDownAlign = LeftRightAlignment.Left;
            TransactionTables = new DataGridView();
            mainContentParts = new RoundedPanel();
            Parts = new Button();
            Transactions = new Button();
            Add = new Button();
            gridViewparts = new DataGridView();

            // mainContentParts
            mainContentParts.BackColor = Color.White;
            mainContentParts.BorderRadius = 50;
            mainContentParts.Controls.Add(Parts);
            mainContentParts.Controls.Add(Transactions);
            mainContentParts.Controls.Add(Add);
            mainContentParts.Controls.Add(gridViewparts);
            mainContentParts.Dock = DockStyle.Fill;
            mainContentParts.Name = "mainContentParts";
            mainContentParts.Size = new Size(0, 30);
            mainContentParts.TabIndex = 0;

            // Parts Button
            Parts.Location = new Point(50, 20);
            Parts.Name = "Parts";
            Parts.Size = new Size(120, 40);
            Parts.Text = "Parts";
            Parts.Click += Parts_Click;
            // Transactions Button
            Transactions.Location = new Point(Parts.Right + 20, 20);
            Transactions.Name = "Transactions";
            Transactions.Size = new Size(120, 40);
            Transactions.Text = "Transactions";
            Transactions.Click += Transacstions_CLick;
            // Lấy giá trị của DateTimePicker (giả sử là startDatePicker)



            DateTime start = startDate.Value;
            DateTime end = endDate.Value;
            // ComboBox for List Parts
             PartsContent=new Label();
            PartsContent.Text = "Parts:";
        
        
            PartsContent.Location= new Point(50, Parts.Bottom + 35);
            PartsContent.Width = 40;

            listPartsBox = new ComboBox();
            mainContentParts.Controls.Add(PartsContent);
            lists = _inventory.GetLinhKienList();
            AllList = _inventory.GetLinhKienList();
            listTransactionQUery = _inventory.GetTransactionsByDate(start, end);
            AlllistTransactionQUery = _inventory.GetTransactionsByDate(start, end);
            var linhKienList = AllList.Select(part => new LinhKienItem
            {
                LinhKienId = part.LinhKienID,
                TenLinhKien = part.TenLinhKien
            }).ToList();
            linhKienList.Insert(0, new LinhKienItem
            {
                LinhKienId = 0, // Hoặc sử dụng null nếu LinhKienId có thể nhận giá trị null
                TenLinhKien = "All"
            });
            listPartsBox.DataSource = linhKienList;
            listPartsBox.DisplayMember = "TenLinhKien"; // Hiển thị tên linh kiện
            listPartsBox.ValueMember = "LinhKienId";  // Sử dụng LinhKienId làm giá trị

            listPartsBox.Location = new Point(PartsContent.Right, Parts.Bottom + 30);
            listPartsBox.Width = 150;
            listPartsBox.Height = 40;
            listPartsBox.MouseWheel += (sender, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };
            // Xử lý sự kiện khi người dùng chọn một tùy chọn
            listPartsBox.SelectedIndexChanged += (sender, e) =>
            {
                // Lấy phần tử đã chọn trong ComboBox
                var selectedItem = listPartsBox.SelectedItem;
                DateTime sd = startDate.Value;
                DateTime ed = endDate.Value;
                int selectedLinhKienId = (int)listPartsBox.SelectedValue;
                if (selectedLinhKienId == 0) // If "All" is selected
                {

                    lists = _inventory.GetLinhKienList(); // Get all parts
                    listTransactionQUery = _inventory.GetTransactionsByDate(sd, ed);
                }
                else
                {
                    lists = _inventory.GetLinhKienList(selectedLinhKienId);
                    listTransactionQUery = _inventory.GetTransactionsByDate(sd, ed, selectedLinhKienId);
                }
                gridViewparts.Rows.Clear();
                TransactionTables.Rows.Clear();
                InitDataGridView(AllList, gridViewparts);
                InitTransactionParts(listTransactionQUery, TransactionTables);
            };
            mainContentParts.Controls.Add(listPartsBox);
            Add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Add.Location = new Point(mainContentParts.Width - mainContentParts.Padding.Right - 150, listPartsBox.Location.Y - listPartsBox.Height / 2);
            Add.Name = "Add";
            Add.Size = new Size(120, 40);
            Add.Text = "Add";
            Add.Click += Add_click;
             StartDate= new Label();
            StartDate.Text = "Start Date:";
            StartDate.Location = new Point(listPartsBox.Right+30,listPartsBox.Location.Y+5);
             EndDate = new Label();
            EndDate.Text = "End Date:";
           
            EndDate.Width = 60;
            StartDate.Width = 70;
            startDate.Location = new Point(StartDate.Right, listPartsBox.Location.Y);
            startDate.Width = 100;
            endDate.Width = 100;
            EndDate.Location = new Point(startDate.Right + 30, listPartsBox.Location.Y+5);
            endDate.Location = new Point(EndDate.Right, listPartsBox.Location.Y);
            // Add mainContentParts to InventoryControl
            Controls.Add(mainContentParts);
            Name = "InventoryControl";
            Padding = new Padding(100, 60, 100, 60);
            Resize += InventoryControl_Resize;

            // DataGridView for Parts

            // Đảm bảo dòng này ở ngay đầu hoặc trước khi thêm dữ liệu vào DataGridView
            TransactionTables.GridColor = Color.Gray;  // Đảm bảo không có đường kẻ giữa các ô
            TransactionTables.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // Thiết lập padding cho tất cả các ô trong DataGridView
            TransactionTables.Padding = new Padding(20);

            // Đặt kiểu viền cho header
            TransactionTables.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;// Loại bỏ tất cả đường kẻ ô
            TransactionTables.RowHeadersVisible = false;
            TransactionTables.AllowUserToAddRows = false;
            TransactionTables.AllowUserToDeleteRows = false;
            TransactionTables.ReadOnly = true;
            TransactionTables.ScrollBars = ScrollBars.None;
            TransactionTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            TransactionTables.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            TransactionTables.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            TransactionTables.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray; // Giữ màu khi chọn
            TransactionTables.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black; // Giữ màu chữ khi chọn
            TransactionTables.ColumnHeadersHeight = 40;
            // Thay đổi màu đường kẻ ngang
            TransactionTables.RowsDefaultCellStyle.BackColor = Color.White;  // Màu nền của hàng
            TransactionTables.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Màu nền của hàng chẵn
            TransactionTables.AllowUserToResizeRows = false;
            TransactionTables.AllowUserToResizeColumns = false;

            // Đảm bảo không có màu khi chọn
            TransactionTables.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            TransactionTables.DefaultCellStyle.SelectionForeColor = TransactionTables.DefaultCellStyle.ForeColor;

            TransactionTables.BackgroundColor = Color.White;

            // Cập nhật độ cao mỗi hàng
            // Đặt chiều cao của mỗi hàng
            TransactionTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TransactionTables.MultiSelect = false;
            TransactionTables.ReadOnly = true;

            // Cho phép chọn lại ô nút "Cập Nhật"


            // Xử lý sự kiện CellClick để chỉ cho phép nhấn vào nút "Cập Nhật"

            TransactionTables.RowTemplate.Height = 45;
            TransactionTables.CellClick += (s, e) =>
            {
                // Kiểm tra nếu ô được nhấn là ô "Update" (cột nút Cập Nhật)
                if (e.ColumnIndex == TransactionTables.Columns["Update"].Index)
                {
                    // Xử lý hành động cập nhật ở đây

                    // đợi bạn 5p   
                };
            };
                if (TransactionTables.Columns["HinhAnh"] == null)
            {
                var imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "HinhAnh";
                imageColumn.HeaderText = "Image";
                imageColumn.Width = 60;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Customize image layout
                TransactionTables.Columns.Insert(0, imageColumn); // Insert at the first column
            }

            if (TransactionTables.Columns["No"] == null)
            {
                var sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "No";
                sttColumn.HeaderText = "No";
                sttColumn.Width = 30; // Adjust width for No column
                TransactionTables.Columns.Insert(0, sttColumn); // Insert at the first column
            }
            
            // Tạo cột Update Button
            var updateButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Update",
                HeaderText = "Actions",
                Text = "Update",
                UseColumnTextForButtonValue = true,
            };

            // Thêm cột Update Button vào DataGridView


            // Các cột TextBox
            TransactionTables.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn { Name = "User", HeaderText = "User" },
                    new DataGridViewTextBoxColumn { Name = "Parts", HeaderText = "Parts" },
                    new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount" },
                    new DataGridViewTextBoxColumn { Name = "Prices", HeaderText = "Prices" },
                    new DataGridViewTextBoxColumn { Name = "Transaction date", HeaderText = "Transaction date" },
                });

            // Đặt WrapMode cho cột "User" để hiển thị nhiều dòng
            TransactionTables.Columns["User"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            TransactionTables.Columns.Add(updateButtonColumn);
            // Thiết lập chiều cao tiêu đề của cột
            TransactionTables.ColumnHeadersHeight = 40;

            // Xử lý sự kiện khi nhấn nút "Update"
            TransactionTables.CellContentClick += (sender, e) =>
            {
                // Kiểm tra nếu cột nhấn là cột nút "Update"
                if (e.RowIndex >= 0 && TransactionTables.Columns[e.ColumnIndex].Name == "Update")
                {
                    // Lấy thông tin của dòng hiện tại (dùng e.RowIndex để truy xuất dòng)
                    var selectedRow = TransactionTables.Rows[e.RowIndex];


                    int iduser = listTransactionQUery[e.RowIndex].userId;
                  
                    // Gọi phương thức để cập nhật dữ liệu vào cơ sở dữ liệu
                    AddNhanVien add = new AddNhanVien(_db, iduser);
                    add.Show();
                }
            };
            // alo hiện tại là ảnh bạn đang để chế độ fake ,nó ko có thật nên load ảnh nó báo lỗi , ông trong form tạo hàm kiểm tra nếu nó ko tồn tại thì đặt một cái ảnh mặc định vào là đc
            // giờ tôi làm nốt winform các màn còn lại
            // Ẩn tiêu đề dòng để không hiển thị dấu X 
            gridViewparts.RowHeadersVisible = false;

                gridViewparts.AllowUserToAddRows = false;

                gridViewparts.AllowUserToDeleteRows = false;
                gridViewparts.ReadOnly = true;
                // Tắt thanh cuộn mặc định
                gridViewparts.ScrollBars = ScrollBars.None; // Tắt thanh cuộn mặc định
                gridViewparts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Loại bỏ đường kẻ dọc và ngang
                gridViewparts.GridColor = Color.Gray;  // Đảm bảo không có đường kẻ giữa các ô
                gridViewparts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                // Thiết lập padding cho tất cả các ô trong DataGridView
                gridViewparts.Padding = new Padding(20);

                // Đặt kiểu viền cho header
                gridViewparts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;// Loại bỏ tất cả đường kẻ ô
                gridViewparts.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                gridViewparts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                gridViewparts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray; // Giữ màu khi chọn
                gridViewparts.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black; // Giữ màu chữ khi chọn

                // Điều chỉnh chiều cao của header
                gridViewparts.ColumnHeadersHeight = 40;
                // Thay đổi màu đường kẻ ngang
                gridViewparts.RowsDefaultCellStyle.BackColor = Color.White;  // Màu nền của hàng
                gridViewparts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Màu nền của hàng chẵn
                gridViewparts.AllowUserToResizeRows = false;
                gridViewparts.AllowUserToResizeColumns = false;

                // Đảm bảo không có màu khi chọn
                gridViewparts.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
                gridViewparts.DefaultCellStyle.SelectionForeColor = gridViewparts.DefaultCellStyle.ForeColor;

                gridViewparts.BackgroundColor = Color.White;

                // Cập nhật độ cao mỗi hàng
                // Đặt chiều cao của mỗi hàng
                gridViewparts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridViewparts.MultiSelect = false;
                gridViewparts.ReadOnly = true;

                // Cho phép chọn lại ô nút "Cập Nhật"
                // Đặt màu nền cho hàng tiêu đề
                gridViewparts.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;

                // Đặt màu viền cho hàng tiêu đề
                gridViewparts.EnableHeadersVisualStyles = false;
                gridViewparts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                gridViewparts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Màu chữ của Header
                gridViewparts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightBlue; // Màu khi Header được chọn

                // Đặt viền ngoài của toàn bộ DataGridView (nếu cần)
                gridViewparts.BorderStyle = BorderStyle.Fixed3D;

                gridViewparts.RowTemplate.Height = 45;

                    if (gridViewparts.Columns["HinhAnh"] == null)
                    {
                        var imageColumn = new DataGridViewImageColumn();
                        imageColumn.Name = "HinhAnh";
                        imageColumn.Width = 60;
                        imageColumn.HeaderText = "Image";
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Customize image layout
                        gridViewparts.Columns.Insert(0, imageColumn); // Insert at the first column
                    }

                    if (gridViewparts.Columns["No"] == null)
                    {
                        var sttColumn = new DataGridViewTextBoxColumn();
                        sttColumn.Name = "No";
                        sttColumn.HeaderText = "No";
                        sttColumn.Width = 30; // Adjust width for No column
                        gridViewparts.Columns.Insert(0, sttColumn); // Insert at the first column
                    }

                    // Add the Update button column before adding rows
                    var updateButtonColumnParts = new DataGridViewButtonColumn
                    {
                        Name = "Update",
                        HeaderText = "Actions",
                        Text = "Update",
                        UseColumnTextForButtonValue = true,

                    };
                    

                    // Columns in DataGridView
                    gridViewparts.Columns.AddRange(new DataGridViewColumn[]
                {
                    new DataGridViewTextBoxColumn { Name = "Parts", HeaderText = "Parts" },
                    new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount" },
                    new DataGridViewTextBoxColumn { Name = "Prices", HeaderText = "Prices" },

                });
                    gridViewparts.ColumnHeadersHeight = 40;
                    gridViewparts.Columns.Add(updateButtonColumnParts);
                    InitDataGridView(AllList, gridViewparts);
                InitTransactionParts(listTransactionQUery, TransactionTables);

            mainContentParts.Controls.Add(Parts);


        }

        private void Add_click(object sender, EventArgs e)
        {
            AddNhanVien addStaff = new AddNhanVien(_db);
            addStaff.Show();
        }

        private void EndDate_Changed(object sender, EventArgs e)
        {
            DateTime start = startDate.Value;
            DateTime end = endDate.Value;
            TransactionTables.Rows.Clear();
            listTransactionQUery=_inventory.GetTransactionsByDate(start, end);
            InitTransactionParts(listTransactionQUery,TransactionTables);
        }



        // Event handler for Mouse Enter (hover effect)
        private void InitTransactionParts(List<TransactionQuery> listsDetail, DataGridView? gridViewparts)
        {
            int index = 1;
            foreach (var item in listsDetail)
            {
                // Load the image for the part, handling missing or invalid paths
                Image partImage;
                try
                {
                    if (!string.IsNullOrEmpty(item.anh) && File.Exists(item.anh))
                    {
                        partImage = Image.FromFile(item.anh);
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
                gridViewparts.Rows.Add(index, partImage, item.ten + "\n" + item.userId, item.tenLinhKien, item.soLuongLinhKien, item.GiaTriHoaDon, item.NgayGiaoDich.Date);
                index++;
            

        }
            // Ensure button column moves with the rows when scrolling
            gridViewparts.Refresh();
            gridViewparts.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == gridViewparts.Columns["Update"].Index)
                {
                    // Handle Update button click logic here
                    var part = listsDetail[e.RowIndex]; // Retrieve the part corresponding to the clicked row
                                                        // Do something with the part, such as opening an update form

                    if (part != null) {
                        return;
                    }
                    AddNhanVien addStaff = new AddNhanVien(_db,part.userId);
                    addStaff.Show();
                }
            };

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
            foreach (DataGridViewRow row in gridViewparts.Rows)
            {
                var buttonCell = row.Cells["Update"] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    // Tính toán chiều rộng và chiều cao của nút chiếm 3/4 chiều rộng và chiều cao của ô
                    int width = gridViewparts.Columns["Update"].Width * 3 / 5; // Adjust width slightly for padding
                    int height = gridViewparts.RowTemplate.Height * 3 / 5; // Adjust height for better alignment

                    // Tính toán padding để căn giữa nút
                    int horizontalPadding = (gridViewparts.Columns["Update"].Width - width) / 2;
                    int verticalPadding = (gridViewparts.RowTemplate.Height - height) / 2;

                    // Căn giữa nút trong cột "Update" với padding tính toán động
                    buttonCell.Style.Padding = new Padding(horizontalPadding, verticalPadding, horizontalPadding, verticalPadding);


                    buttonCell.Style.ForeColor = Color.Black;
                    buttonCell.Style.SelectionBackColor = Color.AliceBlue;
                    buttonCell.Style.SelectionForeColor = Color.Black;
                    buttonCell.Style.Font = new Font("Arial", 10); // Đặt font cho nút

                }

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
            gridViewparts.Columns["Update"].ReadOnly = false; // Giả sử "Update" là tên của cột nút Cập Nhật}
        }
            private void InitDataGridView(List<LinhKien> listLinhkiens,DataGridView? gridViewparts)
        {
           
       
            int index = 1;
            foreach (var part in lists)
            {
                // Load the image for the part, handling missing or invalid paths
                Image partImage;
                try
                {
                    if (!string.IsNullOrEmpty(part.HinhAnh) && File.Exists(part.HinhAnh))
                    {
                        partImage = Image.FromFile(part.HinhAnh);
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
                gridViewparts.Rows.Add(index, partImage, part.TenLinhKien, part.SoLuong, part.Gia);
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
            foreach (DataGridViewRow row in gridViewparts.Rows)
            {
                var buttonCell = row.Cells["Update"] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    // Tính toán chiều rộng và chiều cao của nút chiếm 3/4 chiều rộng và chiều cao của ô
                    int width = gridViewparts.Columns["Update"].Width * 3 / 5; // Adjust width slightly for padding
                    int height = gridViewparts.RowTemplate.Height * 3 / 5; // Adjust height for better alignment

                    // Tính toán padding để căn giữa nút
                    int horizontalPadding = (gridViewparts.Columns["Update"].Width - width) / 2;
                    int verticalPadding = (gridViewparts.RowTemplate.Height - height) / 2;

                    // Căn giữa nút trong cột "Update" với padding tính toán động
                    buttonCell.Style.Padding = new Padding(horizontalPadding, verticalPadding, horizontalPadding, verticalPadding);


                    buttonCell.Style.ForeColor = Color.Black;
                    buttonCell.Style.SelectionBackColor = Color.AliceBlue;
                    buttonCell.Style.SelectionForeColor = Color.Black;
                    buttonCell.Style.Font = new Font("Arial", 10); // Đặt font cho nút

                }

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
            gridViewparts.Columns["Update"].ReadOnly = false; // Giả sử "Update" là tên của cột nút Cập Nhật

        }
        private void Transacstions_CLick(object sender, EventArgs e)
        {
            mainContentParts.Controls.Add(startDate);
            mainContentParts.Controls.Add(endDate);
            mainContentParts.Controls.Remove(gridViewparts);
            mainContentParts.Controls.Add(TransactionTables);
            mainContentParts.Controls.Add(StartDate);
            mainContentParts.Controls.Add(EndDate);
        }
        private void Parts_Click(object sender, EventArgs e)
        {
            mainContentParts.Controls.Remove(StartDate);
            mainContentParts.Controls.Remove(startDate);
            mainContentParts.Controls.Remove(endDate);
            mainContentParts.Controls.Add(gridViewparts);
            mainContentParts.Controls.Remove(TransactionTables);
            mainContentParts.Controls.Remove(EndDate);
        }
        private void InventoryControl_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí của TransactionTable để tránh che mất ComboBox
            int offsetFromTop = listPartsBox.Location.Y + listPartsBox.Height + 20; // Khoảng cách từ phía trên form (giả sử khoảng cách này là đủ để không bị che khuất)
            TransactionTables.Location = new Point(PartsContent.Location.X, offsetFromTop); // Di chuyển bảng xuống
            TransactionTables.Width = Add.Location.X + Add.Width - PartsContent.Location.X; // Đảm bảo chiều rộng của bảng phù hợp với diện tích
            TransactionTables.Height = mainContentParts.Height - offsetFromTop - 20; // Điều chỉnh chiều cao của bảng

          
            TransactionTables.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
 
            mainContentParts.Padding = new Padding(0, 0, 0, 30);
            gridViewparts.ColumnHeadersHeight = 40;
            gridViewparts.Location = new Point(PartsContent.Location.X, offsetFromTop); // Di chuyển bảng xuống
            gridViewparts.Width = Add.Location.X + Add.Width - PartsContent.Location.X; // Đảm bảo chiều rộng của bảng phù hợp với diện tích
            gridViewparts.Height = mainContentParts.Height - offsetFromTop - 20; // Điều chỉnh chiều cao của bảng

          
            gridViewparts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            mainContentParts.Padding = new Padding(0, 0, 0, 30);
            gridViewparts.ColumnHeadersHeight = 40;
          
        }
      
        #endregion

    }
}