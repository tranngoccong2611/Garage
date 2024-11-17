using Garage.Common.Extension;
using Garage.Data.Models;
using GaraOto.Common.Utilities.Helper;
public class StatusWork
{
    public string Name { get; set; }
    public int Id { get; set; }
}
public class Role
{
    public int Id { get; set; }

    public string Name { get; set; }    
}
namespace Garage.Forms.MainForm.Dictionary
{
    partial class StaffManagementControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView gridviewUser;
        int widthSearchPanel = (SystemInformation.WorkingArea.Width - 250) * 5 / 6;
        private ComboBox listWorkStatus;
        private ComboBox listRole;
        private Button ExportExcel;
        private Panel Wrap;
        private List<Staff> staffList;
        private List<Role> listChucVu;
        private List<StatusWork> listStatus = new List<StatusWork>
{   new StatusWork { Id = 1, Name = "All" },
            new StatusWork { Id = 2, Name = "Working" },
    new StatusWork { Id = 3, Name = "Quit job" },
    
 
};
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
            listChucVu = _getstaffs.GetListRole()
    .Select(c => new Role{ Id=c.ChucVuID, Name= c.TenChucVu })
    .ToList();
            staffList=_getstaffs.GetStaffListAll();

            Wrap = new Panel();
            Wrap.Width = widthSearchPanel + 20;
            Wrap.Height=(SystemInformation.WorkingArea.Height-60)*3/4+70;

            Wrap.Location = new Point(((SystemInformation.WorkingArea.Width-250)-widthSearchPanel-20)/2,(SystemInformation.WorkingArea.Height-60- (SystemInformation.WorkingArea.Height - 60) * 3 / 4)/2-50);
            Controls.Add(Wrap);
             listWorkStatus = new ComboBox();
            listRole = new ComboBox();
            initRole();
            InitWorkStatus();
            
            gridviewUser = new DataGridView();
            ExportExcel = new Button();
            Wrap.Controls.Add(gridviewUser);
            GridViewUser();
            ExportExcel.Width = 150;
            ExportExcel.Height = 40;
            ExportExcel.BackColor = Color.Green;
            ExportExcel.ForeColor = Color.Black;
            ExportExcel.Text = "Export To Excel";
            ExportExcel.ForeColor  =Color.White;
            ExportExcel.Location = new Point(widthSearchPanel-135,listRole.Location.Y);
            ExportExcel.Click += ExportExcel_Click;
            InitTableStaff(staffList,gridviewUser);
            Wrap.Controls.Add(listRole);
            Wrap.Controls.Add(listWorkStatus);
            Wrap.Controls.Add(ExportExcel);

        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
           
                // Ví dụ sử dụng
                var data = staffList; // Lấy dữ liệu cần xuất
                string filePath = ExcelHelper.ExportToExcel(
                    data,
                    "DanhSachNhanVien",
                    @"D:\ExcelExports"
                );
                // File sẽ được lưu với tên kiểu: DanhSachNhanVien_20241116_143022.xlsx

                // Display a success message to the user
                MessageBox.Show("Excel file exported successfully!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void initRole()
        {
            listChucVu.Insert(0, new Role { Id = 0, Name = "All" });
            listRole.DataSource = listChucVu;
            listRole.DisplayMember = "Name";
            listRole.ValueMember = "Id";

            listRole.Location = new Point(0, 10);
            listRole.Width = 200;
            listRole.Height = 50;

            listRole.MouseWheel += (sender, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };

            listRole.SelectedIndexChanged += (sender, e) =>
            {
                // Reset Work Status to "All" when Role changes
                listWorkStatus.SelectedIndex = 0;

                // Get selected role
                var selectedItem = (Role)listRole.SelectedItem;
                UpdateGridView(selectedItem.Id, 1); // 1 is the ID for "All" status
            };
        }

        private void InitWorkStatus()
        {
            listWorkStatus.DataSource = listStatus;
            listWorkStatus.DisplayMember = "Name";
            listWorkStatus.ValueMember = "Id";

            listWorkStatus.Location = new Point(listRole.Right + 30, listRole.Location.Y);
            listWorkStatus.Width = 100;
            listWorkStatus.Height = 50;

            listWorkStatus.MouseWheel += (sender, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };

            listWorkStatus.SelectedIndexChanged += (sender, e) =>
            {
                var selectedStatus = (StatusWork)listWorkStatus.SelectedItem;
                var selectedRole = (Role)listRole.SelectedItem;

                if (selectedStatus != null && selectedRole != null)
                {
                    UpdateGridView(selectedRole.Id, selectedStatus.Id);
                }
            };
        }

        private void UpdateGridView(int roleId, int statusId)
        {
            gridviewUser.Rows.Clear();
            List<Staff> filteredStaff = new List<Staff>();

            // First, filter by role
            if (roleId == 0) // All roles
            {
                filteredStaff = _getstaffs.GetStaffListAll();
            }
            else
            {
                filteredStaff = _getstaffs.GetStaffListAll().FindAll(item => item.RoleId == roleId);
            }
            switch (statusId)
            {
                case 1: 
                    break;
                case 2:
                    filteredStaff = filteredStaff.FindAll(staff => _getstaffs.GetStaffListWork().Exists(s => s.Id == staff.Id));
                    break;
                case 3: 
                    filteredStaff = filteredStaff.FindAll(staff => _getstaffs.GetStaffListUnWork().Exists(s => s.Id == staff.Id));
                    break;
            }

            InitTableStaff(filteredStaff, gridviewUser);
        }

    


        private void GridViewUser()
        {

            gridviewUser.Width = widthSearchPanel+20;
            gridviewUser.Height = SystemInformation.WorkingArea.Height - 60 - 60 - 40-72;
            gridviewUser.Location = new Point(listRole.Location.X, listRole.Bottom + 30);

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
                    new DataGridViewTextBoxColumn { Name = "Name", HeaderText = " Name" },
                    new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone" },
                    new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Role" },
                    new DataGridViewTextBoxColumn { Name = "JoinDate", HeaderText = "JoinDate" },
                    new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" },
                });

            gridviewUser.ColumnHeadersHeight = 40;
         

        }
        private void InitTableStaff(List<Staff> listsDetail, DataGridView? gridViewparts)
        {
            int index = 1;
            foreach (var item in listsDetail)
            {
                // Load the image for the part, handling missing or invalid paths
                Image partImage;
                try
                {
                    if (!string.IsNullOrEmpty(item.Image) && File.Exists(item.Image))
                    {
                        partImage = Image.FromFile(item.Image);
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
                string status = item.OutDate == null ? "Working" : "Quit job";
                // Add the row to the DataGridView
                gridViewparts.Rows.Add(index, partImage, item.Name, item.Phone, item.Role,DateOnly.FromDateTime(item.JoinDate), status);
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
        #endregion
    }
}
