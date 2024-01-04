using BTL_ConGa.Models;
using BTL_ConGa.Models.GioHangAPI;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Service.GioHang
{
    public class GioHangService : IGioHangService
    {
        private readonly BtlWebContext _context;
        public GioHangService(BtlWebContext context)
        {
            _context = context;
        }
        public async Task AddToCart(GioHang_HoaDon gioHang_HoaDon)
        {
            var hoaDonBan = new HoaDonBan
            {
                MaHoaDon = gioHang_HoaDon.MaHDB,
                NgayTao = gioHang_HoaDon.NgayTao,
                TongTien = gioHang_HoaDon.TongTien,
                TrangThaiThanhToan = gioHang_HoaDon.TrangThaiThanhToan,
                DiaChiGiaoHang = gioHang_HoaDon.DiaChiGiaoHang,
                SoDienThoai = gioHang_HoaDon.SoDienThoai,
                NguoiNhan = gioHang_HoaDon.NguoiNhan,
                GhiChu = gioHang_HoaDon.GhiChu,
                TinhTrangDonHang = gioHang_HoaDon.TinhTrangDonHang,
                MaVoucher = gioHang_HoaDon.MaVoucher,
                IdkhachHang = gioHang_HoaDon.IDKhachHang,
                MaNhanVien = gioHang_HoaDon.MaNhanVien
            };
            var chiTietHoaDon = new ChiTietHoaDonBan
            {
                MaHoaDon = gioHang_HoaDon.MaHDB,
                MaMonAn = gioHang_HoaDon.MaMonAn,
                SoLuong = gioHang_HoaDon.SoLuong
            };
            await _context.HoaDonBans.AddAsync(hoaDonBan);
            await _context.ChiTietHoaDonBans.AddAsync(chiTietHoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task AddToCartExsits(ChiTietHoaDonDTO chiTietHoaDonBan)
        {
            var chitietHDB = new ChiTietHoaDonBan
            {
                SoLuong = chiTietHoaDonBan.SoLuong,
                MaMonAn = chiTietHoaDonBan.MaMonAn,
                MaHoaDon = chiTietHoaDonBan.MaHoaDon
            };
            await _context.ChiTietHoaDonBans.AddAsync(chitietHDB);
            await _context.SaveChangesAsync();
        }

        
    }
}
