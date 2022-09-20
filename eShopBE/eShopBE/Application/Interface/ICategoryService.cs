using eShopBE.ViewModel.CategoryVM;
using System.Threading.Tasks;


namespace eShopBE.Application.Interface
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
