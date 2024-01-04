namespace BTL_ConGa.Models.LichSu
{
    public class LichSuModel
    {
        public string MaHoaDon { get; set; } = null!;
        public DateTime NgayTao { get; set; }
        public double TongTien { get; set; }
        public string IdkhachHang { get; set; } = null!;
        public int SoLuong { get; set; }
        public string MaMonAn { get; set; } = null!;
        public string TenMonAn { get; set; } = null!;
        public double DonGia { get; set; }
        public string AnhDaiDien { get; set; } = null!;
    }
}
