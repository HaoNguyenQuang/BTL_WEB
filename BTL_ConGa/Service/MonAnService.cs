using BTL_ConGa.Models;
using BTL_ConGa.Models.TTMonAn;

namespace BTL_ConGa.Service
{
    public class MonAnService: IMonAnService
    {
        private readonly BtlWebContext _context;
        public MonAnService(BtlWebContext context)
        {
            _context = context;
        }

        /*public Task ThemMonAn(TTMonAn monAn)
        {
            throw new NotImplementedException();
        }*/

        public async Task ThemMonAn(TTMonAn monAn)
        {
            var monAnInfo = new MonAn
            {
                MaMonAn = monAn.MaMonAn,
                TenMonAn = monAn.TenMonAn,
                DonGia = monAn.DonGia,
                MoTa = monAn.MoTa,
                TrangThai = monAn.TrangThai,
                AnhDaiDien = monAn.AnhDaiDien,
                SoLuong = monAn.SoLuong,
                MaDanhMuc = monAn.MaDanhMuc
            };
            var anh = new Anh
            {
                MaAnh = monAn.MaAnh,
                TenAnh = monAn.TenAnh,
                HinhAnh = monAn.HinhAnh
            };
            await _context.MonAns.AddAsync(monAnInfo);
            await _context.Anhs.AddAsync(anh);           
            await _context.SaveChangesAsync();

        }
    }
}
