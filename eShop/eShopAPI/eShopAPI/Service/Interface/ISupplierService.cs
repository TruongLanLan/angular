
using eShopAPI.Common;
using eShopAPI.Data.ViewModel.Supplier;

namespace eShopAPI.Service.Interface
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
