
using eShopAPI.Common;
using eShopAPI.Data.ViewModel.User;

namespace eShopAPI.Service.Interface
{
    public interface IUserService
    {
        public Task<Response> GetAll();

        public Task<Response> GetById(int Id);

        public Task<Response> Add(UserAddVM user);

        public Task<Response> Update(UserUpdateVM user);

        public Task<Response> Delete(int Id);
    }
}
