using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
         
        [HttpGet]
        public IEnumerable<Models.NhanVien> GetAllNhanVien()
        {
            var nhanvien = db.NhanViens.ToList();
            return nhanvien;
        }
        [HttpGet("{manhanvien}")]
        public IEnumerable<Models.NhanVien> GetNhanVienTheoMa(string manhanvien)
        {
            var nhanvien = db.NhanViens.Where(x=>x.MaNhanVien==manhanvien).ToList();
            return nhanvien;
        }
        [HttpPost]
        [Route("ThemNhanVien")]
        public bool ThemNhanVien(String MaNhanVien, String TenNhanVien, String DiaChi, DateTime NgaySinh, String Email, 
            String SoDienThoai, String GioiTinh, string TaiKhoan, string MatKhau)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.TaiKhoan1 = TaiKhoan;
            taikhoan.MatKhau = MatKhau;
            taikhoan.MaLoaiTaiKhoan = "LTK01";
            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();

            Models.NhanVien nhanvien = new Models.NhanVien();
            nhanvien.MaNhanVien = MaNhanVien;
            nhanvien.TenNhanVien = TenNhanVien;
            nhanvien.DiaChi = DiaChi;
            nhanvien.NgaySinh = NgaySinh;
            nhanvien.Email = Email;
            nhanvien.SoDienThoai = SoDienThoai;
            nhanvien.GioiTinh = GioiTinh;
            nhanvien.TaiKhoan = taikhoan.TaiKhoan1;

            db.NhanViens.Add(nhanvien);
            db.SaveChanges();
            return true;
        }
    }
}
