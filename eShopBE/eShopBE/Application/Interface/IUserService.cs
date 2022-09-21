using eShopBE.ViewModel.UserViewM;

namespace eShopBE.Application.Interface
{
    public interface IUserService
    {
        public Task<Response> GetAll();
        public Task<Response> Add(UserAddVM user);
        public Task<Response> Update(UserUpdateVM user);
        public Task<Response> Delete(int id);
        public Task<Response> GetUserbyUserName(string userName);
        public Task<Response> GetUserById(int id);
        public Task<Response> GetAllCustomers();
    }
}
