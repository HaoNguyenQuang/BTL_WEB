using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class TaiKhoan
{
    public string TaiKhoan1 { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string MaLoaiTaiKhoan { get; set; } = null!;

    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();

    public virtual LoaiTaiKhoan MaLoaiTaiKhoanNavigation { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();
}
