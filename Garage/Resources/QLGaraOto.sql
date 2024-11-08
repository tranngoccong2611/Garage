




-- Tạo Cơ sở dữ liệu
CREATE DATABASE QLGaraOtoBTL;
GO
select * from DichVu
USE QLGaraOtoBTL;
select * from NguoiDung
ALTER TABLE NguoiDung
ADD NgayThamGia DATE NOT NULL DEFAULT '2024-10-12';

GO
-- Bảng GioiTinh (Bảng tra cứu cho giới tính)
CREATE TABLE GioiTinh (
    GioiTinhID INT PRIMARY KEY IDENTITY(1,1),
    TenGioiTinh NVARCHAR(10) UNIQUE NOT NULL
);
go
-- Bảng ChucVu (Bảng tra cứu cho chức vụ)
CREATE TABLE ChucVu (
    ChucVuID INT PRIMARY KEY IDENTITY(1,1),
    TenChucVu NVARCHAR(50) UNIQUE NOT NULL
);
go
alter table ChucVu
add MucLuong int not null default 0;
CREATE TABLE DichVu (
    DichVuID INT PRIMARY KEY IDENTITY(1,1),
    TenDichVu NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255),
    Gia DECIMAL(18, 2) NOT NULL,
  
);
go

-- Bảng NhanVien (Lưu trữ thông tin nhân viên)
CREATE TABLE NhanVien (
    NhanVienID INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinhID INT FOREIGN KEY REFERENCES GioiTinh(GioiTinhID),
    NgaySinh DATE,
    SoDienThoai NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    ChucVuID INT FOREIGN KEY REFERENCES ChucVu(ChucVuID),
    DiaChi NVARCHAR(255),
    HinhAnh VARCHAR(200)
);
GO
select * from DSDonBaoDuongXe
-- Bảng NguoiDung (Lưu trữ thông tin người dùng)
CREATE TABLE NguoiDung (
    NguoiDungID INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinhID INT FOREIGN KEY REFERENCES GioiTinh(GioiTinhID),
    NgaySinh DATE,
    SoDienThoai NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(255),
    HinhAnh VARCHAR(200)
);
GO
select * from NguoiDung
update  NguoiDung 
set NgayThamGia ='2024-09-22'
where NguoiDungId='1'

-- Bảng XeOTo (Lưu trữ thông tin xe ô tô bảo dưỡng của người dùng)
CREATE TABLE XeOTo (
    XeID INT PRIMARY KEY IDENTITY(1,1),
    NguoiDungID INT FOREIGN KEY REFERENCES NguoiDung(NguoiDungID),
    BienSoXe NVARCHAR(20) NOT NULL UNIQUE,
    HangXe NVARCHAR(50),
    Model NVARCHAR(50),
    NamSanXuat SMALLINT,
    MauSac NVARCHAR(20),
    HinhAnh VARCHAR(200)
);
GO
select * from LinhKien
-- Tạo chỉ mục cho NguoiDungID trên bảng XeOTo để tăng tốc truy vấn
CREATE INDEX idx_NguoiDungID_XeOTo ON XeOTo(NguoiDungID);

-- Bảng CSKH (Lưu trữ thông tin chăm sóc khách hàng)
CREATE TABLE CSKH (
    CSKHID INT PRIMARY KEY IDENTITY(1,1),
    NguoiDungID INT FOREIGN KEY REFERENCES NguoiDung(NguoiDungID),
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
    NgayChamSoc DATE,
    PhuongThucLienHe NVARCHAR(50),
    NoiDungTraoDoi NVARCHAR(255)
);
GO

-- Tạo chỉ mục cho NguoiDungID và NhanVienID trên bảng CSKH để tăng tốc truy vấn
CREATE INDEX idx_NguoiDungID_CSKH ON CSKH(NguoiDungID);
CREATE INDEX idx_NhanVienID_CSKH ON CSKH(NhanVienID);

-- Bảng DSDonBaoDuongXe (Lưu thông tin các đơn bảo dưỡng xe của khách hàng)
CREATE TABLE DSDonBaoDuongXe (
    DonBaoDuongID INT PRIMARY KEY IDENTITY(1,1),
    XeID INT FOREIGN KEY REFERENCES XeOTo(XeID),
    NgayBaoDuong DATE CHECK (NgayBaoDuong >= '2000-01-01'),
    ThoiGianBaoDuong TIME,
    MucTieuBaoDuong NVARCHAR(255)
);
GO

-- Tạo chỉ mục cho XeID trên bảng DSDonBaoDuongXe để tăng tốc truy vấn
CREATE INDEX idx_XeID_DSDonBaoDuongXe ON DSDonBaoDuongXe(XeID);

-- Bảng LichSuDichVu (Lưu thông tin lịch sử dịch vụ bảo dưỡng của khách hàng)
CREATE TABLE LichSuDichVu (
    LichSuDichVuID INT PRIMARY KEY IDENTITY(1,1),
    DonBaoDuongID INT FOREIGN KEY REFERENCES DSDonBaoDuongXe(DonBaoDuongID),
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
    DichVuID int foreign key references DichVu(DichVuID),
    NgayThucHien DATE,
    GhiChu NVARCHAR(255)
);
GO


-- Bảng HangLinhKienOto (Lưu trữ thông tin các linh kiện ô tô còn trong gara)
CREATE TABLE LinhKien (
    LinhKienID INT PRIMARY KEY IDENTITY(1,1),
    TenLinhKien NVARCHAR(100),
    SoLuong INT CHECK (SoLuong >= 0),
    Gia DECIMAL(18, 2) CHECK (Gia >= 0),
    MoTa NVARCHAR(255),
    HinhAnh VARCHAR(200)
);
GO

-- Bảng HoaDon (Lưu thông tin các giao dịch giữa người dùng và gara ô tô)
CREATE TABLE HoaDon (
    HoaDonID INT PRIMARY KEY IDENTITY(1,1),
    NguoiDungID INT FOREIGN KEY REFERENCES NguoiDung(NguoiDungID),
    NgayGiaoDich DATE,
    SoTien DECIMAL(18, 2) CHECK (SoTien >= 0),
    LoaiGiaoDich NVARCHAR(50),
    GhiChu NVARCHAR(255)
);
GO
select * from HoaDon

-- Bảng HoaDonLinhKien (Liên kết hóa đơn và linh kiện)
CREATE TABLE HoaDonLinhKien (
    HoaDonLinhKienID INT PRIMARY KEY IDENTITY(1,1),
    HoaDonID INT FOREIGN KEY REFERENCES HoaDon(HoaDonID),
    LinhKienID INT FOREIGN KEY REFERENCES LinhKien(LinhKienID),
    SoLuong INT CHECK (SoLuong >= 0)
);
GO
SELECT SUM(hl.SoLuong * lk.Gia) AS TotalRevenue
FROM HoaDonLinhKien hl
JOIN HoaDon hd ON hl.HoaDonID = hd.HoaDonID
JOIN LinhKien lk ON hl.LinhKienID = lk.LinhKienID
SELECT SUM(dv.Gia) AS TotalRevenue
FROM LichSuDichVu lsdv
JOIN DichVu dv ON lsdv.DichVuID = dv.DichVuID;


-- Bảng TheoDoiBaoDuong (Lưu thông tin các vấn đề bảo dưỡng đã và chưa được giải quyết)
CREATE TABLE TheoDoiBaoDuong (
    TheoDoiID INT PRIMARY KEY IDENTITY(1,1),
    DonBaoDuongID INT FOREIGN KEY REFERENCES DSDonBaoDuongXe(DonBaoDuongID),
    VanDe NVARCHAR(255),
    DaGiaiQuyet BIT DEFAULT 0 CHECK (DaGiaiQuyet IN (0, 1)),
    CachGiaiQuyet NVARCHAR(255)
);
GO

-- Trigger để tự động giảm số lượng linh kiện khi tạo mới HoaDonLinhKien

CREATE TRIGGER trg_UpdateSoLuongLinhKien
ON HoaDonLinhKien
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted i JOIN LinhKien lk ON i.LinhKienID = lk.LinhKienID WHERE lk.SoLuong < i.SoLuong)
    BEGIN
        RAISERROR ('Số lượng linh kiện không đủ', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE LinhKien
    SET LinhKien.SoLuong = LinhKien.SoLuong - i.SoLuong
    FROM inserted i
    WHERE LinhKien.LinhKienID = i.LinhKienID;
END;



SELECT LoaiGiaoDich, SUM(SoTien) AS TongDoanhThu
FROM HoaDon
GROUP BY LoaiGiaoDich
ORDER BY TongDoanhThu DESC;
SELECT lk.TenLinhKien, 
       SUM(hl.SoLuong * lk.Gia) AS TongTienBan
FROM HoaDonLinhKien hl
JOIN LinhKien lk ON hl.LinhKienID = lk.LinhKienID
GROUP BY lk.TenLinhKien
ORDER BY TongTienBan DESC;
SELECT SUM(hl.SoLuong * lk.Gia) AS TongTienBanTatCa
FROM HoaDonLinhKien hl
JOIN LinhKien lk ON hl.LinhKienID = lk.LinhKienID;
CREATE FUNCTION dbo.GetTotalPartsSoldAmount()
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @total DECIMAL(18, 2);
    
    SELECT @total = SUM(hl.SoLuong * lk.Gia)
    FROM HoaDonLinhKien hl
    JOIN LinhKien lk ON hl.LinhKienID = lk.LinhKienID
    

    RETURN ISNULL(@total, 0); -- Trả về 0 nếu không có giá trị
END;
SELECT dbo.GetTotalPartsSoldAmount() AS TotalPartsSoldAmount;

go
CREATE FUNCTION dbo.TinhTongTienHoaDonDichVu()
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(18, 2);

    SELECT @TongTien = SUM(h.SoTien)
    FROM HoaDon h
    JOIN LichSuDichVu lsdv ON h.HoaDonID = lsdv.DonBaoDuongID;

    RETURN @TongTien;
END;
SELECT dbo.TinhTongTienHoaDonDichVu() AS TongTienHoaDonDichVu;


select * from ChucVu
-- View để xem lịch sử bảo dưỡng
CREATE VIEW vw_LichSuBaoDuong AS
SELECT ls.DichVu, ls.NgayThucHien, ls.GhiChu, nv.HoTen AS TenNhanVien, nd.HoTen AS TenKhachHang, xe.BienSoXe
FROM LichSuDichVu ls
JOIN NhanVien nv ON ls.NhanVienID = nv.NhanVienID
JOIN DSDonBaoDuongXe dbd ON ls.DonBaoDuongID = dbd.DonBaoDuongID
JOIN XeOTo xe ON dbd.XeID = xe.XeID
JOIN NguoiDung nd ON xe.NguoiDungID = nd.NguoiDungID;
GO

-- Bảng DatLichBaoDuongXe (Lưu thông tin các đơn đặt lịch bảo dưỡng xe của khách hàng)
CREATE TABLE DatLichBaoDuongXe (
    DatLichBaoDuongID INT PRIMARY KEY IDENTITY(1,1),
    NguoiDungID INT FOREIGN KEY REFERENCES NguoiDung(NguoiDungID),
    XeID INT FOREIGN KEY REFERENCES XeOTo(XeID),
    NgayDatLich DATE NOT NULL CHECK (NgayDatLich >= GETDATE()),
    ThoiGianDatLich TIME NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT 'Đang chờ xác nhận' -- Trạng thái mặc định
);
GO
create table Admin(
	TenTaiKhoan nvarchar(200) not null,
	MatKhau nvarchar(10) not null,

);
alter table Admin
add AdminId int  PRIMARY KEY IDENTITY(1,1)
go
ALTER TABLE Admin
ALTER COLUMN MatKhau NVARCHAR(256)
select * from Admin
insert into Admin (TenTaiKhoan,MatKhau) values('PhongNguyen','123456');
insert into Admin (TenTaiKhoan,MatKhau) values('MinhTan','12345@');
insert into Admin (TenTaiKhoan,MatKhau) values('CongTran','123456@');
insert into Admin (TenTaiKhoan,MatKhau) values('QuocCuong123','123456@@');
update Admin
set MatKhau='123456@@'
where TenTaiKhoan='QuocCuong123'
-- Hàm tính doanh thu linh kiện theo tháng và năm
go
CREATE FUNCTION dbo.TinhDoanhThuLinhKienTheoThangNam (
    @Thang INT,
    @Nam INT
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThuLinhKien DECIMAL(18, 2);

    SELECT @TongDoanhThuLinhKien = SUM(hl.SoLuong * lk.Gia)
    FROM HoaDonLinhKien hl
    JOIN HoaDon hd ON hl.HoaDonID = hd.HoaDonID
    JOIN LinhKien lk ON hl.LinhKienID = lk.LinhKienID
    WHERE MONTH(hd.NgayGiaoDich) = @Thang AND YEAR(hd.NgayGiaoDich) = @Nam;

    RETURN ISNULL(@TongDoanhThuLinhKien, 0); -- Trả về 0 nếu không có doanh thu
END;
GO

-- Hàm tính doanh thu dịch vụ theo tháng và năm
CREATE FUNCTION dbo.TinhDoanhThuDichVuTheoThangNam (
    @Thang INT,
    @Nam INT
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThuDichVu DECIMAL(18, 2);

    SELECT @TongDoanhThuDichVu = SUM(dv.Gia)
    FROM DichVu dv
    JOIN LichSuDichVu lsdv ON dv.DichVuID = lsdv.DichVuID
	join TheoDoiBaoDuong td on td.DonBaoDuongID=lsdv.DonBaoDuongID
    WHERE MONTH(lsdv.NgayThucHien) = @Thang AND YEAR(lsdv.NgayThucHien) = @Nam;

    RETURN ISNULL(@TongDoanhThuDichVu, 0); -- Trả về 0 nếu không có doanh thu
END;
GO
select * from HoaDon
SELECT dbo.TinhDoanhThuLinhKienTheoThangNam(1, 2023) AS DoanhThuLinhKienThang10_2023;

SELECT dbo.TinhDoanhThuDichVuTheoThangNam(1, 2024) AS DoanhThuDichVuThang1_2024;


-- Tạo chỉ mục cho NguoiDungID và XeID trên bảng DatLichBaoDuongXe để tăng tốc truy vấn
CREATE INDEX idx_NguoiDungID_DatLichBaoDuongXe ON DatLichBaoDuongXe(NguoiDungID);
CREATE INDEX idx_XeID_DatLichBaoDuongXe ON DatLichBaoDuongXe(XeID);
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ChucVu';
CREATE LOGIN NguyenPhong WITH PASSWORD = '123456';
go
-- Chuyển sang cơ sở dữ liệu mục tiêu
USE QLGaraOtoBTL; -- Thay tên cơ sở dữ liệu của bạn
go
-- Tạo user từ login đã tạo
CREATE USER NguyenPhong FOR LOGIN NguyenPhong;
-- Cấp quyền cho user NguyenPhong
GRANT INSERT, UPDATE, DELETE ON dbo.Admin TO NguyenPhong; -- Thay 'dbo.Admin' bằng tên bảng bạn muốn cấp quyền
-- Cấp quyền cho user NguyenPhong
GRANT INSERT, UPDATE, DELETE ON NguoiDung TO NguyenPhong;
GRANT INSERT, UPDATE, DELETE ON NhanVien TO NguyenPhong; 
GRANT INSERT, UPDATE, DELETE ON LinhKien TO NguyenPhong;-- Thay 'dbo.Admin' bằng tên bảng bạn muốn cấp quyền
GRANT INSERT, UPDATE, DELETE ON XeOTo TO NguyenPhong;
CREATE LOGIN MinhTan WITH PASSWORD = '12345678'; -- Đặt mật khẩu mạnh
-- Tạo user cho User1
USE QLGaraOtoBTL; -- Chuyển sang cơ sở dữ liệu mục tiêu
CREATE USER MinhTan FOR LOGIN MinhTan;

-- Tạo login cho User2
CREATE LOGIN CongTran WITH PASSWORD = '1234567'; -- Đặt mật khẩu mạnh
-- Tạo user cho User2
CREATE USER CongTran FOR LOGIN CongTran;

-- Cấp quyền cập nhật cho User1 và User2
GRANT UPDATE ON dbo.Admin TO MinhTan; -- Thay 'dbo.Admin' bằng tên bảng bạn muốn cấp quyền
GRANT UPDATE ON dbo.Admin TO CongTran; -- Thay 'dbo.Admin' bằng tên bảng bạn muốn cấp quyền
-- Thêm dữ liệu vào bảng GioiTinh
INSERT INTO GioiTinh (TenGioiTinh) VALUES (N'Nam');
INSERT INTO GioiTinh (TenGioiTinh) VALUES (N'Nữ');
INSERT INTO GioiTinh (TenGioiTinh) VALUES (N'Khác');

-- Thêm dữ liệu vào bảng ChucVu
INSERT INTO ChucVu (TenChucVu) VALUES (N'Quản lý');
INSERT INTO ChucVu (TenChucVu) VALUES (N'Nhân viên kỹ thuật');
INSERT INTO ChucVu (TenChucVu) VALUES (N'Thợ sửa chữa');
INSERT INTO ChucVu (TenChucVu) VALUES (N'Lễ tân');
INSERT INTO ChucVu (TenChucVu) VALUES (N'Chăm sóc khách hàng');
UPDATE ChucVu
SET MucLuong = 5000000
WHERE ChucVuID = 1;

UPDATE ChucVu
SET MucLuong = 7000000
WHERE ChucVuID = 2;

UPDATE ChucVu
SET MucLuong = 10000000
WHERE ChucVuID = 3;

UPDATE ChucVu
SET MucLuong = 15000000
WHERE ChucVuID = 4;
UPDATE ChucVu
SET MucLuong = 20000000
WHERE ChucVuID = 5;


alter table DichVu
drop column LoaiDichVuID
-- Thêm dữ liệu vào bảng DichVu
INSERT INTO DichVu (LoaiDichVuID, TenDichVu, MoTa, Gia) VALUES 
(1, N'Bảo dưỡng định kỳ', N'Kiểm tra và bảo dưỡng xe định kỳ', 500000),
(2, N'Sửa chữa động cơ', N'Sửa chữa và bảo dưỡng động cơ', 2000000),
(3, N'Thay dầu', N'Thay dầu động cơ và kiểm tra tổng quát', 300000),
(4, N'Rửa xe', N'Dịch vụ rửa xe toàn diện', 100000),
(5, N'Kiểm tra phanh', N'Kiểm tra và bảo dưỡng hệ thống phanh', 150000),
(6, N'Thay lốp xe', N'Thay lốp xe và kiểm tra áp suất', 800000);
select * from DatLichBaoDuongXe where Year(NgayDatLich)='2024'
-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (HoTen, GioiTinhID, NgaySinh, SoDienThoai, Email, ChucVuID, DiaChi, HinhAnh) VALUES 
(N'Nguyễn Văn A', 1, '1990-05-12', '0912345671', 'nguyenvana@example.com', 1, N'Hà Nội', 'nguyenvana.jpg'),
(N'Lê Thị B', 2, '1992-08-23', '0912345672', 'lethib@example.com', 2, N'Hải Phòng', 'lethib.jpg'),
(N'Trần Văn C', 1, '1985-01-15', '0912345673', 'tranvanc@example.com', 3, N'Đà Nẵng', 'tranvanc.jpg'),
(N'Phạm Thị D', 2, '1993-03-09', '0912345674', 'phamthid@example.com', 4, N'Huế', 'phamthid.jpg'),
(N'Hoàng Văn E', 1, '1988-07-25', '0912345675', 'hoangvane@example.com', 5, N'Quảng Ninh', 'hoangvane.jpg'),
(N'Vũ Thị F', 2, '1995-11-30', '0912345676', 'vuthif@example.com', 2, N'Ninh Bình', 'vuthif.jpg'),
(N'Ngô Văn G', 1, '1990-12-20', '0912345677', 'ngovang@example.com', 3, N'Bắc Ninh', 'ngovang.jpg'),
(N'Tạ Thị H', 2, '1987-02-27', '0912345678', 'tathih@example.com', 4, N'Lào Cai', 'tathih.jpg'),
(N'Phan Văn I', 1, '1994-09-12', '0912345679', 'phanvani@example.com', 5, N'Bình Dương', 'phanvani.jpg'),
(N'Đặng Thị J', 2, '1986-06-18', '0912345680', 'dangthij@example.com', 1, N'Cà Mau', 'dangthij.jpg'),
(N'Bùi Văn K', 1, '1983-04-14', '0912345681', 'buivank@example.com', 3, N'TP. Hồ Chí Minh', 'buivank.jpg'),
(N'Trịnh Thị L', 2, '1991-10-05', '0912345682', 'trinhthil@example.com', 2, N'Vĩnh Long', 'trinhthil.jpg'),
(N'Doãn Văn M', 1, '1989-12-02', '0912345683', 'doanvanm@example.com', 4, N'Phú Yên', 'doanvanm.jpg'),
(N'Chử Thị N', 2, '1996-01-18', '0912345684', 'chuthin@example.com', 5, N'Quảng Bình', 'chuthin.jpg'),
(N'Nguyễn Văn O', 1, '1992-07-29', '0912345685', 'nguyenvano@example.com', 2, N'An Giang', 'nguyenvano.jpg');

-- Thêm dữ liệu vào bảng NguoiDung
INSERT INTO NguoiDung (HoTen, GioiTinhID, NgaySinh, SoDienThoai, Email, DiaChi, HinhAnh) VALUES 
(N'Nguyễn Văn A', 1, '1990-05-12', '0912345601', 'nguyenvana1@example.com', N'Hà Nội', 'nguyenvana1.jpg'),
(N'Lê Thị B', 2, '1992-08-23', '0912345602', 'lethib2@example.com', N'Hải Phòng', 'lethib2.jpg'),
(N'Trần Văn C', 1, '1985-01-15', '0912345603', 'tranvanc3@example.com', N'Đà Nẵng', 'tranvanc3.jpg'),
(N'Phạm Thị D', 2, '1993-03-09', '0912345604', 'phamthid4@example.com', N'Huế', 'phamthid4.jpg'),
(N'Hoàng Văn E', 1, '1988-07-25', '0912345605', 'hoangvane5@example.com', N'Quảng Ninh', 'hoangvane5.jpg'),
(N'Vũ Thị F', 2, '1995-11-30', '0912345606', 'vuthif6@example.com', N'Ninh Bình', 'vuthif6.jpg'),
(N'Ngô Văn G', 1, '1990-12-20', '0912345607', 'ngovang7@example.com', N'Bắc Ninh', 'ngovang7.jpg'),
(N'Tạ Thị H', 2, '1987-02-27', '0912345608', 'tathih8@example.com', N'Lào Cai', 'tathih8.jpg'),
(N'Phan Văn I', 1, '1994-09-12', '0912345609', 'phanvani9@example.com', N'Bình Dương', 'phanvani9.jpg'),
(N'Đặng Thị J', 2, '1986-06-18', '0912345610', 'dangthij10@example.com', N'Cà Mau', 'dangthij10.jpg'),
(N'Bùi Văn K', 1, '1983-04-14', '0912345611', 'buivank11@example.com', N'TP. Hồ Chí Minh', 'buivank11.jpg'),
(N'Trịnh Thị L', 2, '1991-10-05', '0912345612', 'trinhthil12@example.com', N'Vĩnh Long', 'trinhthil12.jpg'),
(N'Doãn Văn M', 1, '1989-12-02', '0912345613', 'doanvanm13@example.com', N'Phú Yên', 'doanvanm13.jpg'),
(N'Chử Thị N', 2, '1996-01-18', '0912345614', 'chuthin14@example.com', N'Quảng Bình', 'chuthin14.jpg'),
(N'Nguyễn Văn O', 1, '1992-07-29', '0912345615', 'nguyenvano15@example.com', N'An Giang', 'nguyenvano15.jpg'),
(N'Lý Văn P', 1, '1980-05-14', '0912345616', 'lyvanp16@example.com', N'Hải Dương', 'lyvanp16.jpg'),
(N'Trần Thị Q', 2, '1984-08-19', '0912345617', 'tranthiq17@example.com', N'Bắc Giang', 'tranthiq17.jpg'),
(N'Nguyễn Văn R', 1, '1979-03-01', '0912345618', 'nguyenvanr18@example.com', N'Lâm Đồng', 'nguyenvanr18.jpg'),
(N'Vũ Thị S', 2, '1995-11-25', '0912345619', 'vuthis19@example.com', N'Vĩnh Phúc', 'vuthis19.jpg'),
(N'Trần Văn T', 1, '1991-04-22', '0912345620', 'tranvant20@example.com', N'Thanh Hóa', 'tranvant20.jpg'),
(N'Nguyễn Thị U', 2, '1988-09-10', '0912345621', 'nguyenthieu21@example.com', N'Hòa Bình', 'nguyenthieu21.jpg'),
(N'Phạm Văn V', 1, '1987-07-02', '0912345622', 'phamvanv22@example.com', N'Sơn La', 'phamvanv22.jpg'),
(N'Bùi Thị W', 2, '1993-12-25', '0912345623', 'buithiw23@example.com', N'Hà Giang', 'buithiw23.jpg'),
(N'Trần Văn X', 1, '1990-08-15', '0912345624', 'tranvanx24@example.com', N'Thái Bình', 'tranvanx24.jpg'),
(N'Nguyễn Thị Y', 2, '1986-01-08', '0912345625', 'nguyenthiy25@example.com', N'Nghệ An', 'nguyenthiy25.jpg'),
(N'Hoàng Văn Z', 1, '1984-11-03', '0912345626', 'hoangvanz26@example.com', N'Hậu Giang', 'hoangvanz26.jpg'),
(N'Phan Thị A1', 2, '1992-06-15', '0912345627', 'phanthia1@example.com', N'Tiền Giang', 'phanthia1.jpg'),
(N'Đỗ Văn B1', 1, '1994-03-20', '0912345628', 'dovanb1@example.com', N'Kiên Giang', 'dovanb1.jpg'),
(N'Trương Thị C1', 2, '1985-12-30', '0912345629', 'truongthic1@example.com', N'Bạc Liêu', 'truongthic1.jpg'),
(N'Nguyễn Văn D1', 1, '1990-05-01', '0912345630', 'nguyenvand1@example.com', N'Tây Ninh', 'nguyenvand1.jpg');

-- Thêm dữ liệu vào bảng XeOTo
INSERT INTO XeOTo (NguoiDungID, BienSoXe, HangXe, Model, NamSanXuat, MauSac, HinhAnh) VALUES 
(1, '30A-12345', N'Toyota', N'Camry', 2018, N'Đen', 'toyota_camry.jpg'),
(2, '29B-67890', N'Honda', N'Civic', 2019, N'Xanh', 'honda_civic.jpg'),
(3, '30C-23456', N'Ford', N'Focus', 2017, N'Bạc', 'ford_focus.jpg'),
(4, '31D-34567', N'Hyundai', N'Elantra', 2020, N'Đỏ', 'hyundai_elantra.jpg'),
(5, '32E-45678', N'Toyota', N'Corolla', 2021, N'Trắng', 'toyota_corolla.jpg'),
(6, '33F-56789', N'Kia', N'Cerato', 2019, N'Xám', 'kia_cerato.jpg'),
(7, '34G-67890', N'BMW', N'X5', 2018, N'Xanh lá', 'bmw_x5.jpg'),
(8, '35H-78901', N'Mercedes', N'C300', 2021, N'Đỏ', 'mercedes_c300.jpg'),
(9, '36I-89012', N'Audi', N'A4', 2019, N'Tím', 'audi_a4.jpg'),
(10, '37J-90123', N'Mazda', N'CX-5', 2017, N'Xanh dương', 'mazda_cx5.jpg'),
(11, '38K-12346', N'Toyota', N'Vios', 2020, N'Đen', 'toyota_vios.jpg'),
(12, '39L-23457', N'Honda', N'Accord', 2018, N'Bạc', 'honda_accord.jpg'),
(13, '40M-34568', N'Toyota', N'Innova', 2017, N'Trắng', 'toyota_innova.jpg'),
(14, '41N-45679', N'Ford', N'Everest', 2020, N'Nâu', 'ford_everest.jpg'),
(15, '42O-56780', N'Mazda', N'Mazda 3', 2021, N'Bạc', 'mazda_3.jpg'),
(16, '43P-67891', N'Honda', N'CR-V', 2019, N'Xanh lục', 'honda_crv.jpg'),
(17, '44Q-78902', N'Hyundai', N'Santa Fe', 2021, N'Xám', 'hyundai_santa_fe.jpg'),
(18, '45R-89013', N'Mitsubishi', N'Outlander', 2018, N'Đen', 'mitsubishi_outlander.jpg'),
(19, '46S-90124', N'Suzuki', N'XL7', 2019, N'Trắng', 'suzuki_xl7.jpg'),
(20, '47T-12347', N'Toyota', N'Rush', 2020, N'Xanh', 'toyota_rush.jpg'),
(21, '48U-23458', N'Kia', N'Seltos', 2021, N'Đỏ', 'kia_seltos.jpg'),
(22, '49V-34569', N'Honda', N'Jazz', 2018, N'Xám', 'honda_jazz.jpg'),
(23, '50W-45670', N'Audi', N'Q7', 2019, N'Xanh', 'audi_q7.jpg'),
(24, '51X-56781', N'BMW', N'3 Series', 2017, N'Đen', 'bmw_3_series.jpg'),
(25, '52Y-67892', N'Mercedes', N'E200', 2020, N'Xám', 'mercedes_e200.jpg'),
(26, '53Z-78903', N'Mazda', N'Mazda 6', 2018, N'Trắng', 'mazda_6.jpg'),
(27, '54A-89014', N'Toyota', N'Fortuner', 2019, N'Xanh lục', 'toyota_fortuner.jpg'),
(28, '55B-90125', N'Hyundai', N'Tucson', 2021, N'Đỏ', 'hyundai_tucson.jpg'),
(29, '56C-12348', N'Ford', N'Ranger', 2018, N'Xanh dương', 'ford_ranger.jpg'),
(30, '57D-23459', N'Honda', N'City', 2017, N'Bạc', 'honda_city.jpg'),
(1, '33E-34560', N'Toyota', N'Highlander', 2020, N'Xanh lá', 'toyota_highlander.jpg'),
(2, '33F-45671', N'Mazda', N'Mazda CX-8', 2021, N'Xám', 'mazda_cx8.jpg'),
(3, '34G-56782', N'Kia', N'Optima', 2019, N'Đen', 'kia_optima.jpg'),
(4, '34H-67893', N'Hyundai', N'Accent', 2017, N'Trắng', 'hyundai_accent.jpg'),
(5, '34I-78904', N'Suzuki', N'Celerio', 2021, N'Nâu', 'suzuki_celerio.jpg');

-- Thêm dữ liệu vào bảng CSKH
INSERT INTO CSKH (NguoiDungID, NhanVienID, NgayChamSoc, PhuongThucLienHe, NoiDungTraoDoi) VALUES
(1, 1, '2024-01-05', N'Điện thoại', N'Tư vấn về gói bảo hành xe.'),
(2, 2, '2024-01-10', N'Email', N'Trao đổi về dịch vụ bảo dưỡng xe định kỳ.'),
(3, 3, '2024-01-15', N'Trực tiếp', N'Giải đáp thắc mắc về chi phí bảo trì.'),
(4, 4, '2024-01-20', N'Zalo', N'Hướng dẫn sử dụng dịch vụ cứu hộ.'),
(5, 5, '2024-01-25', N'Điện thoại', N'Tư vấn về chương trình khuyến mãi mới.'),
(6, 6, '2024-02-01', N'Email', N'Hướng dẫn cách đăng ký dịch vụ bảo hiểm.'),
(7, 7, '2024-02-05', N'Điện thoại', N'Chăm sóc khách hàng sau mua xe.'),
(8, 8, '2024-02-10', N'Trực tiếp', N'Gửi thông tin dịch vụ bảo dưỡng VIP.'),
(9, 9, '2024-02-15', N'Email', N'Tư vấn nâng cấp gói bảo hiểm.'),
(10, 10, '2024-02-20', N'Zalo', N'Tư vấn về phụ tùng thay thế.'),
(11, 11, '2024-02-25', N'Điện thoại', N'Hướng dẫn sử dụng hệ thống định vị.'),
(12, 12, '2024-03-01', N'Email', N'Trao đổi về dịch vụ sửa chữa khẩn cấp.'),
(13, 13, '2024-03-05', N'Điện thoại', N'Chăm sóc khách hàng sau khi sử dụng dịch vụ bảo dưỡng.'),
(14, 14, '2024-03-10', N'Trực tiếp', N'Giải đáp về quy trình bảo hành xe.'),
(15, 15, '2024-03-15', N'Zalo', N'Tư vấn các dịch vụ hậu mãi.'),
(16, 4, '2024-03-20', N'Điện thoại', N'Hướng dẫn đăng ký dịch vụ định kỳ.'),
(17, 8, '2024-03-25', N'Email', N'Trao đổi về chính sách đổi trả phụ tùng.'),
(18, 13, '2024-04-01', N'Zalo', N'Tư vấn mua thêm dịch vụ bảo hiểm xe.'),
(19, 4, '2024-04-05', N'Điện thoại', N'Trao đổi về việc gia hạn bảo hành.'),
(20, 8, '2024-04-10', N'Trực tiếp', N'Hướng dẫn sử dụng dịch vụ cứu hộ khẩn cấp.'),
(21, 13, '2024-04-15', N'Email', N'Tư vấn nâng cấp hệ thống an ninh xe.'),
(22, 4, '2024-04-20', N'Điện thoại', N'Giới thiệu chương trình chăm sóc xe VIP.'),
(23, 8, '2024-04-25', N'Trực tiếp', N'Tư vấn các gói dịch vụ bảo trì theo năm.'),
(24,13, '2024-05-01', N'Zalo', N'Trao đổi về bảo trì phụ tùng.'),
(25, 13, '2024-05-05', N'Điện thoại', N'Hỗ trợ kiểm tra lịch sử dịch vụ.'),
(26, 4, '2024-05-10', N'Email', N'Giải đáp thắc mắc về điều khoản bảo hành.'),
(27, 4, '2024-05-15', N'Trực tiếp', N'Hỗ trợ đăng ký dịch vụ sửa chữa định kỳ.'),
(28, 4, '2024-05-20', N'Zalo', N'Tư vấn các dịch vụ nâng cấp xe.'),
(29,4 , '2024-05-25', N'Điện thoại', N'Hướng dẫn bảo dưỡng xe tại nhà.'),
(30, 8, '2024-06-01', N'Email', N'Trao đổi về chính sách bảo hiểm cho xe.');

-- Thêm dữ liệu vào bảng DSDonBaoDuongXe
INSERT INTO DSDonBaoDuongXe (XeID, NgayBaoDuong, ThoiGianBaoDuong, MucTieuBaoDuong) VALUES
(1, '2024-01-05', '09:00:00', N'Kiểm tra hệ thống phanh và lốp.'),
(2, '2024-01-10', '10:30:00', N'Bảo dưỡng động cơ và thay nhớt.'),
(3, '2024-01-15', '11:00:00', N'Kiểm tra hệ thống điều hòa và làm sạch.'),
(4, '2024-01-20', '08:45:00', N'Thay dầu phanh và bảo dưỡng định kỳ.'),
(5, '2024-01-25', '14:00:00', N'Kiểm tra và thay lốp xe.'),
(6, '2024-02-01', '09:30:00', N'Kiểm tra hệ thống điện và ắc quy.'),
(7, '2024-02-05', '13:15:00', N'Bảo dưỡng hệ thống truyền động.'),
(8, '2024-02-10', '10:00:00', N'Vệ sinh nội thất và kiểm tra đèn.'),
(9, '2024-02-15', '15:00:00', N'Bảo dưỡng hệ thống lái.'),
(10, '2024-02-20', '16:30:00', N'Thay thế các bộ phận lọc.'),
(11, '2024-02-25', '08:00:00', N'Kiểm tra hệ thống an toàn và phanh.'),
(12, '2024-03-01', '14:30:00', N'Bảo dưỡng và thay dầu động cơ.'),
(13, '2024-03-05', '09:00:00', N'Thay nước làm mát.'),
(14, '2024-03-10', '11:45:00', N'Kiểm tra hệ thống phanh ABS.'),
(15, '2024-03-15', '10:15:00', N'Kiểm tra và bảo dưỡng hệ thống treo.'),
(16, '2024-03-20', '13:45:00', N'Thay nhớt động cơ và kiểm tra lốp.'),
(17, '2024-03-25', '15:30:00', N'Bảo dưỡng hệ thống làm mát.'),
(18, '2024-04-01', '09:15:00', N'Kiểm tra hệ thống lái và vệ sinh nội thất.'),
(19, '2024-04-05', '12:00:00', N'Thay dầu phanh.'),
(20, '2024-04-10', '14:15:00', N'Kiểm tra đèn và hệ thống điện.'),
(21, '2024-04-15', '08:45:00', N'Kiểm tra ắc quy và hệ thống điện.'),
(22, '2024-04-20', '11:30:00', N'Thay lốp và bảo dưỡng hệ thống lái.'),
(23, '2024-04-25', '13:00:00', N'Bảo dưỡng định kỳ.'),
(24, '2024-05-01', '10:30:00', N'Vệ sinh nội thất và kiểm tra điều hòa.'),
(25, '2024-05-05', '15:45:00', N'Thay dầu và kiểm tra hệ thống làm mát.'),
(26, '2024-05-10', '09:00:00', N'Bảo dưỡng động cơ và hệ thống phanh.'),
(27, '2024-05-15', '14:30:00', N'Kiểm tra các hệ thống an toàn.'),
(28, '2024-05-20', '11:00:00', N'Thay dầu động cơ và kiểm tra treo.'),
(29, '2024-05-25', '08:30:00', N'Kiểm tra hệ thống điều hòa và làm sạch.'),
(30, '2024-06-01', '10:00:00', N'Thay lọc dầu và kiểm tra điện.'),
(31, '2024-06-05', '16:00:00', N'Kiểm tra và thay dầu phanh.'),
(32, '2024-06-10', '09:15:00', N'Thực hiện bảo dưỡng định kỳ toàn diện.'),
(33, '2024-06-15', '13:45:00', N'Vệ sinh và bảo dưỡng nội thất.'),
(34, '2024-06-20', '15:00:00', N'Thay nhớt và kiểm tra động cơ.'),
(35, '2024-06-25', '10:30:00', N'Bảo dưỡng hệ thống điện và kiểm tra đèn.');
-- Thêm dữ liệu vào bảng LinhKien
INSERT INTO LinhKien (TenLinhKien, SoLuong, Gia, MoTa, HinhAnh) VALUES
(N'Pin ô tô', 20, 1500.00, N'Pin dùng cho xe điện, dung lượng cao', 'pin_o_to.jpg'),
(N'Bộ phanh ABS', 15, 2500.00, N'Hệ thống phanh chống bó cứng', 'phanh_abs.jpg'),
(N'Lốp xe', 50, 500.00, N'Lốp xe bền bỉ cho mọi địa hình', 'lop_xe.jpg'),
(N'Đèn pha', 30, 300.00, N'Đèn pha LED siêu sáng', 'den_pha.jpg'),
(N'Bộ lọc dầu', 25, 100.00, N'Bộ lọc dầu chất lượng cao', 'bo_loc_dau.jpg'),
(N'Hệ thống điều hòa', 10, 2000.00, N'Hệ thống làm mát cho xe hơi', 'he_thong_dieu_hoa.jpg'),
(N'Pin chìa khóa', 100, 50.00, N'Pin dành cho điều khiển từ xa', 'pin_chia_khoa.jpg'),
(N'Ghế da', 8, 3000.00, N'Ghế bọc da cao cấp', 'ghe_da.jpg'),
(N'Gương chiếu hậu', 40, 150.00, N'Gương chiếu hậu góc rộng', 'guong_chieu_hau.jpg'),
(N'Bộ truyền động', 12, 3500.00, N'Hệ thống truyền động cao cấp', 'bo_truyen_dong.jpg'),
(N'Trợ lực tay lái', 18, 1200.00, N'Hệ thống trợ lực lái điện tử', 'tro_luc_tay_lai.jpg'),
(N'Bộ điều khiển trung tâm', 5, 4500.00, N'Bộ điều khiển trung tâm thông minh', 'bo_dieu_khien_trung_tam.jpg'),
(N'Cần gạt nước', 60, 80.00, N'Cần gạt nước chống mòn', 'can_gat_nuoc.jpg'),
(N'Bình dầu phanh', 30, 120.00, N'Bình chứa dầu phanh tiêu chuẩn', 'binh_dau_phanh.jpg'),
(N'Bộ lọc gió', 35, 200.00, N'Bộ lọc không khí cho khoang động cơ', 'bo_loc_gio.jpg');
-- Thêm dữ liệu vào bảng HoaDon
INSERT INTO HoaDon (NguoiDungID, NgayGiaoDich, SoTien, LoaiGiaoDich, GhiChu) VALUES
(1, '2023-01-15', 1500.00, N'Thuê xe', N'Thuê xe trong 3 ngày'),
(2, '2023-01-20', 300.00, N'Sửa chữa', N'Sửa chữa bộ phanh'),
(3, '2023-01-25', 200.00, N'Dịch vụ bảo trì', N'Thay dầu máy'),
(4, '2023-02-05', 4500.00, N'Thay thế phụ tùng', N'Thay bộ phanh ABS'),
(5, '2023-02-10', 1200.00, N'Thuê xe', N'Thuê xe trong 2 ngày'),
(6, '2023-02-15', 350.00, N'Sửa chữa', N'Sửa chữa điều hòa'),
(7, '2023-03-01', 800.00, N'Dịch vụ bảo trì', N'Kiểm tra hệ thống điện'),
(8, '2023-03-05', 600.00, N'Thay thế phụ tùng', N'Thay lốp xe'),
(9, '2023-03-10', 400.00, N'Dịch vụ bảo trì', N'Rửa xe'),
(10, '2023-03-15', 1000.00, N'Thuê xe', N'Thuê xe cho một tuần'),
(11, '2023-04-01', 2000.00, N'Thay thế phụ tùng', N'Thay bình ắc quy'),
(12, '2023-04-05', 500.00, N'Sửa chữa', N'Sửa chữa gương chiếu hậu'),
(13, '2023-04-10', 150.00, N'Dịch vụ bảo trì', N'Kiểm tra phanh'),
(14, '2023-04-15', 3500.00, N'Thay thế phụ tùng', N'Thay hệ thống điều hòa'),
(15, '2023-05-01', 250.00, N'Thuê xe', N'Thuê xe cho một ngày'),
(16, '2023-05-05', 120.00, N'Sửa chữa', N'Sửa chữa hệ thống đèn'),
(17, '2023-05-10', 700.00, N'Dịch vụ bảo trì', N'Kiểm tra lốp'),
(18, '2023-05-15', 900.00, N'Thay thế phụ tùng', N'Thay bộ lọc gió'),
(19, '2023-06-01', 1800.00, N'Thuê xe', N'Thuê xe trong 5 ngày'),
(20, '2023-06-05', 300.00, N'Sửa chữa', N'Sửa chữa điều hòa'),
(21, '2023-06-10', 500.00, N'Dịch vụ bảo trì', N'Kiểm tra định kỳ'),
(22, '2023-06-15', 2200.00, N'Thay thế phụ tùng', N'Thay lốp và bộ phanh'),
(23, '2023-07-01', 450.00, N'Thuê xe', N'Thuê xe trong 3 ngày'),
(24, '2023-07-05', 700.00, N'Sửa chữa', N'Sửa chữa hệ thống điện'),
(25, '2023-07-10', 350.00, N'Dịch vụ bảo trì', N'Rửa xe và bảo dưỡng'),
(26, '2023-07-15', 1400.00, N'Thay thế phụ tùng', N'Thay bình xăng'),
(27, '2023-08-01', 600.00, N'Thuê xe', N'Thuê xe cho một tuần'),
(28, '2023-08-05', 800.00, N'Sửa chữa', N'Sửa chữa hộp số'),
(29, '2023-08-10', 500.00, N'Dịch vụ bảo trì', N'Kiểm tra hệ thống phanh'),
(30, '2023-08-15', 1700.00, N'Thay thế phụ tùng', N'Thay hệ thống treo'),
(1, '2023-09-01', 400.00, N'Thuê xe', N'Thuê xe trong 2 ngày'),
(2, '2023-09-05', 200.00, N'Sửa chữa', N'Sửa chữa đèn hậu'),
(3, '2023-09-10', 600.00, N'Dịch vụ bảo trì', N'Thay dầu động cơ'),
(14, '2023-09-15', 1200.00, N'Thay thế phụ tùng', N'Thay bộ lọc dầu'),
(25, '2023-10-01', 800.00, N'Thuê xe', N'Thuê xe trong 4 ngày'),
(26, '2023-10-05', 300.00, N'Sửa chữa', N'Sửa chữa điều hòa'),
(17, '2023-10-10', 900.00, N'Dịch vụ bảo trì', N'Kiểm tra hệ thống điện'),
(18, '2023-10-15', 1300.00, N'Thay thế phụ tùng', N'Thay bộ phanh'),
(29, '2023-11-01', 600.00, N'Thuê xe', N'Thuê xe cho một ngày'),
(20, '2023-11-05', 250.00, N'Sửa chữa', N'Sửa chữa hệ thống điều hòa');

-- Thêm dữ liệu vào bảng HoaDonLinhKien
INSERT INTO HoaDonLinhKien (HoaDonID, LinhKienID, SoLuong) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 1),
(2, 4, 1),
(3, 5, 2),
(3, 6, 1),
(4, 7, 1),
(4, 8, 2),
(5, 9, 1),
(5, 10, 1),
(6, 11, 1),
(6, 12, 4),
(7, 13, 2),
(7, 14, 1),
(8, 15, 1),
(8, 1, 2),
(9, 2, 1),
(9, 3, 3),
(10, 4, 1),
(10, 5, 1),
(11, 6, 2),
(11, 7, 1),
(12, 8, 2),
(12, 9, 1),
(13, 10, 1),
(13, 11, 3),
(14, 12, 1),
(14, 13, 2),
(15, 14, 1),
(15, 15, 1),
(16, 1, 1),
(16, 2, 1),
(17, 3, 2),
(17, 4, 1),
(18, 5, 1),
(18, 6, 1),
(19, 7, 1),
(19, 8, 1),
(20, 9, 1),
(20, 10, 1),
(21, 11, 1),
(21, 12, 1),
(22, 13, 2),
(22, 14, 1),
(23, 15, 1),
(23, 1, 1),
(24, 2, 1),
(24, 3, 1),
(25, 4, 2),
(25, 5, 1),
(26, 6, 2),
(26, 7, 1),
(27, 8, 1),
(27, 9, 1),
(28, 10, 1),
(28, 11, 1),
(29, 12, 1),
(29, 13, 1),
(30, 14, 2),
(30, 15, 1),
(31, 1, 2),
(31, 2, 1),
(32, 3, 1),
(32, 4, 1),
(33, 5, 2),
(33, 6, 1),
(34, 7, 1),
(34, 8, 1),
(35, 9, 1),
(35, 10, 1),
(36, 11, 1),
(36, 12, 2),
(37, 13, 1),
(37, 14, 1),
(38, 15, 1),
(38, 1, 1),
(39, 2, 1),
(39, 3, 1),
(40, 4, 2);
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LinhKien';
select * from DatLichBaoDuongXe
INSERT INTO DatLichBaoDuongXe (NguoiDungID, XeID, NgayDatLich, ThoiGianDatLich)
VALUES
(1, 1, '2024-11-03', '09:00:00'),
(2, 1, '2024-11-03', '10:00:00'),
(1, 2, '2024-12-03', '11:00:00'),
(3, 1, '2024-11-04', '12:00:00'),
(2, 2, '2024-11-05', '13:00:00'),
(1, 3, '2024-11-06', '14:00:00'),
(4, 1, '2024-11-07', '15:00:00'),
(3, 2, '2024-11-08', '16:00:00'),
(2, 3, '2024-11-09', '17:00:00'),
(1, 4, '2024-11-10', '08:30:00'),
(5, 1, '2024-11-11', '09:30:00'),
(4, 2, '2024-11-12', '10:30:00'),
(5, 3, '2024-11-13', '11:30:00'),
(3, 4, '2024-11-14', '12:30:00'),
(1, 5, '2024-11-15', '13:30:00'),
(2, 4, '2024-11-16', '14:30:00'),
(4, 5, '2024-11-17', '15:30:00'),
(5, 6, '2024-11-18', '16:30:00'),
(1, 7, '2024-11-19', '17:30:00'),
(3, 5, '2024-11-20', '09:00:00'),
(2, 6, '2024-11-21', '10:00:00');

INSERT INTO TheoDoiBaoDuong (DonBaoDuongID, VanDe, DaGiaiQuyet, CachGiaiQuyet)
VALUES
(1, 'Kiểm tra phanh', 0, NULL),
(2, 'Thay dầu máy', 1, 'Đã thay dầu mới'),
(3, 'Bảo trì hệ thống điện', 0, NULL),
(4, 'Sửa chữa động cơ', 0, NULL),
(5, 'Thay lốp xe', 1, 'Lốp đã được thay mới'),
(6, 'Bảo dưỡng hệ thống phanh', 0, NULL),
(7, 'Kiểm tra ắc quy', 1, 'Đã thay ắc quy mới'),
(8, 'Kiểm tra hệ thống treo', 0, NULL),
(9, 'Thay lọc gió', 1, 'Đã thay lọc gió mới'),
(10, 'Sửa chữa kính chắn gió', 0, NULL),
(11, 'Thay bình nhiên liệu', 1, 'Đã thay bình nhiên liệu'),
(12, 'Kiểm tra hệ thống điều hòa', 0, NULL),
(13, 'Thay bóng đèn', 1, 'Đã thay bóng đèn mới'),
(14, 'Sửa chữa xe', 0, NULL),
(15, 'Kiểm tra nước làm mát', 1, 'Đã thay nước làm mát'),
(16, 'Bảo trì hệ thống xả', 0, NULL),
(17, 'Sửa chữa truyền động', 1, 'Đã sửa xong truyền động'),
(18, 'Thay dầu hộp số', 0, NULL),
(19, 'Kiểm tra dây đai', 1, 'Đã thay dây đai mới'),
(20, 'Bảo dưỡng toàn bộ xe', 0, NULL),
(21, 'Sửa chữa cửa xe', 1, 'Đã sửa cửa xe'),
(22, 'Thay pin điều khiển từ xa', 0, NULL),
(23, 'Kiểm tra hệ thống phanh ABS', 1, 'Đã kiểm tra và không có lỗi'),
(24, 'Thay nước rửa kính', 0, NULL),
(25, 'Bảo trì xe định kỳ', 1, 'Đã thực hiện bảo trì định kỳ'),
(26, 'Sửa chữa hệ thống âm thanh', 0, NULL),
(27, 'Kiểm tra tiêu thụ nhiên liệu', 1, 'Đã kiểm tra và tối ưu'),
(28, 'Thay mâm xe', 0, NULL),
(29, 'Sửa chữa ống xả', 1, 'Đã sửa ống xả'),
(30, 'Kiểm tra hệ thống GPS', 0, NULL),
(31, 'Bảo trì dầu thắng', 1, 'Đã thay dầu thắng'),
(32, 'Thay bộ lọc nhiên liệu', 0, NULL),
(33, 'Kiểm tra hệ thống lái', 1, 'Đã kiểm tra và không có lỗi'),
(34, 'Sửa chữa hệ thống giảm sóc', 0, NULL),
(35, 'Kiểm tra sự cố tiếng ồn', 1, 'Đã xử lý xong sự cố');


INSERT INTO LichSuDichVu (DonBaoDuongID, NhanVienID, DichVuID, NgayThucHien, GhiChu)
VALUES
(1, 1, 1, '2024-01-10', 'Thực hiện bảo dưỡng định kỳ.'),
(2, 2, 2, '2024-01-11', 'Kiểm tra hệ thống phanh.'),
(3, 3, 3, '2024-01-12', 'Thay dầu máy.'),
(4, 4, 4, '2024-01-13', 'Sửa chữa động cơ.'),
(5, 5, 5, '2024-01-14', 'Thay lốp xe.'),
(6, 6, 6, '2024-01-15', 'Bảo trì hệ thống điện.'),
(7, 7, 1, '2024-01-16', 'Sửa chữa hệ thống treo.'),
(8, 8, 2, '2024-01-17', 'Kiểm tra ắc quy.'),
(9, 9, 3, '2024-01-18', 'Thay lọc gió.'),
(10, 10, 4, '2024-01-19', 'Sửa chữa kính chắn gió.'),
(11, 11, 5, '2024-01-20', 'Thay bình nhiên liệu.'),
(12, 12, 6, '2024-01-21', 'Kiểm tra hệ thống điều hòa.'),
(13, 13, 1, '2024-01-22', 'Thay bóng đèn.'),
(14, 14, 2, '2024-01-23', 'Kiểm tra nước làm mát.'),
(15, 15, 3, '2024-01-24', 'Bảo trì xe định kỳ.'),
(1, 1, 4, '2024-01-25', 'Sửa chữa truyền động.'),
(2, 2, 5, '2024-01-26', 'Kiểm tra dây đai.'),
(3, 3, 6, '2024-01-27', 'Bảo trì dầu thắng.'),
(4, 4, 1, '2024-01-28', 'Thay bộ lọc nhiên liệu.'),
(5, 5, 2, '2024-01-29', 'Kiểm tra hệ thống lái.'),
(6, 6, 3, '2024-01-30', 'Sửa chữa hệ thống giảm sóc.'),
(7, 7, 4, '2024-01-31', 'Kiểm tra sự cố tiếng ồn.'),
(8, 8, 5, '2024-02-01', 'Bảo trì hệ thống điều hòa.'),
(9, 9, 6, '2024-02-02', 'Thay phụ tùng.'),
(10, 10, 1, '2024-02-03', 'Sửa chữa điện tử.'),
(11, 11, 2, '2024-02-04', 'Kiểm tra hệ thống báo động.'),
(12, 12, 3, '2024-02-05', 'Bảo dưỡng xe theo định kỳ.'),
(13, 13, 4, '2024-02-06', 'Kiểm tra tình trạng xe.'),
(14, 14, 5, '2024-02-07', 'Thay nhớt động cơ.'),
(15, 15, 6, '2024-02-08', 'Kiểm tra phanh ABS.'),
(1, 1, 1, '2024-02-09', 'Sửa chữa hệ thống đèn.'),
(2, 2, 2, '2024-02-10', 'Kiểm tra tiêu thụ nhiên liệu.'),
(3, 3, 3, '2024-02-11', 'Thay nước làm mát.'),
(4, 4, 4, '2024-02-12', 'Sửa chữa hệ thống âm thanh.'),
(5, 5, 5, '2024-02-13', 'Kiểm tra hệ thống treo.'),
(6, 6, 6, '2024-02-14', 'Thay thế bộ điều khiển.'),
(7, 7, 1, '2024-02-15', 'Bảo trì tổng quát.'),
(8, 8, 2, '2024-02-16', 'Sửa chữa bình xăng.'),
(9, 9, 3, '2024-02-17', 'Thay van xả.'),
(10, 10, 4, '2024-02-18', 'Kiểm tra ắc quy.');
INSERT INTO DSDonBaoDuongXe (XeID, NgayBaoDuong, ThoiGianBaoDuong, MucTieuBaoDuong)
VALUES 
(1, '2023-01-10', '08:00:00', 'Bảo dưỡng định kỳ'),
(2, '2023-02-15', '09:00:00', 'Kiểm tra hệ thống điện'),
(3, '2023-03-20', '10:30:00', 'Thay dầu máy'),
(4, '2023-04-05', '14:00:00', 'Kiểm tra phanh xe'),
(5, '2023-05-12', '08:30:00', 'Thay lọc gió'),
(6, '2023-06-18', '11:00:00', 'Bảo dưỡng hệ thống điều hòa'),
(7, '2023-07-22', '13:15:00', 'Kiểm tra dầu động cơ'),
(8, '2023-08-10', '09:30:00', 'Kiểm tra ắc quy'),
(9, '2023-09-15', '16:00:00', 'Kiểm tra hệ thống treo'),
(10, '2023-10-25', '17:00:00', 'Thay lốp xe'),
(11, '2023-01-12', '08:45:00', 'Bảo dưỡng định kỳ'),
(12, '2023-02-20', '10:00:00', 'Kiểm tra hệ thống điện'),
(13, '2023-03-25', '13:30:00', 'Thay dầu máy'),
(14, '2023-04-15', '09:30:00', 'Kiểm tra phanh xe'),
(15, '2023-05-20', '15:00:00', 'Thay lọc gió'),
(16, '2023-06-25', '11:45:00', 'Bảo dưỡng hệ thống điều hòa'),
(17, '2023-07-10', '08:00:00', 'Kiểm tra dầu động cơ'),
(18, '2023-08-15', '09:15:00', 'Kiểm tra ắc quy'),
(19, '2023-09-25', '14:30:00', 'Kiểm tra hệ thống treo'),
(20, '2023-10-30', '10:30:00', 'Thay lốp xe');
GO
