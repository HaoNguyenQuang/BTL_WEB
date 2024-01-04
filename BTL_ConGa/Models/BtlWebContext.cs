using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Models;

public partial class BtlWebContext : DbContext
{
    public BtlWebContext()
    {
    }

    public BtlWebContext(DbContextOptions<BtlWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }

    public virtual DbSet<MonAn> MonAns { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TinTuc> TinTucs { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    public IEnumerable<object> LichSuModel { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
          => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UO2968G\\SQLEXPRESS;Initial Catalog=BTL_WEB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anh>(entity =>
        {
            entity.HasKey(e => e.MaAnh).HasName("PK__Anh__356240DF442AD732");

            entity.ToTable("Anh");

            entity.Property(e => e.MaAnh).HasMaxLength(255);
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.TenAnh).HasMaxLength(255);

            entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.Anhs)
                .HasForeignKey(d => d.MaMonAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anh__MaMonAn__45F365D3");
        });

        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity.HasKey(e => new { e.MaMonAn, e.MaHoaDon }).HasName("PK__ChiTietH__1922FB363E885E2C");

            entity.ToTable("ChiTietHoaDonBan");

            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.MaHoaDon).HasMaxLength(255);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__5441852A");

            entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.MaMonAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaMon__534D60F1");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDanhMuc).HasName("PK__DanhMuc__B37508874D1961C9");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDanhMuc).HasMaxLength(255);
            entity.Property(e => e.TenDanhMuc).HasMaxLength(255);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Mafeedback).HasName("PK__Feedback__DF9F5E2D85A4180F");

            entity.ToTable("Feedback");

            entity.Property(e => e.Mafeedback).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13B221DC1C1");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHoaDon).HasMaxLength(255);
            entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(1000);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(255)
                .HasColumnName("IDKhachHang");
            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.MaVoucher).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasColumnType("date");
            entity.Property(e => e.NguoiNhan).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TinhTrangDonHang).HasMaxLength(255);
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(255);

            entity.HasOne(d => d.IdkhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.IdkhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__IDKha__4F7CD00D");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__MaNha__5070F446");

            entity.HasOne(d => d.MaVoucherNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaVoucher)
                .HasConstraintName("FK__HoaDonBan__MaVou__4E88ABD4");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdkhachHang).HasName("PK__KhachHan__5A7167B51FD14683");

            entity.ToTable("KhachHang");

            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(255)
                .HasColumnName("IDKhachHang");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhachHang__TaiKh__4BAC3F29");
        });

        modelBuilder.Entity<LoaiTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaLoaiTaiKhoan).HasName("PK__LoaiTaiK__5F6E141C97BE58CA");

            entity.ToTable("LoaiTaiKhoan");

            entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenLoaiTaiKhoan).HasMaxLength(255);
        });

        modelBuilder.Entity<MonAn>(entity =>
        {
            entity.HasKey(e => e.MaMonAn).HasName("PK__MonAn__B1171625244EA1EF");

            entity.ToTable("MonAn");

            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.MaDanhMuc).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.TenMonAn).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(255);

            entity.HasOne(d => d.MaDanhMucNavigation).WithMany(p => p.MonAns)
                .HasForeignKey(d => d.MaDanhMuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonAn__MaDanhMuc__403A8C7D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47DE5722C3");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenNhanVien).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__TaiKho__48CFD27E");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoan1).HasName("PK__TaiKhoan__D5B8C7F15646A1A2");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(255)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiTaiKhoanNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaLoaiTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaLoai__4316F928");
        });

        modelBuilder.Entity<TinTuc>(entity =>
        {
            entity.HasKey(e => e.MaTinTuc).HasName("PK__TinTuc__B53648C08132EE2E");

            entity.ToTable("TinTuc");

            entity.Property(e => e.MaTinTuc).HasMaxLength(255);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.TieuDe).HasMaxLength(255);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.MaVoucher).HasName("PK__Voucher__0AAC5B11A63455EF");

            entity.ToTable("Voucher");

            entity.Property(e => e.MaVoucher).HasMaxLength(255);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.TenVoucher).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
