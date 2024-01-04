using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using BTL_ConGa.Areas.Admin.Repository;

namespace BTL_ConGa.Areas.Admin.ViewComponents
{
	public class DanhMucMenuViewComponent:ViewComponent
	{
		private readonly IDanhMucMonAnRepository _IDanhMuc;
		public DanhMucMenuViewComponent(IDanhMucMonAnRepository IDanhMuc)
		{
			_IDanhMuc = IDanhMuc;
		}
		public IViewComponentResult Invoke()
		{
			var DanhMuc = _IDanhMuc.GetAllDanhMuc().OrderBy(x => x.TenDanhMuc);
			return View(DanhMuc);
		}
	}
}
