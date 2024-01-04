using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BTL_ConGa.Controllers
{
    public class BaiVietController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult BaiViet(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var listBaiViet = db.TinTucs.OrderBy(x => x.MaTinTuc);
            PagedList<TinTuc> lst = new PagedList<TinTuc>(listBaiViet, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult ChiTietBaiViet(String MaTinTuc)
        {
            var baiViet = db.TinTucs.SingleOrDefault(x => x.MaTinTuc == MaTinTuc);
            var ctbaiViet = db.TinTucs.Where(x => x.MaTinTuc == MaTinTuc).ToList();
            ViewBag.ctbaiViet = ctbaiViet;
            return View(baiViet);
        }
        /*public IActionResult BaiViet()
        {
            return View("Views/BaiViet/BaiViet.cshtml");
        }
        public IActionResult ChiTietBaiViet()
        {
            return View("Views/BaiViet/ChiTietBaiViet.cshtml");
        }*/
    }
}
