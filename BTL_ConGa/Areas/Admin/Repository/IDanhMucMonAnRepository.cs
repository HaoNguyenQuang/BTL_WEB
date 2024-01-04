using BTL_ConGa.Models;

namespace BTL_ConGa.Areas.Admin.Repository
{
    public interface IDanhMucMonAnRepository
    {
        DanhMuc Add(DanhMuc danhmuc);
        DanhMuc Update(DanhMuc danhmuc);
        DanhMuc Delete(string madanhmuc);
        DanhMuc GetDanhMuc(string madanhmuc);
        IEnumerable<DanhMuc> GetAllDanhMuc();
    }
}
