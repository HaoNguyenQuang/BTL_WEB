using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Controllers
{
    public class ThucDonController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(3, id.Length - 3);
            return int.Parse(res);
        }
        public IActionResult MonAnTheoDanhMuc(String MaDanhMuc, int? page)
        {
            //Xử lý giỏ hàng
            //Kiểm tra người dùng đăng nhập chưa
            string taiKhoan = HttpContext.Session.GetString("UserName");
            //đã đăng nhập
            if (taiKhoan != null)
            {
                //Lấy id khách hàng thông qua tài khoản
                string getCustomerId = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan).IdkhachHang;
                //Kiểm tra có tồn tại hóa đơn nhưng chưa thanh toán
                var checkThanhToan = db.HoaDonBans.FirstOrDefault
                    (x => x.TrangThaiThanhToan == "Chưa thanh toán" && x.TinhTrangDonHang == "Thêm giỏ hàng" && x.IdkhachHang == getCustomerId);
                //Lấy mã hóa đơn
                string maHoaDon = "";
                if (checkThanhToan != null)
                {
                    maHoaDon = checkThanhToan.MaHoaDon;
                }
                if (maHoaDon != "")
                {
                    ViewBag.checkHD = 1; // đã có hóa đơn
                    ViewBag.maHDB = maHoaDon;
                }
                else
                {
                    var lstHoaDonBan = db.HoaDonBans.ToList();
                    int lastIdHoaDonBan = splitId(lstHoaDonBan.OrderByDescending(x => splitId(x.MaHoaDon))
                        .FirstOrDefault().MaHoaDon.ToString()) + 1;
                    ViewBag.checkHD = 0;
                    ViewBag.maHDB = "HDB" + lastIdHoaDonBan.ToString();
                }
                //Lấy id khách hàng
                ViewBag.maKH = getCustomerId;
            }
            //
            int pageSize = 3;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            List<MonAn> lstMonan = db.MonAns.AsNoTracking().Where(x => x.MaDanhMuc == MaDanhMuc).OrderBy(x => x.TenMonAn).ToList();
            PagedList<MonAn> lst = new PagedList<MonAn>(lstMonan, pageNumber, pageSize);
            ViewBag.MaDanhMuc = MaDanhMuc;
            return View(lst);
        }
    }
}
