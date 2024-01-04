using BTL_ConGa.Models.TaiKhoanAPI;

namespace BTL_ConGa.Service
{
    public interface IUserInforService
    {
        Task Register(TaiKhoanIn4Model user);
    }
}
