using BTL_ConGa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [HttpGet]
        public IEnumerable<DanhMuc> GetAllDanhMuc()
        {
            var danhmuc = db.DanhMucs.ToList();
            return danhmuc;
        }
        [HttpGet("{madanhmuc}")]
        public IEnumerable<DanhMuc> GetDanhMucTheoMa(string madanhmuc)
        {
            var danhMuc = db.DanhMucs.Where(x => x.MaDanhMuc == madanhmuc).ToList();
            return danhMuc;
        }
        [HttpDelete]
        public bool DeleteDanhMuc(string madanhmuc)
        {

            try
            {
                var danhmuc = db.DanhMucs.Find(madanhmuc);
                if (danhmuc == null) { return false; }
                db.DanhMucs.Remove(danhmuc);
                db.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        [HttpPost]
        public bool ThemDanhMuc(String MaDanhMuc, String TenDanhMuc)
        {
            try
            {
                DanhMuc danhmuc = new DanhMuc();
                danhmuc.MaDanhMuc = MaDanhMuc;
                danhmuc.TenDanhMuc = TenDanhMuc;
                db.DanhMucs.AddAsync(danhmuc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
