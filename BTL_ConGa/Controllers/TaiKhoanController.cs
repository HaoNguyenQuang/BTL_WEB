using BTL_ConGa.Models;
using BTL_ConGa.Models.LichSu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BTL_ConGa.Controllers
{
    public class TaiKhoanController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult TaiKhoan()
        {
            return View("Views/TaiKhoan/TaiKhoan.cshtml");
        }
        public IActionResult ChiTietTaiKhoan()
        {
            ViewBag.IDCustomer = HttpContext.Session.GetString("IDCustomer");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Phone = HttpContext.Session.GetString("Phone");
            ViewBag.Address = HttpContext.Session.GetString("Address");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Gender = HttpContext.Session.GetString("Gender");
            ViewBag.Birth = HttpContext.Session.GetString("Birth");

            return View("Views/TaiKhoan/ChiTietTaiKhoan.cshtml");
        }
        public IActionResult DoiMatKhau()
        {
            ViewBag.Username = HttpContext.Session.GetString("UserName");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View("Views/TaiKhoan/DoiMatKhau.cshtml");
        }
        public IActionResult LichSuDatHang()
        {
            //Lấy chi tiết hóa đơn
            var invoiceDetail = (from product in db.MonAns
                                 join invoiDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiDetail.MaMonAn
                                 join invoice in db.HoaDonBans on invoiDetail.MaHoaDon equals invoice.MaHoaDon
                                 select new
                                 {
                                     product.MaMonAn,
                                     product.AnhDaiDien,
                                     product.TenMonAn,
                                     invoice.MaHoaDon
                                 }).ToList();
            ViewBag.invoiceDetail = invoiceDetail;
            string taiKhoan = HttpContext.Session.GetString("UserName");
            string getCustomerId = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan).IdkhachHang;
            //Liệt kê các hóa đơn của khách hàng X
            var HoaDonBan = db.HoaDonBans.Where(x => x.IdkhachHang == getCustomerId && x.TinhTrangDonHang == "Đã hoàn thành").ToList();
            //var chitiethdb = db.ChiTietHoaDonBans.Where(x=>x.MaHoaDon == )
            return View(HoaDonBan);
        }

        public IActionResult LichSuDatHangChoXacNhan()
        {
            //Lấy chi tiết hóa đơn
            var invoiceDetail = (from product in db.MonAns
                                 join invoiDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiDetail.MaMonAn
                                 join invoice in db.HoaDonBans on invoiDetail.MaHoaDon equals invoice.MaHoaDon
                                 select new
                                 {
                                     product.MaMonAn,
                                     product.AnhDaiDien,
                                     product.TenMonAn,
                                     invoice.MaHoaDon
                                 }).ToList();
            ViewBag.invoiceDetail = invoiceDetail;
            string taiKhoan = HttpContext.Session.GetString("UserName");
            string getCustomerId = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan).IdkhachHang;
            //Liệt kê các hóa đơn của khách hàng X
            var HoaDonBan = db.HoaDonBans.Where(x => x.IdkhachHang == getCustomerId && x.TinhTrangDonHang == "Chờ xác nhận").ToList();
            //var chitiethdb = db.ChiTietHoaDonBans.Where(x=>x.MaHoaDon == )
            return View(HoaDonBan);
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TrangChu", "TrangChu");

            }
        }
        [HttpPost]
        public IActionResult DangNhap(TaiKhoan user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TaiKhoans.Where(x => x.TaiKhoan1 == user.TaiKhoan1 && x.MatKhau == user.MatKhau).FirstOrDefault();
                var k = db.KhachHangs.Where(x => x.TaiKhoan == user.TaiKhoan1).FirstOrDefault();
                var l = db.NhanViens.Where(x => x.TaiKhoan == user.TaiKhoan1).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.TaiKhoan1.ToString());
                    HttpContext.Session.SetString("Password", u.MatKhau.ToString());
                    if(k!= null)
                    {
                        HttpContext.Session.SetString("IDCustomer", k.IdkhachHang.ToString());
                        HttpContext.Session.SetString("Name", k.TenKhachHang.ToString());
                        HttpContext.Session.SetString("Phone", k.SoDienThoai.ToString());
                        HttpContext.Session.SetString("Address", k.DiaChi.ToString());
                        HttpContext.Session.SetString("Email", k.Email.ToString());
                        HttpContext.Session.SetString("Gender", k.GioiTinh.ToString());
                        HttpContext.Session.SetString("Birth", k.NgaySinh.ToString("yyyy-MM-dd"));
                    }
                    if(l != null)
                    {
                        HttpContext.Session.SetString("IDNhanVien", l.MaNhanVien.ToString());
                        HttpContext.Session.SetString("Name", l.TenNhanVien.ToString());
                        HttpContext.Session.SetString("Address", l.DiaChi.ToString());
                        HttpContext.Session.SetString("Birth", l.NgaySinh.ToString("yyyy-MM-dd"));
                        HttpContext.Session.SetString("Email", l.Email.ToString());
                        HttpContext.Session.SetString("Phone", l.SoDienThoai.ToString());
                        HttpContext.Session.SetString("Gender", l.GioiTinh.ToString());

                    }
                    if (u.MaLoaiTaiKhoan == "LTK01")
                    {
                        return RedirectToAction("Index", "Nhanvien");
                    }
                    else if (u.MaLoaiTaiKhoan == "LTK02")
                    {
                        return RedirectToAction("TrangChu", "TrangChu");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View(user);

        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("TrangChu", "TrangChu");
        }

        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }

        public IActionResult DangKy()
        {
            var lastCustomer = db.KhachHangs.ToList();
            int lastId = splitId(lastCustomer.OrderByDescending(x => splitId(x.IdkhachHang)).FirstOrDefault().IdkhachHang.ToString());
            ViewBag.lastId = lastId;
            return View(lastId);
        }

    }
}


