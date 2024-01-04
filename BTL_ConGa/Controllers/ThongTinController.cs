using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    public class ThongTinController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult GioiThieu()
        {
            return View("Views/ThongTin/GioiThieu.cshtml");
        }
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }
        public IActionResult LienHe()
        {
            var lastContact = db.Feedbacks.ToList();
            int lastId = 0;
            if (lastContact.Count > 0)
            {
                lastId = splitId(lastContact.OrderByDescending(x => splitId(x.Mafeedback)).FirstOrDefault().Mafeedback.ToString());
            }
            //ViewBag.lastId = lastId;
            return View(lastId);
        }
        public IActionResult DiaChiNhaHang()
        {
            return View("Views/ThongTin/DiaChiNhaHang.cshtml");
        }
    }
}
