using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BTL_ConGa.Controllers
{
    public class GioHangController : Controller
    {
        BtlWebContext database = new BtlWebContext();
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }
        public IActionResult GioHang()
        {
            //Lấy id khách hàng thông qua tài khoản
            string taiKhoan = HttpContext.Session.GetString("UserName");
            string getCustomerId = database.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan).IdkhachHang;

            //Kiểm tra khách hàng xem có giỏ hàng không
            var checkThanhToan = database.HoaDonBans.FirstOrDefault
                (x => x.TrangThaiThanhToan == "Chưa thanh toán" && x.TinhTrangDonHang == "Thêm giỏ hàng" && x.IdkhachHang == getCustomerId);
            ViewBag.taiKhoan = taiKhoan;
            //Nếu khách hàng có giỏ hàng
            if (checkThanhToan != null)
            {
                return View(checkThanhToan);
            }
            //string maHoaDon = checkThanhToan.MaHoaDon;
            //if (maHoaDon != "")
            //{
            //    return View(maHoaDon);
            //}
            //else
            //{
            //    var lstHoaDonBan = database.HoaDonBans.ToList();
            //    int lastIdHoaDonBan = splitId(lstHoaDonBan.OrderByDescending(x => splitId(x.IdkhachHang))
            //        .FirstOrDefault().MaHoaDon.ToString());
            //    return View(lastIdHoaDonBan);
            //}
            return View(checkThanhToan);
            //ViewBag.thongBao = 1;
            //return RedirectToAction("TrangChu","TrangChu");
        }
        public IActionResult ThanhToan()
        {
            string taiKhoan = HttpContext.Session.GetString("UserName");
            string getCustomerId = database.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan).IdkhachHang;
            //Lấy thông tin khách hàng
            var getCustomer = database.KhachHangs.FirstOrDefault(x => x.TaiKhoan == taiKhoan);
            ViewBag.Customer = getCustomer;
            //Kiểm tra khách hàng xem có giỏ hàng không
            var checkThanhToan = database.HoaDonBans.FirstOrDefault
                (x => x.TrangThaiThanhToan == "Chưa thanh toán" && x.TinhTrangDonHang == "Thêm giỏ hàng" && x.IdkhachHang == getCustomerId);
            ViewBag.taiKhoan = taiKhoan;
            //Nếu khách hàng có giỏ hàng
            if (checkThanhToan != null)
            {
                return View(checkThanhToan);
            }
            return RedirectToAction("TrangChu", "TrangChu");
        }
    }
}
