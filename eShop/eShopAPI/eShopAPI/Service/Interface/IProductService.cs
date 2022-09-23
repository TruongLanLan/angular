

using eShopAPI.Common;
using eShopAPI.Data.ViewModel.Product;

namespace eShopAPI.Service.Interface
{
    public interface IProductService
    {
        public Task<Response> GetAll();
        public Task<Response> GetAllProductAdmin();
        public Task<Response> GetAllProductInHome();

        public Task<Response> GetById(int id);

        public Task<Response> GetByName(string name);

        public Task<Response> Add(ProductAddVM product);

        public Task<Response> Update(ProductUpdateVM product);

        public Task<Response> Detele(int id);
        public Task<Response> GetIdProductMax();
        public Task<Response> GetProductStock();

        public Task<Response> GetFeaturedProduct();
        public Task<Response> GetRecentProduct();
        public Task<Response> GetProductByCategoryId(int categoryId);

    }
}
