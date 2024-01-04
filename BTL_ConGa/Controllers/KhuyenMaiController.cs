using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    public class KhuyenMaiController : Controller
    {
        public IActionResult KhuyenMai()
        {
            return View("Views/KhuyenMai/KhuyenMai.cshtml");
        }
        public IActionResult ChiTietKhuyenMai()
        {
            return View("Views/KhuyenMai/ChiTietKhuyenMai.cshtml");
        }
    }
}
