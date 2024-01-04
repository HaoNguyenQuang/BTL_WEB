using BTL_ConGa.Models;
using BTL_ConGa.Models.GioHangAPI;

namespace BTL_ConGa.Service.GioHang
{
    public interface IGioHangService
    {
        Task AddToCart(GioHang_HoaDon gioHang_HoaDon);
        Task AddToCartExsits(ChiTietHoaDonDTO chiTietHoaDonBan);
    }
}
