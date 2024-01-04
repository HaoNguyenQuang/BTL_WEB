using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string TenNhanVien { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string TaiKhoan { get; set; } = null!;

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();

    public virtual TaiKhoan TaiKhoanNavigation { get; set; } = null!;
}
