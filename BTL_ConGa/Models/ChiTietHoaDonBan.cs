using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class ChiTietHoaDonBan
{
    public int SoLuong { get; set; }

    public string MaMonAn { get; set; } = null!;

    public string MaHoaDon { get; set; } = null!;

    public virtual HoaDonBan MaHoaDonNavigation { get; set; } = null!;

    public virtual MonAn MaMonAnNavigation { get; set; } = null!;
}
