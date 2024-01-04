using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using BTL_ConGa.Service.GioHang;
using BTL_ConGa.Service;
using BTL_ConGa.Models.GioHangAPI;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangAPIController : ControllerBase
    {
        private readonly IGioHangService _gioHangService;
        BtlWebContext db = new BtlWebContext();
        public GioHangAPIController(IGioHangService gioHangService, BtlWebContext db)
        {
            _gioHangService = gioHangService;
            this.db = db;
        }
        // Lấy tất cả món ăn trong giỏ hàng
        [HttpGet("{MaHDB}/{TaiKhoan}")]
        public async Task<IActionResult> getProductFromCart(string MaHDB,string TaiKhoan)
        {
            var lstProduct = from product in db.MonAns
                             join invoiceDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiceDetail.MaMonAn
                             join invoice in db.HoaDonBans on invoiceDetail.MaHoaDon equals invoice.MaHoaDon
                             join khachHang in db.KhachHangs on invoice.IdkhachHang equals khachHang.IdkhachHang
                             where invoice.MaHoaDon == MaHDB && khachHang.TaiKhoan==TaiKhoan && invoice.TrangThaiThanhToan == "Chưa thanh toán"
                             select new { 
                                 product.MaMonAn,
                                 invoice.MaHoaDon,
                                 product.AnhDaiDien, 
                                 product.TenMonAn, 
                                 product.DonGia, 
                                 invoiceDetail.SoLuong,
                                 invoice.TongTien,
                                 ThanhTien = invoiceDetail.SoLuong * product.DonGia
                             };
            return Ok(lstProduct);
        }
        //Add thẳng vào hóa đơn
        [Route("invoiceDetailExsits")]
        [HttpPost]
        public async Task<IActionResult> AddToCartExsits([FromBody]ChiTietHoaDonDTO chiTietHoaDonBan)
        {
            try
            {
                await _gioHangService.AddToCartExsits(chiTietHoaDonBan);
                ////Số lượng to của món ăn đấy
                //var bigProduct = db.MonAns.FirstOrDefault(x=>x.MaMonAn==chiTietHoaDonBan.MaMonAn);
                //bigProduct.SoLuong = bigProduct.SoLuong - (chiTietHoaDonBan.SoLuong);
                //db.MonAns.Update(bigProduct);
                //await db.SaveChangesAsync();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Add 1 lúc 2 đối tượng: hóa đơn và chi tiết hóa đơn
        [Route("invoiceDetail")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] GioHang_HoaDon gioHang_HoaDon)
        {
            try
            {
                await _gioHangService.AddToCart(gioHang_HoaDon);
                //Số lượng to của món ăn đấy
                //var bigProduct = db.MonAns.FirstOrDefault(x => x.MaMonAn == gioHang_HoaDon.MaMonAn);
                //bigProduct.SoLuong = bigProduct.SoLuong - (gioHang_HoaDon.SoLuong);
                //db.MonAns.Update(bigProduct);
                //await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Cập nhật số luọng khi món đấy có sẵn trong giỏ hàng
        [HttpPut("{maHDB}/{maMonAn}/{quantity}")]
        public async Task<IActionResult> updateQuantity(string maHDB,string maMonAn,int quantity)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x=>x.MaHoaDon == maHDB
            && x.MaMonAn==maMonAn);
            if(exsitsProduct == null)
                return BadRequest();
            exsitsProduct.SoLuong = exsitsProduct.SoLuong + quantity;
            db.ChiTietHoaDonBans.Update(exsitsProduct);
            ////Số lượng to của món ăn đấy
            //var bigProduct = db.MonAns.FirstOrDefault(x => x.MaMonAn == maMonAn);
            ////Cập nhật số lượng
            //bigProduct.SoLuong = bigProduct.SoLuong - quantity;
            //db.MonAns.Update(bigProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }
        //Xóa chi tiết hóa đơn
        [HttpDelete("{maHDB}/{maMonAn}")]
        public async Task<IActionResult> deleteInvoiceDetail(string maHDB, string maMonAn)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB
            && x.MaMonAn == maMonAn);
            if (exsitsProduct == null)
                return BadRequest();
            db.ChiTietHoaDonBans.Remove(exsitsProduct);
            //Số lượng to của món ăn đấy
            var bigProduct = db.MonAns.FirstOrDefault(x => x.MaMonAn == maMonAn);
            //Lấy số luongj trong chi tiết hóa đơn
            var productDetail = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB && x.MaMonAn == maMonAn);
            bigProduct.SoLuong = bigProduct.SoLuong + productDetail.SoLuong;
            db.MonAns.Update(bigProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }

        // Cập nhật số lượng khi bấm nút tăng giảm
        [Route("updateInvoiceDetail")]
        [HttpPut]
        public async Task<IActionResult> updateInvoiceDetail(string maHDB, string maMonAn, int quantity)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB
            && x.MaMonAn == maMonAn);
            if (exsitsProduct == null)
                return BadRequest();
            exsitsProduct.SoLuong = quantity;
            db.ChiTietHoaDonBans.Update(exsitsProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }

        // Cập nhật lại số tiền
        [Route("updateMoney")]
        [HttpPut]
        public async Task<IActionResult> updateInvoiceDetail(string maHDB,double money)
        {
            var exsitsInvoice = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            if (exsitsInvoice == null)
                return BadRequest();
            exsitsInvoice.TongTien = money;
            db.HoaDonBans.Update(exsitsInvoice);
            await db.SaveChangesAsync();
            return Ok(exsitsInvoice);
        }

        //Kiểm tra có hợp lệ không
        [Route("CheckValid")]
        [HttpGet]
        public async Task<IActionResult> checkValid(string maHDB)
        {
            //Lấy số lượng cục to
            //Lấy số lượng hiện tại
            var currentProduct = from product in db.MonAns
                                 join invoiceDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiceDetail.MaMonAn
                                 where invoiceDetail.MaHoaDon == maHDB
                                 select new
                                 {
                                     product.MaMonAn,
                                     invoiceDetail.MaHoaDon,
                                     invoiceDetail.SoLuong,
                                 };
            var check = (from product in db.MonAns
                         join current in currentProduct on product.MaMonAn equals current.MaMonAn
                         where current.SoLuong > product.SoLuong
                         select new { product.MaMonAn,product.SoLuong,product.TenMonAn }).ToList();
            
            if (check.Count>0)
                return BadRequest(check);
            else
                return Ok(currentProduct);
        }

        //Cập nhật số lượng
        [Route("UpdateQuantity")]
        [HttpGet]
        public async Task<IActionResult> UpdateQuantityProduct(string maMonAn, int quantity)
        {
            //Lấy số lượng cục to
            var product = db.MonAns.FirstOrDefault(x => x.MaMonAn == maMonAn);
            //Lấy số lượng hiện tại
            product.SoLuong=product.SoLuong-quantity;
            db.MonAns.Update(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        //Cập nhật các thông tin khi đặt hàng thành công
        [Route("orderSuccess")]
        [HttpPut]
        public async Task<IActionResult> orderSuccess(string maHDB,string diaChi,string phone,string nguoiNhan,string ghiChu)
        {
            var hoaDon = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            hoaDon.NgayTao=DateTime.Now;
            hoaDon.DiaChiGiaoHang=diaChi;
            hoaDon.SoDienThoai = phone;
            hoaDon.NguoiNhan=nguoiNhan;
            hoaDon.GhiChu = ghiChu;
            hoaDon.TinhTrangDonHang= "Chờ xác nhận";
            hoaDon.TrangThaiThanhToan = "Đã thanh toán";
            db.HoaDonBans.Update(hoaDon); 
            await db.SaveChangesAsync();
            return Ok(hoaDon);
        }

        //Hủy hóa đơn đang chờ xác nhận
        [Route("deleteInvoice")]
        [HttpDelete]
        public async Task<IActionResult> deleteInvoice(string maHDB)
        {
            var invoiceDetail = db.ChiTietHoaDonBans.Where(x => x.MaHoaDon == maHDB).ToList();
            db.ChiTietHoaDonBans.RemoveRange(invoiceDetail);
            await db.SaveChangesAsync();
            var invoice = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            db.HoaDonBans.Remove(invoice);
            await db.SaveChangesAsync();
            return Ok(invoiceDetail);
        }
    }
}
