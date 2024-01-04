using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class LoaiTaiKhoan
{
    public string MaLoaiTaiKhoan { get; set; } = null!;

    public string TenLoaiTaiKhoan { get; set; } = null!;

    public virtual ICollection<TaiKhoan> TaiKhoans { get; } = new List<TaiKhoan>();
}
