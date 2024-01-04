using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class MonAn
{
    public string MaMonAn { get; set; } = null!;

    public string TenMonAn { get; set; } = null!;

    public double DonGia { get; set; }

    public string MoTa { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public string AnhDaiDien { get; set; } = null!;

    public int SoLuong { get; set; }

    public string MaDanhMuc { get; set; } = null!;

    public virtual ICollection<Anh> Anhs { get; } = new List<Anh>();

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; } = new List<ChiTietHoaDonBan>();

    public virtual DanhMuc MaDanhMucNavigation { get; set; } = null!;
}
