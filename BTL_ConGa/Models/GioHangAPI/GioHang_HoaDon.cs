using System.Data.SqlTypes;

namespace BTL_ConGa.Models.GioHangAPI
{
    public class GioHang_HoaDon
    {
        public string MaHDB { set; get; }
        public DateTime NgayTao { set; get; }
        public double TongTien { set; get; }
        public string TrangThaiThanhToan { set; get; }
        public string DiaChiGiaoHang { set; get; }
        public string SoDienThoai { set; get; }
        public string NguoiNhan { set; get; }
        public string GhiChu { set; get; }
        public string TinhTrangDonHang { set; get; }
        public string MaVoucher { set; get; }
        public string IDKhachHang { set; get; }
        public string MaNhanVien { set; get; }
        public string MaMonAn { set; get; }
        public int SoLuong { set; get; }
    }
}
