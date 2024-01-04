using BTL_ConGa.Models;

namespace BTL_ConGa.Areas.Admin.Repository
{
    public class DanhMucMonAnRepository : IDanhMucMonAnRepository
    {
        private readonly BtlWebContext _context;
        public DanhMucMonAnRepository(BtlWebContext context)
        {
            _context = context;
        }
        public DanhMuc Add(DanhMuc danhmuc)
        {
            _context.Add(danhmuc);
            _context.SaveChanges();
            return danhmuc;
        }

        public DanhMuc Delete(string madanhmuc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DanhMuc> GetAllDanhMuc()
        {
            return _context.DanhMucs;
        }

        public DanhMuc GetDanhMuc(string madanhmuc)
        {
            return _context.DanhMucs.Find(madanhmuc);
        }

        public DanhMuc Update(DanhMuc danhmuc)
        {
            _context.Update(danhmuc);
            _context.SaveChanges();
            return danhmuc;
        }
    }
}
