using eShopBE.ViewModel.CategoryVM;
using eShopBE.ViewModel.SupplierVM;

namespace eShopBE.Application.Interface
{
    public interface ISupplierService
    {
        public Task<Response> GetAll();

        public Task<Response> GetById(int Id);

        public Task<Response> Add(SupplierAddVM supplier);

        public Task<Response> Update(SupplierUpdateVM supplier);

        public Task<Response> Delete(int Id);
    }
}
