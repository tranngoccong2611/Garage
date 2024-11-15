using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Garage.Data.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Drawing2D;
using System.Net.Mime;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;

namespace Garage.Forms.MainForm.Dictionary
{
    partial class RepairTrackerControl : UserControl
    {
        private Label noIssuesLabel;
        private Label issuesLabel;
        private System.ComponentModel.IContainer components = null;
        private string searchQuery;
        private List<NguoiDung> users;
        private ListBox issuesList;
        private ListBox fixesList;
        private TextBox searchBox;
        private Image buttonSearch;
        private ListBox suggestionList;
        private Panel leftPanel;
        private Panel rightPanel;
        private Panel Container;
        private Panel issuesPanel;
    
        private Panel MainContent;
        private List<IResolveIssue> listsUnResolve;
        private List<IResolveIssue> listsResolve;
        private Label fixesLabel;
        private Panel searchPanel;
        private Panel contentPanel;
        private int currScrollLeft = 0;
        private int currentScrollPosition = 0; 
        private const int SCROLL_STEP = 40;
        private const int DEFAULT_HEIGHT = 70;
        private const int EXPANDED_HEIGHT = 100;
        private Dictionary<Panel, int> originalPositions = new Dictionary<Panel, int>();
        private Panel suggest;
        int widthSearchPanel = (SystemInformation.WorkingArea.Width - 250) * 5 / 6;
        private Panel suggestPanel;
        private const int MAX_SUGGESTIONS = 5;
        private const int SUGGESTION_ITEM_HEIGHT = 50;
        private Panel contentIssue;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitSearch(int widthSearchPanel)
        {
            searchPanel = new Panel
            {
                Width = widthSearchPanel*6/5,
                Location = new Point((SystemInformation.WorkingArea.Width - 250 - widthSearchPanel) / 2, 40),
                Height = 60,
            };

            var searchContainer = new CustomPanel
            {
                Height = 40,
                Width = widthSearchPanel ,
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
                Width = searchContainer.Width-100 ,
                Height = 40,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(45, 10),
                PlaceholderText = "Search UserCar",
                Font = new Font("Segoe UI", 12)
            };
            Button btnImage = new Button();
            btnImage.Location = new Point(searchBox.Right+20, 10);
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
                contentPanel.Controls.Clear();
                contentIssue.Controls.Clear();
                listsResolve = _trackerUtils.getRepairTrackerListResolve();
                 listsUnResolve = _trackerUtils.getRepairListUnResolve();
                LoadResolvedIssues(listsResolve);
                LoadLeftResolvedIssues(listsUnResolve);
                contentPanel.Controls.Remove(noIssuesLabel);
                contentIssue.Controls.Remove(noIssuesLabel);
            };
            searchContainer.Controls.Add(btnImage); // Thêm nút vào Form

            searchBox.TextChanged += SearchBox_TextChanged;

           

            searchPanel.Controls.Add(searchContainer);
          
            searchContainer.Controls.Add(searchBox);

            Container.Controls.Add(searchPanel);
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
             searchQuery = searchBox.Text.Trim();
            if (searchQuery.Length >= 1) // Chỉ hiện gợi ý khi nhập ít nhất 1 ký tự
            {
                FilterIssues(searchQuery);
            }
            else if (suggestPanel != null && Container.Controls.Contains(suggestPanel))
            {
                Container.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();
            }
        }


        private void FilterIssues(string searchQuery)
        {
            // Xóa panel gợi ý cũ nếu tồn tại
            if (suggestPanel != null && Container.Controls.Contains(suggestPanel))
            {
                Container.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();
            }

            if (string.IsNullOrEmpty(searchQuery))
                return;
            suggestPanel = new Panel
            {
                Width = searchBox.Width,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(searchPanel.Location.X+20, searchPanel.Bottom),
                AutoScroll = false,
                Height =  150 
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
            var matchingUsers = _context.NguoiDung
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

            Container.Controls.Add(suggestPanel);
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

            // Xử lý sự kiện click
            item.Click += (s, e) => HandleUserSelection(user);

            return item;
        }
        private void HandleUserSelection(NguoiDung selectedUser)
        {
            // Cập nhật searchBox với thông tin người dùng được chọn
            searchBox.Text = $"{selectedUser.HoTen} - {selectedUser.SoDienThoai}";

            // Xóa panel gợi ý
            if (Container.Controls.Contains(suggestPanel))
            {
                Container.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();
            }

            // Lấy và hiển thị danh sách vấn đề của người dùng
            LoadUserIssues(selectedUser.SoDienThoai,true);
            LoadUserIssuesLeft(selectedUser.SoDienThoai,false);
        }
        private void LoadUserIssues(string phoneNumber,bool isFix)
        {
            // Xóa các issue hiện tại
            contentPanel.Controls.Clear();

            // Lấy danh sách vấn đề của người dùng
            var userIssues = _trackerUtils.getRepairListResolveByPhone(phoneNumber);

            int yPosition = 0;
            int tagIndex = 0;

            foreach (var issue in userIssues)
            {
                Panel itemContainer = CreateItemPanel(issue, yPosition, tagIndex,isFix);
                contentPanel.Controls.Add(itemContainer);
                yPosition += itemContainer.Height + 15;
                tagIndex++;
            }

            contentPanel.Height = Math.Max(yPosition, rightPanel.Height - fixesLabel.Height);
            CheckAndFixOverlap();

            // Nếu không có vấn đề nào, hiển thị thông báo
            if (userIssues.Count == 0)
            {
                 noIssuesLabel = new Label
                {
                    Text = "No issues found for this user",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(
                        (contentPanel.Width - 200) / 2,
                        (contentPanel.Height - 30) / 2
                    )
                };
                contentPanel.Controls.Add(noIssuesLabel);
            }
        }
        private void LoadUserIssuesLeft(string phoneNumber,bool isFix)
        {
            // Xóa các issue hiện tại
            contentIssue.Controls.Clear();

            // Lấy danh sách vấn đề của người dùng
            var userIssues = _trackerUtils.getRepairListUnResolveByPhone(phoneNumber);

            int yPosition = 0;
            int tagIndex = 0;

            foreach (var issue in userIssues)
            {
                Panel itemContainer = CreateItemPanel(issue, yPosition, tagIndex, isFix);
                contentIssue.Controls.Add(itemContainer);
                yPosition += itemContainer.Height + 15;
                tagIndex++;
            }

            contentIssue.Height = Math.Max(yPosition, leftPanel.Height - issuesLabel.Height);
            CheckAndFixOverlap();

            // Nếu không có vấn đề nào, hiển thị thông báo
            if (userIssues.Count == 0)
            {
                noIssuesLabel = new Label
                {
                    Text = "No issues found for this user",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(
                       (contentIssue.Width - 200) / 2,
                       (contentIssue.Height - 30) / 2
                   )
                };
                contentIssue.Controls.Add(noIssuesLabel);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (suggestPanel != null && Container.Controls.Contains(suggestPanel))
            {
                Container.Controls.Remove(suggestPanel);
                suggestPanel.Dispose();
            }
        }
    

        private void FilterButton_Click(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                FilterIssues(searchText);
            }
            else
            {
                MessageBox.Show("Please enter text to search.");
            }
        }

        private void InitMain(int widthSearchPanel)
        {
            MainContent = new Panel
            {
                Width = widthSearchPanel,
                Location = new Point(searchPanel.Location.X, searchPanel.Bottom + 15),
                Height = (SystemInformation.WorkingArea.Height - 60) * 4 / 5 - 60,
                BackColor = Color.White
            };

            InitializeLeftPanel(widthSearchPanel);
            InitializeRightPanel(widthSearchPanel);

            MainContent.Controls.Add(leftPanel);
            MainContent.Controls.Add(rightPanel);
        }

        private void InitializeLeftPanel(int widthSearchPanel)
        {
             issuesLabel = new Label
            {
                Text = "Issues",
                 Location = new Point(20, 10),
                 Font = new Font("Segoe UI Semibold", 16),
                Height = 40,
                ForeColor = Color.Black,
            };

            leftPanel = new Panel
            {
                Width = widthSearchPanel * 3 / 7 - 5,
                Padding = new Padding(15, 10, 15, 15),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(240, 240, 240),
                Height = MainContent.Height - 40
            };

            issuesPanel = new Panel
            {
                Width = leftPanel.Width,
                Height = 60,
               Location=new Point(0, 0),
                BackColor = Color.FromArgb(240,240,240),
            };
            contentIssue = new Panel
            {
                Width = leftPanel.Width - 20,
                Location = new Point(20, issuesPanel.Bottom),
                Height = leftPanel.Height - issuesPanel.Height,
                BackColor = Color.FromArgb(240,240,240),
                AutoScroll = false,
                
            };
            issuesPanel.Controls.Add(issuesLabel);
            leftPanel.Controls.Add(issuesPanel);
            leftPanel.Controls.Add(contentIssue);
          
            leftPanel.MouseWheel += LeftPanel_MouseWheel;
            LoadLeftResolvedIssues(listsUnResolve);
        }

        private void InitializeRightPanel(int widthSearchPanel)
        {
            rightPanel = new Panel
            {
                Width = widthSearchPanel - leftPanel.Width - 50,
                Location = new Point(leftPanel.Right + 10, 20),
                Height = MainContent.Height - 40,
                BackColor = Color.White
            };

            Panel headerPanel = new Panel
            {
                Width = rightPanel.Width,
                Height = 60,
                Location = new Point(00, 0),
                BackColor = Color.White
            };

            fixesLabel = new Label
            {
                Text = "Fixes",
                Font = new Font("Segoe UI Semibold", 16),
                Height = 40,
                ForeColor = Color.Black,
                Location = new Point(20, 10)
            };

            headerPanel.Controls.Add(fixesLabel);
            rightPanel.Controls.Add(headerPanel);

            contentPanel = new Panel
            {
                Width = rightPanel.Width - 40,
                Location = new Point(20, headerPanel.Bottom),
                Height = rightPanel.Height - headerPanel.Height,
                BackColor = Color.White,
                AutoScroll = false
            };

            rightPanel.Controls.Add(contentPanel);
            LoadResolvedIssues(listsResolve);
            rightPanel.MouseWheel += RightPanel_MouseWheel;
        }

        private void LoadResolvedIssues(List<IResolveIssue> listsResolve)
        {
            int yPosition = 0;
            int tagIndex = 0;

            foreach (var item in listsResolve)
            {
                Panel itemContainer = CreateItemPanel(item, yPosition, tagIndex, true);
                contentPanel.Controls.Add(itemContainer);
                originalPositions[itemContainer] = yPosition;
                yPosition += itemContainer.Height + 15;
                tagIndex++;
            }

            contentPanel.Height = Math.Max(yPosition, rightPanel.Height - fixesLabel.Height);
        }
        private void LoadLeftResolvedIssues(List<IResolveIssue> listsResolve)
        {
            int yPosition = 0;
            int tagIndex = 0;

            foreach (var item in listsResolve)
            {
                Panel itemContainer = CreateItemPanel(item, yPosition, tagIndex, false);
                contentIssue.Controls.Add(itemContainer);
                originalPositions[itemContainer] = yPosition;
                yPosition += itemContainer.Height + 15;
                tagIndex++;
            }

            // Ensure the contentIssue height is updated after loading the issues
            contentIssue.Height = Math.Max(yPosition, leftPanel.Height - issuesPanel.Height);
        }

        private Panel CreateItemPanel(IResolveIssue item, int yPosition, int tagIndex, bool isFix)
        {
            Panel itemContainer = new Panel
            {
                Width = isFix ? contentPanel.Width - 20 : contentIssue.Width - 20,
                Height = DEFAULT_HEIGHT,
                Location = new Point(0, yPosition),
                BackColor = isFix ? Color.FromArgb(240, 240, 240) : Color.White,
                Tag = tagIndex
            };

            Label title = new Label
            {
                Text = item.TenUser + '-' + item.Sdt + '\n' + item.HangXe + ' ' + item.MoHinhXe + '-' + item.BienXe,
                Width = itemContainer.Width * 2 / 5,
                Location = new Point(10, 15),
                AutoSize = true,
            };

            Label content = new Label
            {
                Text = item.MucTieu,
                Width = itemContainer.Width * 4 / 6, // Adjust width as needed
                Location = new Point(10, 45),
                AutoSize = false,  // Disable AutoSize to manually control the size
                Height = 25,       // Set a height that accommodates multiline text (adjust as needed)
            };

            Button viewDetails = new Button
            {
                Text = "View Details",
                ForeColor = Color.Black,
                Width = 90,
                Height = 36,
                BackColor = Color.FromArgb(3, 252, 78),
                Location = new Point(itemContainer.Width - 100, 12),
                FlatStyle = FlatStyle.Flat
            };
            Point note = new Point(content.Location.X, content.Bottom+1);

            viewDetails.FlatAppearance.BorderSize = 0;
            viewDetails.Click += (sender, e) => HandleViewDetailsClick(itemContainer, viewDetails, item.GhiChu, note);

            Button DoneIssue = new Button
            {
                Text = "Done",
                ForeColor = Color.Black,
                Width = 60,
                Height = 28,
                BackColor = Color.Green,
                Location = new Point(itemContainer.Width - 80, 32),
                FlatStyle = FlatStyle.Flat
            };

            DoneIssue.FlatAppearance.BorderSize = 0;
            DoneIssue.Click += (sender, e) => handleDoneIssue();

            if (isFix == false) { itemContainer.Controls.AddRange(new Control[] { title, content, DoneIssue }); }
            else itemContainer.Controls.AddRange(new Control[] { title, content, viewDetails });

            return itemContainer;
        }

      

        private void handleDoneIssue() {  }
        private void HandleViewDetailsClick(Panel itemContainer, Button viewDetails, string nameStaff, Point note)
        {
            // Check if a label with name "staffLabel" exists already
            Label existingStaffLabel = itemContainer.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "staffLabel");

            if (existingStaffLabel == null)
            {
                // Create a new label if it doesn't exist
                Label staff = new Label
                {
                    Name = "staffLabel",
                    Text = nameStaff,
                    Location = note,
                    ForeColor = Color.Black,
                    Width = itemContainer.Width * 4 / 5
                };

                itemContainer.Controls.Add(staff);
            }

            // Toggle the expansion state of the item container
            bool isExpanded = itemContainer.Height == EXPANDED_HEIGHT;
            int newHeight = isExpanded ? DEFAULT_HEIGHT : EXPANDED_HEIGHT;
            int heightDiff = newHeight - itemContainer.Height;

            UpdatePanelUI(itemContainer, viewDetails, newHeight);
            UpdatePanelPositions(itemContainer, heightDiff, !isExpanded);
            CheckAndFixOverlap();
        }


        private void UpdatePanelUI(Panel itemContainer, Button viewDetails, int newHeight)
        {
            itemContainer.SuspendLayout();
            try
            {
                itemContainer.Height = newHeight;
                viewDetails.Text = newHeight == EXPANDED_HEIGHT ? "Hide Details" : "View Details";

            }
            finally
            {
                itemContainer.ResumeLayout();
            }
        }

        private void UpdatePanelPositions(Panel clickedPanel, int heightDiff, bool isExpanding)
        {
            int clickedPanelIndex = (int)clickedPanel.Tag;

            foreach (Control control in contentPanel.Controls)
            {
                if (control is Panel panel && (int)panel.Tag > clickedPanelIndex)
                {
                    panel.Location = new Point(panel.Location.X, panel.Location.Y + heightDiff);
                }
            }

            contentPanel.Height += heightDiff;
        }

        private void CheckAndFixOverlap()
        {
            var panels = contentPanel.Controls.Cast<Control>()
                .Where(c => c is Panel)
                .Cast<Panel>()
                .OrderBy(p => p.Location.Y)
                .ToList();

            int expectedY = 0;
            foreach (var panel in panels)
            {
                if (panel.Location.Y != expectedY)
                {
                    panel.Location = new Point(panel.Location.X, expectedY);
                }
                expectedY += panel.Height + 15;
            }
        }
        private void CheckAndFixOverlapLeft()
        {
            var panels = contentIssue.Controls.Cast<Control>()
                .Where(c => c is Panel)
                .Cast<Panel>()
                .OrderBy(p => p.Location.Y)
                .ToList();

            int expectedY = 0;
            foreach (var panel in panels)
            {
                if (panel.Location.Y != expectedY)
                {
                    panel.Location = new Point(panel.Location.X, expectedY);
                }
                expectedY += panel.Height + 15;
            }
        }

        private void RightPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int maxScroll = contentPanel.Height - (contentPanel.Parent.Height - fixesLabel.Height - 20);

            // Only allow scrolling if the content height exceeds the visible area
            if (contentPanel.Height <= contentPanel.Parent.Height - fixesLabel.Height)
                return;

            int newScrollPosition = currentScrollPosition;

            if (e.Delta > 0)
            {
                newScrollPosition = Math.Max(0, currentScrollPosition - SCROLL_STEP);
            }
            else
            {
                newScrollPosition = Math.Min(maxScroll, currentScrollPosition + SCROLL_STEP);
            }

            if (newScrollPosition != currentScrollPosition)
            {
                // Add an offset to ensure the first element isn't partially cut off
                int offset = 10;  // Adjust this value as needed to avoid cutting off the top element

                contentPanel.Location = new Point(
                    contentPanel.Location.X,
                    fixesLabel.Bottom - newScrollPosition + offset
                );

                currentScrollPosition = newScrollPosition;
            }

            contentPanel.Invalidate();
        }

        private void LeftPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int maxScroll = contentIssue.Height - (contentIssue.Parent.Height - issuesLabel.Height - 20);

            // Only allow scrolling if the content height exceeds the visible area
            if (contentIssue.Height <= contentIssue.Parent.Height - issuesLabel.Height)
                return;

            int newScrollPosition = currentScrollPosition;

            if (e.Delta > 0)
            {
                newScrollPosition = Math.Max(0, currentScrollPosition - SCROLL_STEP);
            }
            else
            {
                newScrollPosition = Math.Min(maxScroll, currentScrollPosition + SCROLL_STEP);
            }

            if (newScrollPosition != currentScrollPosition)
            {
                // Add an offset to ensure the first element isn't partially cut off
                int offset = 10;  // Adjust this value as needed to avoid cutting off the top element

                contentIssue.Location = new Point(
                    contentIssue.Location.X,
                    issuesLabel.Bottom - newScrollPosition + offset
                );

                currentScrollPosition = newScrollPosition;
            }

            contentIssue.Invalidate();
        }

        private void InitializeComponent()
        {
            this.Text = "Vehicle Issue Tracker";
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(800, 600);

            listsUnResolve = _trackerUtils.getRepairListUnResolve();
            listsResolve = _trackerUtils.getRepairTrackerListResolve();

            Container = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false
            };

           

            InitSearch(widthSearchPanel);
            InitMain(widthSearchPanel);

            Container.Controls.Add(searchPanel);
            Container.Controls.Add(MainContent);

            this.Controls.Add(Container);
        }
    }

    public class CustomPanel : Panel
    {
        public int BorderRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var path = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                path.AddRoundedRectangle(rect, BorderRadius);
                this.Region = new Region(path);
                using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }

    public static class GraphicsExtensions
    {
        public static void AddRoundedRectangle(this GraphicsPath path, Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
        }
    }
}