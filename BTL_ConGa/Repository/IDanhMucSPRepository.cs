using BTL_ConGa.Models;
namespace BTL_ConGa.Repository
{
    public interface IDanhMucSPRepository
    {
        DanhMuc Add(DanhMuc danhMuc);
        DanhMuc Update(DanhMuc danhMuc);
        DanhMuc Delete(String MaDanhMuc);
        DanhMuc GetDanhMuc(String MaDanhMuc);
        IEnumerable<DanhMuc> GetAllDanhMuc();
    }
}
