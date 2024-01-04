using BTL_ConGa.Models;
using BTL_ConGa.Models.TTMonAn;
using BTL_ConGa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonAnAPIController : ControllerBase
    {
        private readonly IMonAnService _monAnService;
        BtlWebContext db = new BtlWebContext();
        public MonAnAPIController(IMonAnService monAnService, BtlWebContext db)
        {
            _monAnService = monAnService;
            this.db = db;
        }
        [HttpGet]
        public IEnumerable<MonAn> GetAllMonAn()
        {
            var danhmuc = db.MonAns.ToList();
            
            return danhmuc;
        }
        [HttpGet("{mamonan}")]
        public IEnumerable<MonAn> GetMonAnTheoMaDanhMuc(string madanhmuc)
        {
            var monAn = db.MonAns.Where(x => x.MaDanhMuc == madanhmuc).ToList();
            return monAn;
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
        public bool ThemMonAn(String MaMonAn, String TenMonAn, double DonGia,
                              String MoTa, String TrangThai, String AnhDaiDien,
                              int SoLuong, String MaDanhMuc,
                              String maanh1, String tenanh1, String hinhanh1,
                              String maanh2, String tenanh2, String hinhanh2,
                              String maanh3, String tenanh3, String hinhanh3)
        {

            try
            {


                MonAn monan = new MonAn();
                monan.MaMonAn = MaMonAn;
                monan.TenMonAn = TenMonAn;
                monan.DonGia = DonGia;
                monan.MoTa = MoTa;
                monan.TrangThai = TrangThai;
                monan.AnhDaiDien = AnhDaiDien;
                monan.SoLuong = SoLuong;
                monan.MaDanhMuc = MaDanhMuc;
                db.MonAns.AddAsync(monan);




                Anh anh1 = new Anh();
                anh1.MaAnh = maanh1;
                anh1.TenAnh = tenanh1;
                anh1.HinhAnh = hinhanh1;
                anh1.MaMonAn = MaMonAn;
                db.Anhs.AddAsync(anh1);
                db.SaveChanges();

                Anh anh2 = new Anh();
                anh2.MaAnh = maanh2;
                anh2.TenAnh = tenanh2;
                anh2.HinhAnh = hinhanh2;
                anh2.MaMonAn = MaMonAn;
                db.Anhs.AddAsync(anh2);
                db.SaveChanges();

                Anh anh3 = new Anh();
                anh3.MaAnh = maanh3;
                anh3.TenAnh = tenanh3;
                anh3.HinhAnh = hinhanh3;
                anh3.MaMonAn = MaMonAn;
                db.Anhs.AddAsync(anh3);
                db.SaveChanges();


                return true;

            }

            catch
            {
                return false;
            }
        }



        [HttpPut]
        [Route("SuaMonAn")]
        public bool SuaMonAn(string MaMonAn, string TenMonAn, 
                            double DonGia, string MoTa, 
                            string TrangThai, string AnhDaiDien, 
                            int SoLuong, string MaDanhMuc)
        {
            try
            {

                MonAn monAn = db.MonAns.FirstOrDefault(x => x.MaMonAn == MaMonAn);
                if (monAn == null) { return false; }
                //tintuc.MaTinTuc = MaTinTuc;
                if (monAn.AnhDaiDien != AnhDaiDien)
                    monAn.AnhDaiDien = AnhDaiDien;
                monAn.TenMonAn = TenMonAn;
                monAn.DonGia = DonGia;
                monAn.MoTa = MoTa;
                monAn.TrangThai = TrangThai;
                monAn.SoLuong = SoLuong;
                monAn.MaDanhMuc = MaDanhMuc;
                db.SaveChanges();
                return true;
            }
            catch { return false; }


        }

        [HttpPut]
        [Route("CapNhatSoLuong")]
        public bool CapNhatSoLuong()
        {
            var monAn = db.MonAns.ToList();
            foreach(var item in monAn)
            {
                item.SoLuong = 100;
            }
            db.SaveChanges();
            return true;
        }
    }
}
