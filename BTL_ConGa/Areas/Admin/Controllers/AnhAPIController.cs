using BTL_ConGa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();


        [HttpGet]
        public IEnumerable<Anh> GetAllAnh()
        {
            var anh = db.Anhs.ToList();
            return anh;
        }
        public void SaveAnh(string anhdaidien)
        {
            string fileSoure = "C:\\Users\\DUY THIEN\\Pictures\\Screenshots\\" + anhdaidien;
            string targetFolderPath = "C:\\Users\\DUY THIEN\\Downloads\\BTL_LTWEB-main\\BTL_ConGa\\wwwroot\\Chicken\\images\\ThucDon";
            string filePath = Path.Combine(targetFolderPath, anhdaidien);
            System.IO.File.Copy(fileSoure, filePath, true);
            byte[] imageData = System.IO.File.ReadAllBytes(filePath);
        }

        [HttpPut]
        public bool SuaAnh(String maanh1, String tenanh1, String hinhanh1,
                           String maanh2, String tenanh2, String hinhanh2,
                           String maanh3, String tenanh3, String hinhanh3, 
                           string mamon)
        {
            try
            {

                Anh anh1 = db.Anhs.FirstOrDefault(x => x.MaAnh == maanh1);
                if (anh1 == null) { return false; }
                //string hinh1 = spilthinanh(hinhanh1);
                anh1.TenAnh = tenanh1;
                anh1.HinhAnh = hinhanh1;
                anh1.MaMonAn = mamon;
                //SaveAnh(hinh1);
                db.SaveChanges();

                Anh anh2 = db.Anhs.FirstOrDefault(x => x.MaAnh == maanh2);
                if (anh2 == null) { return false; }
                //string hinh2 = spilthinanh(hinhanh2);
                anh2.TenAnh = tenanh2;
                anh2.HinhAnh = hinhanh2;
                anh2.MaMonAn = mamon;
                //SaveAnh(hinh2);
                db.SaveChanges();

                Anh anh3 = db.Anhs.FirstOrDefault(x => x.MaAnh == maanh3);
                if (anh3 == null) { return false; }
                //string hinh3 = spilthinanh(hinhanh3);
                anh3.TenAnh = tenanh3;
                anh3.HinhAnh = hinhanh3;
                anh3.MaMonAn = mamon;
                //SaveAnh(hinh3);
                db.SaveChanges();
                return true;
                
            }
            catch { return false; }

        }
          



        public string spilthinanh(string hinhanh)
        {
            var tenanh = hinhanh.Split('\\');
            return tenanh[tenanh.Length - 1];
        }


    }
}
