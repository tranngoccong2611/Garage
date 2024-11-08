using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    ChucVuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MucLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.ChucVuID);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    DichVuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiDichVuID = table.Column<int>(type: "int", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.DichVuID);
                });

            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    GioiTinhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinh", x => x.GioiTinhID);
                });

            migrationBuilder.CreateTable(
                name: "LinhKien",
                columns: table => new
                {
                    LinhKienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLinhKien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhKien", x => x.LinhKienID);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    NguoiDungID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinhID = table.Column<int>(type: "int", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.NguoiDungID);
                    table.ForeignKey(
                        name: "FK_NguoiDung_GioiTinh_GioiTinhID",
                        column: x => x.GioiTinhID,
                        principalTable: "GioiTinh",
                        principalColumn: "GioiTinhID");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinhID = table.Column<int>(type: "int", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.NhanVienID);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ChucVu",
                        principalColumn: "ChucVuID");
                    table.ForeignKey(
                        name: "FK_NhanVien_GioiTinh_GioiTinhID",
                        column: x => x.GioiTinhID,
                        principalTable: "GioiTinh",
                        principalColumn: "GioiTinhID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: true),
                    NgayGiaoDich = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiGiaoDich = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.HoaDonID);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungID");
                });

            migrationBuilder.CreateTable(
                name: "XeOTo",
                columns: table => new
                {
                    XeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: true),
                    BienSoXe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HangXe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NamSanXuat = table.Column<short>(type: "smallint", nullable: true),
                    MauSac = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeOTo", x => x.XeID);
                    table.ForeignKey(
                        name: "FK_XeOTo_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungID");
                });

            migrationBuilder.CreateTable(
                name: "CSKH",
                columns: table => new
                {
                    CSKHID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: true),
                    NhanVienID = table.Column<int>(type: "int", nullable: true),
                    NgayChamSoc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhuongThucLienHe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoiDungTraoDoi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSKH", x => x.CSKHID);
                    table.ForeignKey(
                        name: "FK_CSKH_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungID");
                    table.ForeignKey(
                        name: "FK_CSKH_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "NhanVienID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonLinhKien",
                columns: table => new
                {
                    HoaDonLinhKienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    LinhKienID = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonLinhKien", x => x.HoaDonLinhKienID);
                    table.ForeignKey(
                        name: "FK_HoaDonLinhKien_HoaDon_HoaDonID",
                        column: x => x.HoaDonID,
                        principalTable: "HoaDon",
                        principalColumn: "HoaDonID");
                    table.ForeignKey(
                        name: "FK_HoaDonLinhKien_LinhKien_LinhKienID",
                        column: x => x.LinhKienID,
                        principalTable: "LinhKien",
                        principalColumn: "LinhKienID");
                });

            migrationBuilder.CreateTable(
                name: "DatLichBaoDuongXe",
                columns: table => new
                {
                    DatLichBaoDuongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: true),
                    XeID = table.Column<int>(type: "int", nullable: true),
                    NgayDatLich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianDatLich = table.Column<TimeSpan>(type: "time", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Đang chờ xác nhận")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatLichBaoDuongXe", x => x.DatLichBaoDuongID);
                    table.ForeignKey(
                        name: "FK_DatLichBaoDuongXe_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungID");
                    table.ForeignKey(
                        name: "FK_DatLichBaoDuongXe_XeOTo_XeID",
                        column: x => x.XeID,
                        principalTable: "XeOTo",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateTable(
                name: "DSDonBaoDuongXe",
                columns: table => new
                {
                    DonBaoDuongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XeID = table.Column<int>(type: "int", nullable: true),
                    NgayBaoDuong = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianBaoDuong = table.Column<TimeSpan>(type: "time", nullable: true),
                    MucTieuBaoDuong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSDonBaoDuongXe", x => x.DonBaoDuongID);
                    table.ForeignKey(
                        name: "FK_DSDonBaoDuongXe_XeOTo_XeID",
                        column: x => x.XeID,
                        principalTable: "XeOTo",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateTable(
                name: "LichSuDichVu",
                columns: table => new
                {
                    LichSuDichVuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonBaoDuongID = table.Column<int>(type: "int", nullable: true),
                    NhanVienID = table.Column<int>(type: "int", nullable: true),
                    DichVuID = table.Column<int>(type: "int", nullable: true),
                    NgayThucHien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDichVu", x => x.LichSuDichVuID);
                    table.ForeignKey(
                        name: "FK_LichSuDichVu_DSDonBaoDuongXe_DonBaoDuongID",
                        column: x => x.DonBaoDuongID,
                        principalTable: "DSDonBaoDuongXe",
                        principalColumn: "DonBaoDuongID");
                    table.ForeignKey(
                        name: "FK_LichSuDichVu_DichVu_DichVuID",
                        column: x => x.DichVuID,
                        principalTable: "DichVu",
                        principalColumn: "DichVuID");
                    table.ForeignKey(
                        name: "FK_LichSuDichVu_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "NhanVienID");
                });

            migrationBuilder.CreateTable(
                name: "TheoDoiBaoDuong",
                columns: table => new
                {
                    TheoDoiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonBaoDuongID = table.Column<int>(type: "int", nullable: true),
                    VanDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DaGiaiQuyet = table.Column<bool>(type: "bit", nullable: true),
                    CachGiaiQuyet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoDoiBaoDuong", x => x.TheoDoiID);
                    table.ForeignKey(
                        name: "FK_TheoDoiBaoDuong_DSDonBaoDuongXe_DonBaoDuongID",
                        column: x => x.DonBaoDuongID,
                        principalTable: "DSDonBaoDuongXe",
                        principalColumn: "DonBaoDuongID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSKH_NguoiDungID",
                table: "CSKH",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_CSKH_NhanVienID",
                table: "CSKH",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DatLichBaoDuongXe_NguoiDungID",
                table: "DatLichBaoDuongXe",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_DatLichBaoDuongXe_XeID",
                table: "DatLichBaoDuongXe",
                column: "XeID");

            migrationBuilder.CreateIndex(
                name: "IX_DSDonBaoDuongXe_XeID",
                table: "DSDonBaoDuongXe",
                column: "XeID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NguoiDungID",
                table: "HoaDon",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonLinhKien_HoaDonID",
                table: "HoaDonLinhKien",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonLinhKien_LinhKienID",
                table: "HoaDonLinhKien",
                column: "LinhKienID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDichVu_DichVuID",
                table: "LichSuDichVu",
                column: "DichVuID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDichVu_DonBaoDuongID",
                table: "LichSuDichVu",
                column: "DonBaoDuongID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDichVu_NhanVienID",
                table: "LichSuDichVu",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_GioiTinhID",
                table: "NguoiDung",
                column: "GioiTinhID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuID",
                table: "NhanVien",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_GioiTinhID",
                table: "NhanVien",
                column: "GioiTinhID");

            migrationBuilder.CreateIndex(
                name: "IX_TheoDoiBaoDuong_DonBaoDuongID",
                table: "TheoDoiBaoDuong",
                column: "DonBaoDuongID");

            migrationBuilder.CreateIndex(
                name: "IX_XeOTo_NguoiDungID",
                table: "XeOTo",
                column: "NguoiDungID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CSKH");

            migrationBuilder.DropTable(
                name: "DatLichBaoDuongXe");

            migrationBuilder.DropTable(
                name: "HoaDonLinhKien");

            migrationBuilder.DropTable(
                name: "LichSuDichVu");

            migrationBuilder.DropTable(
                name: "TheoDoiBaoDuong");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "LinhKien");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "DSDonBaoDuongXe");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "XeOTo");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "GioiTinh");
        }
    }
}
