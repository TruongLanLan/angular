
using eShopAPI.Common;
using eShopAPI.Data.ViewModel.Category;

namespace eShopAPI.Service.Interface
{
    public interface ICategoryService
    {
        public Task<Response> GetAll();

        public Task<Response> GetById(int Id);

        public Task<Response> Add(CategoryAddVM category);

        public Task<Response> Update(CategoryUpdateVM category);

        public Task<Response> Delete(int Id);

    }
}
