using Garage.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Garage.Data.Models;

namespace Garage.Forms.MainForm
{
    public partial class FormAddTransaction : Form
    {
        private GaraOtoDbContext _context;
        private int? _currentCarId;
        private int? _currentUserId;
        private int? _currentMaintenanceId;
        private int? _currentInvoiceId;
        public FormAddTransaction(GaraOtoDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
        private void SetCurrentIds(int userId, int carId)
        {
            _currentUserId = userId;
            _currentCarId = carId;
        }

        private void createNewDsDonBaoDuongXe()
        {
            if (!_currentCarId.HasValue) return;

            var newMaintenance = new DSDonBaoDuongXe
            {
                XeID = _currentCarId,
                NgayBaoDuong = dateTransactions.Value,
                ThoiGianBaoDuong = DateTime.Now.TimeOfDay,
                MucTieuBaoDuong = "Bảo dưỡng định kỳ", // Or get from form if available
             
            };

            _context.DSDonBaoDuongXe.Add(newMaintenance);
            _context.SaveChanges();

            _currentMaintenanceId = newMaintenance.DonBaoDuongID;
        }

        private void createNewHoaDon()
        {
            if (!_currentUserId.HasValue) return;

            var newInvoice = new HoaDon
            {
                NguoiDungID = _currentUserId,
                NgayGiaoDich = dateTransactions.Value,
                LoaiGiaoDich = "Bảo dưỡng", // Or get from form if you have different types
                GhiChu = issuelsInput.Text // Assuming this is where you store notes
            };

            _context.HoaDon.Add(newInvoice);
            _context.SaveChanges();

            _currentInvoiceId = newInvoice.HoaDonID;
        }

        private void createNewHoaDonLinhKien()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var selectedPart = selectParts.SelectedItem as LinhKien;
                    if (selectedPart == null)
                    {
                        var partName = selectParts.SelectedItem.ToString();
                        selectedPart = _context.LinhKien
                            .FirstOrDefault(p => p.TenLinhKien == partName);

                        if (selectedPart == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin linh kiện!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Kiểm tra và parse số lượng
                    if (!int.TryParse(numPartsInput.Text.Trim(), out int quantity) || quantity <= 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy thông tin linh kiện mới nhất từ database
                    var currentPart = _context.LinhKien
                        .FirstOrDefault(p => p.LinhKienID == selectedPart.LinhKienID);

                    if (currentPart == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin linh kiện trong kho!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra số lượng tồn kho
                    if (currentPart.SoLuong < quantity)
                    {
                        MessageBox.Show($"Số lượng trong kho không đủ! Hiện chỉ còn {currentPart.SoLuong} sản phẩm",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật số lượng tồn kho
                    currentPart.SoLuong -= quantity;
                    _context.LinhKien.Update(currentPart);

                    // Tạo hóa đơn linh kiện mới
                    var newPartInvoice = new HoaDonLinhKien
                    {
                        HoaDonID = _currentInvoiceId.Value,
                        LinhKienID = selectedPart.LinhKienID,
                        SoLuong = quantity,
                      
                    };

                    _context.HoaDonLinhKien.Add(newPartInvoice);

                    // Lưu các thay đổi
                    _context.SaveChanges();

                    // Commit transaction nếu mọi thứ OK
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction.Rollback();
                    MessageBox.Show($"Đã xảy ra lỗi khi lưu hóa đơn linh kiện: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void createNewLichSuDichVu()
        {
            NhanVien selectedStaff;
            if (staffFullName.SelectedItem is NhanVien)
            {
                selectedStaff = staffFullName.SelectedItem as NhanVien;
            }
            else
            {
                // Nếu ComboBox chỉ lưu tên nhân viên
                var staffName = staffFullName.SelectedItem.ToString();
                selectedStaff = _context.NhanVien
                    .FirstOrDefault(s => s.HoTen == staffName);

                if (selectedStaff == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Lấy DichVu từ ComboBox
            DichVu selectedService;
            if (selectServices.SelectedItem is DichVu)
            {
                selectedService = selectServices.SelectedItem as DichVu;
            }
            else
            {
                // Nếu ComboBox chỉ lưu tên dịch vụ
                var serviceName = selectServices.SelectedItem.ToString();
                selectedService = _context.DichVu
                    .FirstOrDefault(s => s.TenDichVu == serviceName);

                if (selectedService == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var newServiceHistory = new LichSuDichVu
            {
                DonBaoDuongID = _currentMaintenanceId.Value,
                NhanVienID = selectedStaff.NhanVienID,
                DichVuID = selectedService.DichVuID,
                GhiChu = issuelsInput.Text
            };

            _context.LichSuDichVu.Add(newServiceHistory);
            _context.SaveChanges();
        }


        private void createNewTheoDoiBaoDuong()
        {
            if (!_currentMaintenanceId.HasValue) return;

            var newMaintenanceTracking = new TheoDoiBaoDuong
            {
                DonBaoDuongID = _currentMaintenanceId,
                VanDe = issuelsInput.Text,
                DaGiaiQuyet = true, // Initial status
                CachGiaiQuyet = solutionInput.Text
            };

            _context.TheoDoiBaoDuong.Add(newMaintenanceTracking);
            _context.SaveChanges();
        }

        private void ProcessUserAndCar(string phoneNumber)
        {
            var existingUser = _context.NguoiDung.FirstOrDefault(i => i.SoDienThoai == phoneNumber);

            if (existingUser == null)
            {
                var existingCar = _context.XeOTo.FirstOrDefault(c =>
                    
                    c.BienSoXe == BienSoXeInput.Text.Trim());
                if (existingCar != null)
                {
                    MessageBox.Show("Biển số xe đã được sử dụng");
                    this.Hide();
                    return;
                }
                else
                {
                    // Case 1: New user
                    var newUser = CreateNewUser();
                    var newCar = CreateCarForUser(newUser.NguoiDungID);
                    SetCurrentIds(newUser.NguoiDungID, newCar.XeID);
                }
            }
            else
            {
                var existingCar = _context.XeOTo.FirstOrDefault(c =>
                    c.NguoiDungID == existingUser.NguoiDungID &&
                    c.BienSoXe == BienSoXeInput.Text.Trim());

                if (existingCar == null)
                {
                    // Case 2a: Existing user, new car
                    var newCar = CreateCarForUser(existingUser.NguoiDungID);
                    SetCurrentIds(existingUser.NguoiDungID, newCar.XeID);
                }
                else
                {
                    // Case 2b: Existing user, existing car
                    SetCurrentIds(existingUser.NguoiDungID, existingCar.XeID);
                }
            }

            // Create related records in the correct order
            createNewDsDonBaoDuongXe();  // Creates maintenance record first
            createNewHoaDon();           // Creates invoice second
            createNewHoaDonLinhKien();   // Uses invoice ID
            createNewLichSuDichVu();     // Uses maintenance ID
            createNewTheoDoiBaoDuong();  // Uses maintenance ID

            this.Close();
        }

        // Update CreateCarForUser to return the created car
        private XeOTo CreateCarForUser(int userId)
        {
            
        
            var newCar = new XeOTo
            {
                NguoiDungID = userId,
                Model = inputModel.Text.Trim(),
                HangXe = InputBrand.Text.Trim(),
                BienSoXe = BienSoXeInput.Text.Trim(),
                HinhAnh = "D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png",
                NamSanXuat = 0,
                MauSac = "không cung cấp"
            };

            _context.XeOTo.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }
        private NguoiDung CreateNewUser()
        {
            var newUser = new NguoiDung
            {
                GioiTinhID = 3,
                HoTen = FullNameBox.Text.Trim(),
                SoDienThoai = PhoneCall.Text.Trim(),
                DiaChi = "",
                NgayThamGia = dateTransactions.Value,
                NgaySinh = new DateTime(1900, 1, 1),
                Email = "",
                HinhAnh = "D:\\btlWinform\\Garage\\Garage\\Resources\\Icons\\image-removebg-preview.png"
            };

            _context.NguoiDung.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        private bool CheckIfCarExists(int userId)
        {
            return _context.XeOTo.Any(c =>
                c.NguoiDungID == userId &&
                c.BienSoXe == BienSoXeInput.Text.Trim());
        }

    

        private void CreateRelatedRecords()
        {
            createNewDsDonBaoDuongXe();
            createNewHoaDon();
            createNewHoaDonLinhKien();
            createNewLichSuDichVu();
            createNewTheoDoiBaoDuong();
        }

        public void btn_save(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to save this transaction?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes && ValidateForm())
            {
                ProcessUserAndCar(PhoneCall.Text.Trim());
            }
        }


    
      
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác minh
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this transaction?",  
                "Confirmation",                                      
                MessageBoxButtons.YesNo,                             
                MessageBoxIcon.Question                            
            );

            // Kiểm tra phản hồi của người dùng
            if (result == DialogResult.Yes)
            {
                
                this.Hide();
            }
        }


        private bool ValidateForm()
        {
            DateTime dateTransactionSelected = dateTransactions.Value;
            DateTime startDate = new DateTime(2023, 1, 1);

            // Ngày hiện tại
            DateTime currentDate = DateTime.Now;
            if (dateTransactionSelected < startDate && dateTransactionSelected > currentDate)
            {
                MessageBox.Show("The selected date must be less than or equal to today's date and greater than January 1, 2023");
                return false;
            }
            string nameUser= FullNameBox.Text;
            if (string.IsNullOrEmpty(nameUser)) {
                MessageBox.Show("Data FullName can not be null or empty.");
                return false;
            }
            string pattern = @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸỳỵýỷỹ\s]+$";

            // Kiểm tra với Regex
            if (!Regex.IsMatch(nameUser, pattern))
            {
                MessageBox.Show("Name is invalid. Please avoid special characters and number!");
            }
            string phoneNumber=PhoneCall.Text;
            if (string.IsNullOrEmpty(phoneNumber)) {
                MessageBox.Show("Data Phone can not be null or empty.");
                return false;
            }
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Phone number can only contain digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra độ dài và ký tự bắt đầu
            if (phoneNumber.Length != 10 && phoneNumber.Length != 11)
            {
                MessageBox.Show("Phone number must be 10 or 11 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!phoneNumber.StartsWith("0"))
            {
                MessageBox.Show("Phone number must start with 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string brand=InputBrand.Text;
            if (string.IsNullOrEmpty(brand)) {
                MessageBox.Show("Data Brand of Car can not be null or empty.");
                return false;
            }
            string patternBrand = @"^[a-zA-Z\s]+$";
            if (!Regex.IsMatch(brand.Trim(), patternBrand))
            {
                MessageBox.Show("brand must contain only letters (a-z, A-Z) and no special characters or accents in"+brand, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string modelcar=inputModel.Text;
            if (string.IsNullOrEmpty(modelcar))
            {
                MessageBox.Show("Data Model of Car can not be null or empty.");
                return false;

            }
            if (!Regex.IsMatch(modelcar, patternBrand))
            {
                MessageBox.Show("model must contain only letters (a-z, A-Z) and no special characters or accents. in"+modelcar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string staffName=staffFullName.Text;
            if (string.IsNullOrEmpty(staffName)) {
                MessageBox.Show("You must select Your Name.");
                return false;
            }
            string parts=selectParts.Text;
           
            string nums=numPartsInput.Text;
            if (!string.IsNullOrEmpty(nums) &&string.IsNullOrEmpty(parts)) {
                MessageBox.Show("You must select Parts.");
                return false;
            }
            if (!string.IsNullOrEmpty(parts) && string.IsNullOrEmpty(nums))
            {
                MessageBox.Show("You must type nums of parts.");
                return false;

            }
            // Kiểm tra nếu không phải là số nguyên
            if (!int.TryParse(nums, out _))
            {
                MessageBox.Show("Nums Of Part must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string services =selectServices.Text;
            if (string.IsNullOrEmpty(services)) {
                MessageBox.Show("services is null.");
                return false;
            }
            string issues=issuelsInput.Text;
            if (string.IsNullOrEmpty(issues)&&string.IsNullOrEmpty(parts)) {
                MessageBox.Show("issuelsInput and parts is null.\nYou must select one of two");
                return false;
            }
            string solution=solutionInput.Text;
            if (string.IsNullOrEmpty(solution)) {
                MessageBox.Show("solutionInput is null.");
                return false;
            }
            string licensePlate=BienSoXeInput.Text;
         if (ValidateLicensePlate(licensePlate) == false)
            {
                MessageBox.Show("licensePlate không hợp lệ . phải đúng dạng 34B2-383.83");
                return false;
            }


            return true;
        }
    }
}
