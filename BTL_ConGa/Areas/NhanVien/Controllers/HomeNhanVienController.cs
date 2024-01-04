using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Areas.NhanVien.Controllers
{
    [Area("nhanvien")]
    [Route("nhanvien")]
    [Route("nhanvien/homenhanvien")]
    
    public class HomeNhanVienController : Controller
    {
        BtlWebContext db = new BtlWebContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return RedirectToAction("HoSo");
        }
        // Tat Ca Mon An
        //[Route("tatcamonan")]
        //public IActionResult TatCaMonAn(int? page)
        //{
        //    int pageSize = 5;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstMonAn = db.MonAns.AsNoTracking().OrderBy(x => x.TenMonAn);
        //    PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("tatcamonan")]
        public IActionResult TatCaMonAn()
        {
            var lstTatCaMonAn = db.MonAns.ToList();
            return View(lstTatCaMonAn);
        }

        //Mon An Theo Danh Muc
        //[Route("monantheodanhmuc")]
        //public IActionResult MonAnTheoDanhMuc(String madanhmuc, int? page)
        //{

        //	int pageSize = 3;
        //	int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //	// phuc vu phan trang
        //	var lstMonAn = db.MonAns.AsNoTracking().Where(x => x.MaDanhMuc == madanhmuc).OrderBy(x => x.TenMonAn);
        //	PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //	var tendanhmuc = db.DanhMucs.Find(madanhmuc);
        //	ViewBag.madanhmuc = madanhmuc;
        //	ViewBag.tendanhmuc = tendanhmuc.TenDanhMuc;
        //	return View(lst);
        //}
        [Route("monantheodanhmuc")]
        public IActionResult MonAnTheoDanhMuc(String madanhmuc)
        {

            var lstMonAnTheoDanhMuc = db.MonAns.Where(x=>x.MaDanhMuc==madanhmuc).ToList();
            var tendanhmuc = db.DanhMucs.Find(madanhmuc);
            ViewBag.tendanhmuc = tendanhmuc.TenDanhMuc;
            return View(lstMonAnTheoDanhMuc);
        }


        [Route("chitietmonan")]
        public IActionResult ChiTietMonAn(String mamonan)
        {

            var lstMonAn = db.MonAns.Find(mamonan);
            return View(lstMonAn);

        }

        // Hoa Don Ban
        //[Route("hoadonban")]
        //public IActionResult HoaDonBan(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstHoaDonBan = db.HoaDonBans.AsNoTracking().OrderBy(x => x.MaHoaDon);
        //    PagedList<HoaDonBan> lst = new PagedList<HoaDonBan>(lstHoaDonBan, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("hoadonban")]
        public IActionResult HoaDonBan()
        {
            ViewBag.IDNhanVien = HttpContext.Session.GetString("IDNhanVien");
            var lstHoaDonBan = db.HoaDonBans.Where(x=>x.TinhTrangDonHang == "Chờ xác nhận").ToList();
            return View(lstHoaDonBan);
        }

        [Route("hoadonbancuaban")]
        public IActionResult HoaDonBanCuaBan()
        {
            var lstHoaDonBan = db.HoaDonBans.Where(x => x.MaNhanVien == HttpContext.Session.GetString("IDNhanVien")).ToList();
            return View(lstHoaDonBan);
        }

        [Route("chitiethoadonban")]
        public IActionResult ChiTietHoaDonBan(String mahoadon)
        {
            var lstHoaDonBan = db.HoaDonBans.Find(mahoadon);
            return View(lstHoaDonBan);
        }
        [Route("dangxuat")]
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("TrangChu", "TrangChu");
        }

        [Route("hoso")]
        public IActionResult HoSo()
        {
            ViewBag.IDNhanVien = HttpContext.Session.GetString("IDNhanVien");
            ViewBag.TenNhanVien = HttpContext.Session.GetString("Name");
            ViewBag.DiaChi = HttpContext.Session.GetString("Address");
            ViewBag.NgaySinh = HttpContext.Session.GetString("Birth");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.SoDienThoai = HttpContext.Session.GetString("Phone");
            ViewBag.GioiTinh = HttpContext.Session.GetString("Gender");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.Username = HttpContext.Session.GetString("UserName");

            return View();
        }
    }
}
