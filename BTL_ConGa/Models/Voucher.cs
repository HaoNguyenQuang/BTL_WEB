using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class Voucher
{
    public string MaVoucher { get; set; } = null!;

    public string TenVoucher { get; set; } = null!;

    public int PhanTram { get; set; }

    public int SoLuong { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();
}
