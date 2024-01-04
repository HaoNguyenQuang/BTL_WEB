using BTL_ConGa.Models;

namespace BTL_ConGa.Repository
{
    public class DanhMucSPRepository : IDanhMucSPRepository
    {
        private readonly BtlWebContext _context;
        public DanhMucSPRepository(BtlWebContext context)
        {
            _context = context;
        }
        public DanhMuc Add(DanhMuc danhMuc)
        {
            _context.DanhMucs.Add(danhMuc);
            _context.SaveChanges();
            return danhMuc;
        }

        public DanhMuc Delete(string MaDanhMuc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DanhMuc> GetAllDanhMuc()
        {
            return _context.DanhMucs;
        }

        public DanhMuc GetDanhMuc(string MaDanhMuc)
        {
            return _context.DanhMucs.Find(MaDanhMuc);
        }

        public DanhMuc Update(DanhMuc danhMuc)
        {
            _context.Update(danhMuc);
            _context.SaveChanges();
            return danhMuc;
        }
    }
}
