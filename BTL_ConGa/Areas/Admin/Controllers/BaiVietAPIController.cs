using BTL_ConGa.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.CodeAnalysis;

namespace BTL_ConGa.Areas.Admin.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        

        [HttpGet]
        public IEnumerable<TinTuc> GetAllBaiViet()
        {
            var tintuc = db.TinTucs.ToList();
            return tintuc;
        }
        [HttpGet("{matintuc}")]
        public IEnumerable<TinTuc> GetBaiVietTheoMa(string matintuc)
        {
            var tintuc = db.TinTucs.Where(x => x.MaTinTuc == matintuc).ToList();
            return tintuc;
        }
        [HttpDelete]
        public bool DeleteTinTuc(string matintuc)
        {

            try
            {
                var tintuc = db.TinTucs.Find(matintuc);
                if (tintuc == null) { return false; }
                db.TinTucs.Remove(tintuc);
                db.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        [HttpPost]
        public bool ThemTinTuc(String MaTinTuc, String AnhDaiDien, String TieuDe, String NoiDung)
        {
            
            try
            {
                var tenanh = AnhDaiDien.Split('\\');
                string anhdaidien = tenanh[tenanh.Length-1];
                
                TinTuc tintuc = new TinTuc();
                tintuc.MaTinTuc = MaTinTuc;
                tintuc.AnhDaiDien = anhdaidien;
                tintuc.TieuDe = TieuDe;
                tintuc.NoiDung = NoiDung;
                db.TinTucs.AddAsync(tintuc);
                db.SaveChanges();

                SaveAnh(anhdaidien);





                return true;
           
            }
            
            catch
            {
                return false;
            }
        }

        public void SaveAnh(string anhdaidien)
        {
            string fileSoure = "C:\\Users\\Admin\\Pictures\\Screenshots\\" + anhdaidien;
            string targetFolderPath = "D:\\BTL_WEB\\BTL_LTWEB_ChuaCoThien_Thinh\\BTL_LTWEB_ChuaCoThien\\BTL_LTWEB - main\\BTL_LTWEB - main\\BTL_ConGa\\wwwroot\\Chicken\\images\\BaiViet";
            string filePath = Path.Combine(targetFolderPath, anhdaidien);
            System.IO.File.Copy(fileSoure, filePath, true);
            byte[] imageData = System.IO.File.ReadAllBytes(filePath);
        }



        [HttpPut]
        public bool SuaTinTuc(String MaTinTuc, String AnhDaiDien, String TieuDe, String NoiDung)
        {

                //var tenanh = AnhDaiDien.Split('\\');
                //string anhdaidien = tenanh[tenanh.Length - 1];
                //SaveAnh(anhdaidien);

                TinTuc tintuc = db.TinTucs.FirstOrDefault(x => x.MaTinTuc == MaTinTuc);
                if (tintuc == null) { return false; }
                //tintuc.MaTinTuc = MaTinTuc;
                tintuc.AnhDaiDien = AnhDaiDien;
                tintuc.TieuDe = TieuDe;
                tintuc.NoiDung = NoiDung;
                db.SaveChanges();
                return true;



        }
        
    }
}
