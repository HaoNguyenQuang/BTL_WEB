using BTL_ConGa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [HttpGet]
        public IEnumerable<Voucher> GetAllVoucher()
        {
            var voucher = db.Vouchers.ToList();
            return voucher;
        }
        [HttpGet("{mavoucher}")]
        public IEnumerable<Voucher> GetVoucherTheoMa(string mavoucher)
        {
            var voucher = db.Vouchers.Where(x => x.MaVoucher == mavoucher).ToList();
            return voucher;
        }
        [HttpDelete]
        public Boolean XoaVoucher(string mavoucher)
        {

            try
            {
                var voucher = db.Vouchers.Find(mavoucher);
                var voucherhoadon = db.HoaDonBans.Find(mavoucher);
                if (voucher == null || voucherhoadon!=null) { return false; }

                db.Vouchers.Remove(voucher);
                db.SaveChanges();
                return true;
            }
            catch { return false; }

        }
        [HttpPost]
        public bool ThemVoucher(String MaVoucher, String TenVoucher, int PhanTram, int SoLuong, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            try
            {
                Voucher voucher = new Voucher();
                voucher.MaVoucher = MaVoucher;
                voucher.TenVoucher = TenVoucher;
                voucher.PhanTram= PhanTram;
                voucher.SoLuong= SoLuong;
                voucher.NgayBatDau = NgayBatDau;
                voucher.NgayKetThuc= NgayKetThuc;
                db.Vouchers.AddAsync(voucher);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool SuaVoucher(String MaVoucher, String TenVoucher, int PhanTram, int SoLuong, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            try
            {

                Voucher voucher = db.Vouchers.FirstOrDefault(x => x.MaVoucher == MaVoucher);
                if (voucher == null) { return false; }     
                //voucher.MaVoucher = MaVoucher;
                voucher.TenVoucher = TenVoucher;
                voucher.PhanTram = PhanTram;
                voucher.SoLuong = SoLuong;
                voucher.NgayBatDau = NgayBatDau;
                voucher.NgayKetThuc = NgayKetThuc;
                db.SaveChanges();
                return true;
            }
            catch { return false; }


        }
    }
}
