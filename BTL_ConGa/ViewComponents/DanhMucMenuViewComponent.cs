using BTL_ConGa.Models;
using BTL_ConGa.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BTL_ConGa.ViewComponents
{
    public class DanhMucMenuViewComponent : ViewComponent
    {
        private readonly IDanhMucSPRepository _danhMucSP;

        public DanhMucMenuViewComponent(IDanhMucSPRepository danhMucSPRepository)
        {
            _danhMucSP= danhMucSPRepository;
        }
        public IViewComponentResult Invoke()
        {
            var danhMucSP = _danhMucSP.GetAllDanhMuc().OrderBy(x => x.MaDanhMuc);
            return View(danhMucSP);
        }
    }
}
