using Garage.Common.Enum;
using System;

namespace Garage.Forms.MainForm.Dictionary
{

    partial class BookingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel Wrap;
        private Panel header;
        private Panel timeInday;
    
        private Panel ItemInday;
        private RoundedPanel mainContentParts;
        private   int widthSearchPanel = (SystemInformation.WorkingArea.Width - 200) * 4/5;
        int WidthTimeTable = 80;
        private List<Bookcar> listsPerson;
    
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
            mainContentParts = new RoundedPanel();
            mainContentParts.BackColor = Color.White;
            mainContentParts.BorderRadius = 50;
       
            mainContentParts.Dock = DockStyle.Fill;
            mainContentParts.Name = "mainContentParts";
            mainContentParts.Size = new Size(0, 30);
            mainContentParts.TabIndex = 0;
            listsPerson = _bookings.getListCarBookingInWeekyly();

             Wrap = new Panel();
            Wrap.Width = widthSearchPanel+120 ;
            Wrap.Height = (SystemInformation.WorkingArea.Height - 60) * 4 / 5 ;
          
            Wrap.Location = new Point((SystemInformation.WorkingArea.Width-250-30-widthSearchPanel)/2, (SystemInformation.WorkingArea.Height - 60 - (SystemInformation.WorkingArea.Height - 60) * 3 / 4) / 2 - 50);
            header = new Panel();
            timeInday = new Panel();

            Padding = new Padding(20, 10, 20, 10);
            Controls.Add(mainContentParts);
            mainContentParts.Controls.Add(Wrap);
            Wrap.BackColor=Color.White;
            Wrap.Controls.Add(header);
         
          
            InitHeader();
            DayInWeek();
           
        }
        private void InitHeader() {
            header.Width = widthSearchPanel;
            header.Height = 60;
            header.Location = new Point(0, 0);
            header.BackColor = Color.AliceBlue;
            Label Books= new Label();
            Books.Text = "Bookings Weekly";
            Books.Height = 60;
            Books.Width = 250;
            Books.Location = new Point(20, 10);
            Books.Font = new Font("Times New Roman", 20,  FontStyle.Italic);
            Books.ForeColor = Color.DarkOliveGreen;
         
            header.Controls.Add(Books);


        }
       
       
        private void DayInWeek() {

            DateTime today= DateTime.Today;
            var dateNow=GetDayAndTimeSlot(today,new TimeSpan(12,0,0));
            int dayNumber = (int)dateNow.DayOfWeekNumber == 0 ? 7 : (int)dateNow.DayOfWeekNumber;
            DateTime[] weekDays = new DateTime[7];
            HashSet<Position> usedPositions = new HashSet<Position>();
            for (int i = 0; i < 7; i++)
            {
                // Tính số ngày còn lại trong tuần (theo thứ Hai đến Chủ Nhật)
                int offset = (i + 1 - dayNumber ) % 7;  // Tính toán sự chênh lệch ngày
                weekDays[i] = today.AddDays(offset);  // Cộng thêm số ngày tương ứng
            }
            Item(true,true,0,0,"TimeSlot","",0);
            usedPositions.Add(new Position(0, 0));
            Item(false, true, 0, 1, "Monday", "", 0, weekDays[0]);
            usedPositions.Add(new Position(0, 1));
            Item(false, true, 0, 2, "Tuesday", "", 0, weekDays[1]);
            usedPositions.Add(new Position(0, 2));
            Item(false, true, 0, 3, "Wednesday", "", 0, weekDays[2]);
            usedPositions.Add(new Position(0, 3));
            Item(false, true, 0, 4, "Thursday", "", 0, weekDays[3]);
            usedPositions.Add(new Position(0, 4));
            Item(false, true, 0, 5, "Friday", "", 0, weekDays[4]);
            usedPositions.Add(new Position(0, 5));
            Item(false, true, 0, 6, "Saturday", "", 0, weekDays[5]);
            usedPositions.Add(new Position(0, 6));
            Item(false, true, 0, 7, "Sunday", "", 0, weekDays[6]);
            usedPositions.Add(new Position(0, 7));
            Item(true,false,1,0,"8:00-10:00","",0);
            usedPositions.Add(new Position(1, 0));
            Item(true, false, 2, 0, "10:00-12:00", "", 0);
            usedPositions.Add(new Position(2, 0));
            Item(true, false, 3, 0, "12:00-14:00", "", 0);
            usedPositions.Add(new Position(3, 0));
            Item(true, false, 4, 0, "14:00-16:00", "", 0);
            usedPositions.Add(new Position(4, 0));
            Item(true, false, 5, 0, "16:00-18:00", "", 0);
            usedPositions.Add(new Position(5, 0));
            foreach (var item in listsPerson)
            {
               
                var res = GetDayAndTimeSlot(item.date, item.time);
                int status;
                if (item.status == StatusCarMaintaince.Approve.GetStatusName())
                {
                    status = 3;
                }
                else status = 4;
                Item(false,false,res.TimeSlotNumber,res.DayOfWeekNumber,item.nameCustomer,item.phone,item.idBooking,item.date,true,item.idBooking,status);
                usedPositions.Add(new Position(res.TimeSlotNumber, res.DayOfWeekNumber));

            }
            for (int row = 1; row <= 5; row++) // 5 time slots
            {
                for (int col = 1; col <= 7; col++) // 7 days
                {
                    var position = new Position(row, col);
                    if (!usedPositions.Contains(position))
                    {
                        Item(false, false, row, col, "", "", 0, null, false);
                    }
                }
            }

        }
        private void Item(bool isTimeSlot, bool isRowTimeTableHeader, int indexInTableRow, int indexCol, string name, string phoneNumber, int idBooking, DateTime? date = null, bool? isBook = null,int idDatLich=0,int status=3)
        {
            // Tạo container
            Panel itemContainer = new Panel();
            itemContainer.Width = isTimeSlot ? WidthTimeTable : (int)((widthSearchPanel - WidthTimeTable) / 7);
            itemContainer.BorderStyle = BorderStyle.FixedSingle;
            itemContainer.Height = isRowTimeTableHeader ? 50 : (Wrap.Height -110) / 5;
           

            // Tính toán vị trí X
            int xPosition;
            if (indexCol == 0)
            {
                xPosition = 0;
            }
            else
            {
                xPosition = WidthTimeTable + ((indexCol - 1) * (widthSearchPanel - WidthTimeTable) / 7);
            }

            // Tính toán vị trí Y
            int yPosition;
            if (indexInTableRow == 0)
            {
                yPosition = header.Bottom;
            }
            else
            {
                yPosition = 30 + (indexInTableRow * (Wrap.Height - 110) / 5);
            }

            itemContainer.Location = new Point(xPosition, yPosition);
            itemContainer.BackColor = isBook == null ? Color.White : isBook == false ? Color.WhiteSmoke :status==4?Color.Aqua: Color.LightBlue;

            // Tạo label hiển thị nội dung
            Label nameUser = new Label();

            // Xử lý hiển thị text tùy theo loại ô
            if (isRowTimeTableHeader||name=="TimeSlot")
            {
                // Hiển thị thứ và ngày ở hàng đầu
                nameUser.Text = indexCol == 0 ? name :
                               name + "\n" + (date.HasValue ? date.Value.ToString("dd/MM/yyyy") : "");
                nameUser.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (isTimeSlot)
            {
                // Hiển thị khung giờ ở cột đầu
                nameUser.Text = name;
                nameUser.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                // Hiển thị thông tin booking
                nameUser.Text = name +'\n'+ phoneNumber;
                nameUser.TextAlign = ContentAlignment.MiddleLeft;
            }

            nameUser.ForeColor = Color.Black;
            //nameUser.Dock = DockStyle.Fill;
            nameUser.Padding = new Padding(5, 0, 0, 0);
            nameUser.Height = 40;

          

            Button DoneMaintainece = new Button();
            DoneMaintainece.Text = "Done";
            DoneMaintainece.ForeColor = Color.White;
            DoneMaintainece.BackColor = Color.Green;
            DoneMaintainece.FlatStyle = FlatStyle.Flat;
            DoneMaintainece.FlatAppearance.BorderSize = 0;
            DoneMaintainece.Visible = false;
            DoneMaintainece.Width = 60;
            DoneMaintainece.Height = 30;
            DoneMaintainece.Location = new Point(30, 40);

            DoneMaintainece.Click += (sender, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to mark this maintenance as complete?", "Confirm Completion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the status in the database
                    if ( idBooking!= null)
                    {
                        var dl = _db.DatLichBaoDuongXe.Find(idBooking);
                        dl.TrangThai = StatusCarMaintaince.Completed.GetStatusName();
                        _db.SaveChanges();
                        Wrap.Controls.Clear();
                        InitHeader();
                        Wrap.Controls.Add(header);
                        listsPerson = _bookings.getListCarBookingInWeekyly();


                        DayInWeek();
                    }
                    else
                    {
                        MessageBox.Show("Item or TheoDoiId is null.");
                    }

                    DoneMaintainece.Visible = false;  // Hide the button
                }
            };

            itemContainer.Click += (sender, e) =>
            {
                if (idBooking != 0&&status!=4)
                {
                    DoneMaintainece.Visible = !DoneMaintainece.Visible;
                }
            };

            itemContainer.Controls.Add(nameUser);
          
            itemContainer.Controls.Add(DoneMaintainece);

            Wrap.Controls.Add(itemContainer);
        }
        public (int DayOfWeekNumber, int TimeSlotNumber) GetDayAndTimeSlot(DateTime? date, TimeSpan time)
            {

            DateTime dateOfWeek = date ?? DateTime.Now;

            // Xác định ngày trong tuần (1: Thứ 2, ..., 7: Chủ Nhật)
            int dayOfWeekNumber = dateOfWeek.DayOfWeek switch
                {
                    DayOfWeek.Monday => 1,
                    DayOfWeek.Tuesday => 2,
                    DayOfWeek.Wednesday => 3,
                    DayOfWeek.Thursday => 4,
                    DayOfWeek.Friday => 5,
                    DayOfWeek.Saturday => 6,
                    DayOfWeek.Sunday => 7,
                    _ => 0 // Trường hợp không hợp lệ
                };

                // Xác định khung giờ (1: 8-10, 2: 10-12, 3: 13-15, 4: 15-17)
                int timeSlotNumber = time switch
                {
                    var t when t >= new TimeSpan(8, 0, 0) && t < new TimeSpan(10, 0, 0) => 1,
                    var t when t >= new TimeSpan(10, 0, 0) && t < new TimeSpan(12, 0, 0) => 2,
                    var t when t >= new TimeSpan(12, 0, 0) && t < new TimeSpan(14, 0, 0) => 3,
                    var t when t >= new TimeSpan(14, 0, 0) && t < new TimeSpan(16, 0, 0) => 4,
                    var t when t >= new TimeSpan(16, 0, 0) && t < new TimeSpan(18, 0, 0) => 4,
                    _ => 0 // Ngoài các khung giờ
                };

                return (dayOfWeekNumber, timeSlotNumber);
            }

           
        #endregion
    }
}
