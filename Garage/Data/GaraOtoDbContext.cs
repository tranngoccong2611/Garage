using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Garage.Data.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.InkML;

namespace Garage.Data
{
    public class GaraOtoDbContext : DbContext
    {
        public GaraOtoDbContext()
        {
        }

        public GaraOtoDbContext(DbContextOptions<GaraOtoDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<GioiTinh> GioiTinh { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<XeOTo> XeOTo { get; set; }
        public DbSet<CSKH> CSKH { get; set; }
        public DbSet<DSDonBaoDuongXe> DSDonBaoDuongXe { get; set; }
        public DbSet<LichSuDichVu> LichSuDichVu { get; set; }
        public DbSet<LinhKien> LinhKien { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDonLinhKien> HoaDonLinhKien { get; set; }
        public DbSet<TheoDoiBaoDuong> TheoDoiBaoDuong { get; set; }
        public DbSet<DatLichBaoDuongXe> DatLichBaoDuongXe { get; set; }
        public DbSet<Admin> Admin { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // GioiTinh configuration
            modelBuilder.Entity<GioiTinh>(entity =>
            {
                entity.HasKey(e => e.GioiTinhID);
                entity.Property(e => e.TenGioiTinh).HasMaxLength(10).IsRequired();
            });

            // ChucVu configuration
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.ChucVuID);
                entity.Property(e => e.TenChucVu).HasMaxLength(50).IsRequired();
                entity.Property(e => e.MucLuong).IsRequired();
            });

            // DichVu configuration
            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.DichVuID);
                entity.Property(e => e.TenDichVu).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MoTa).HasMaxLength(255);
                entity.Property(e => e.Gia).HasColumnType("decimal(18,2)").IsRequired();
            });

            // NhanVien configuration
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.NhanVienID);
                entity.Property(e => e.HoTen).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SoDienThoai).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.DiaChi).HasMaxLength(255);
                entity.Property(e => e.HinhAnh).HasMaxLength(200);

                entity.HasOne(e => e.GioiTinh)
                      .WithMany()
                      .HasForeignKey(e => e.GioiTinhID);

                entity.HasOne(e => e.ChucVu)
                      .WithMany()
                      .HasForeignKey(e => e.ChucVuID);
            });

            // NguoiDung configuration
            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.NguoiDungID);
                entity.Property(e => e.HoTen).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SoDienThoai).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.DiaChi).HasMaxLength(255);
                entity.Property(e => e.HinhAnh).HasMaxLength(200);

                entity.HasOne(e => e.GioiTinh)
                      .WithMany()
                      .HasForeignKey(e => e.GioiTinhID);
            });

            // XeOTo configuration
            modelBuilder.Entity<XeOTo>(entity =>
            {
                entity.HasKey(e => e.XeID);
                entity.Property(e => e.BienSoXe).HasMaxLength(20).IsRequired();
                entity.Property(e => e.HangXe).HasMaxLength(50);
                entity.Property(e => e.Model).HasMaxLength(50);
                entity.Property(e => e.MauSac).HasMaxLength(20);
                entity.Property(e => e.HinhAnh).HasMaxLength(200);

                entity.HasOne(e => e.NguoiDung)
                      .WithMany()
                      .HasForeignKey(e => e.NguoiDungID);
            });

            // CSKH configuration
            modelBuilder.Entity<CSKH>(entity =>
            {
                entity.HasKey(e => e.CSKHID);
                entity.Property(e => e.PhuongThucLienHe).HasMaxLength(50);
                entity.Property(e => e.NoiDungTraoDoi).HasMaxLength(255);

                entity.HasOne(e => e.NguoiDung)
                      .WithMany()
                      .HasForeignKey(e => e.NguoiDungID);

                entity.HasOne(e => e.NhanVien)
                      .WithMany()
                      .HasForeignKey(e => e.NhanVienID);
            });

            // DSDonBaoDuongXe configuration
            modelBuilder.Entity<DSDonBaoDuongXe>(entity =>
            {
                entity.HasKey(e => e.DonBaoDuongID);
                entity.Property(e => e.MucTieuBaoDuong).HasMaxLength(255);

                entity.HasOne(e => e.XeOTo)
                      .WithMany()
                      .HasForeignKey(e => e.XeID);
            });

            // LichSuDichVu configuration
            modelBuilder.Entity<LichSuDichVu>(entity =>
            {
                entity.HasKey(e => e.LichSuDichVuID);
                entity.Property(e => e.GhiChu).HasMaxLength(255);

                entity.HasOne(e => e.DonBaoDuong)
                      .WithMany()
                      .HasForeignKey(e => e.DonBaoDuongID);

                entity.HasOne(e => e.NhanVien)
                      .WithMany()
                      .HasForeignKey(e => e.NhanVienID);

                entity.HasOne(e => e.DichVu)
                      .WithMany()
                      .HasForeignKey(e => e.DichVuID);
            });

            // LinhKien configuration
            modelBuilder.Entity<LinhKien>(entity =>
            {
                entity.HasKey(e => e.LinhKienID);
                entity.Property(e => e.TenLinhKien).HasMaxLength(100);
                entity.Property(e => e.Gia).HasColumnType("decimal(18,2)");
                entity.Property(e => e.MoTa).HasMaxLength(255);
                entity.Property(e => e.HinhAnh).HasMaxLength(200);
            });

            // HoaDon configuration
            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.HoaDonID);
                entity.Property(e => e.SoTien).HasColumnType("decimal(18,2)");
                entity.Property(e => e.LoaiGiaoDich).HasMaxLength(50);
                entity.Property(e => e.GhiChu).HasMaxLength(255);

                entity.HasOne(e => e.NguoiDung)
                      .WithMany()
                      .HasForeignKey(e => e.NguoiDungID);
            });

            // HoaDonLinhKien configuration
            modelBuilder.Entity<HoaDonLinhKien>(entity =>
            {
                entity.HasKey(e => e.HoaDonLinhKienID);

                entity.HasOne(e => e.HoaDon)
                      .WithMany()
                      .HasForeignKey(e => e.HoaDonID);

                entity.HasOne(e => e.LinhKien)
                      .WithMany()
                      .HasForeignKey(e => e.LinhKienID);
            });

            // TheoDoiBaoDuong configuration
            modelBuilder.Entity<TheoDoiBaoDuong>(entity =>
            {
                entity.HasKey(e => e.TheoDoiID);
                entity.Property(e => e.VanDe).HasMaxLength(255);
                entity.Property(e => e.CachGiaiQuyet).HasMaxLength(255);

                entity.HasOne(e => e.DonBaoDuong)
                      .WithMany()
                      .HasForeignKey(e => e.DonBaoDuongID);
            });

            // DatLichBaoDuongXe configuration
            modelBuilder.Entity<DatLichBaoDuongXe>(entity =>
            {
                entity.HasKey(e => e.DatLichBaoDuongID);
                entity.Property(e => e.TrangThai).HasMaxLength(50).HasDefaultValue("Đang chờ xác nhận");

                entity.HasOne(e => e.NguoiDung)
                      .WithMany()
                      .HasForeignKey(e => e.NguoiDungID);

                entity.HasOne(e => e.XeOTo)
                      .WithMany()
                      .HasForeignKey(e => e.XeID);
            });
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId);
                entity.ToTable("Admin"); // Chỉ định tên bảng
                entity.Property(e => e.TenTaiKhoan).HasMaxLength(50).IsRequired();
                entity.Property(e => e.MatKhau).HasMaxLength(50).IsRequired();
            });
            base.OnModelCreating(modelBuilder);

        }
    }
}
