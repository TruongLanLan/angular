using eShopAPI.Data.Entities;

namespace eShopAPI.DataAccess.Interface
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProduct();
        public Task<IEnumerable<Product>> GetAllProductInHome();
        public Task<Product> GetProductById(int id);
        public Task<IEnumerable<Product>> GetFeaturedProduct();
        public Task<IEnumerable<Product>> GetRecentProduct();
        public Task<Product> GetIdProductMax();
        public Task<IEnumerable<Product>> GetProductByName(string name);
        public Task<IEnumerable<Product>> GetProductCategoryId(int categoryId);
        public Task<IEnumerable<Picture>> GetImageByProductId(int productId);
        public Task<IEnumerable<Product>> GetProductStock();
    }
}
