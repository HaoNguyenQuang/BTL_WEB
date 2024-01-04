using BTL_ConGa.Models;
using BTL_ConGa.Models.TaiKhoanAPI;

namespace BTL_ConGa.Service
{
    public class UserInforService : IUserInforService
    {
        private readonly BtlWebContext _context;
        public UserInforService(BtlWebContext context)
        {
            _context = context;
        }

        public async Task Register(TaiKhoanIn4Model user)
        {
            var taiKhoan = new TaiKhoan
            {
                TaiKhoan1 = user.Username,
                MatKhau = user.Password,
                MaLoaiTaiKhoan = user.AccountType
            };
            var userInfo = new KhachHang
            {
                IdkhachHang = user.CustomerId,
                TenKhachHang = user.CustomerName,
                NgaySinh = user.DateOfBirth,
                SoDienThoai = user.PhoneNumber,
                DiaChi = user.Address,
                Email = user.Email,
                GioiTinh = user.Sex,
                TaiKhoan = user.Username,
                TaiKhoanNavigation = taiKhoan,
            };
            await _context.TaiKhoans.AddAsync(taiKhoan);
            await _context.KhachHangs.AddAsync(userInfo);
            await _context.SaveChangesAsync();
        }
    }
}
