using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class HoaDonBan
{
    public string MaHoaDon { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public double TongTien { get; set; }

    public string TrangThaiThanhToan { get; set; } = null!;

    public string DiaChiGiaoHang { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string NguoiNhan { get; set; } = null!;

    public string GhiChu { get; set; } = null!;

    public string TinhTrangDonHang { get; set; } = null!;

    public string? MaVoucher { get; set; }

    public string IdkhachHang { get; set; } = null!;

    public string MaNhanVien { get; set; } = null!;

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; } = new List<ChiTietHoaDonBan>();

    public virtual KhachHang IdkhachHangNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual Voucher? MaVoucherNavigation { get; set; }
}
