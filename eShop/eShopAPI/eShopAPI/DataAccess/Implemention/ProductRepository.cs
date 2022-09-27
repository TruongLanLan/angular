using eShopAPI.Data.Context;
using eShopAPI.Data.Entities;
using eShopAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace eShopAPI.DataAccess.Implemention
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(eShopDBContext dBContext) : base(dBContext)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _eShopDbContext.Products.AsNoTracking()
                .Include(c => c.Pictures)
                .Where(c => c.IsDeleted == false)
                .OrderByDescending(c => c.Id)
                .Include(c => c.Supplier)
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductInHome()
        {
            return await _eShopDbContext.Products.AsNoTracking()
                .Include(x => x.Pictures)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Take(8)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetFeaturedProduct()
        {
            var listProductByVew = await _eShopDbContext.Products
                .Include(x => x.Pictures)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Sale)
                .Take(4)
                .ToListAsync();
            return listProductByVew;
        }

        public async Task<Product> GetIdProductMax()
        {
            return await _eShopDbContext.Products
                .OrderByDescending(x => x.Id)
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Picture>> GetImageByProductId(int productId)
        {
            return await _eShopDbContext.Pictures
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductCategoryId(int categoryId)
        {
            return await _eShopDbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Pictures)
                .Where(x => x.IsDeleted == false)
                .Take(4)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _eShopDbContext.Products.AsNoTracking()
                .Include(x => x.Pictures)
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _eShopDbContext.Products
                    .Include(x => x.Pictures)
                    .Include(x => x.Category)
                    .Include(x => x.Supplier)
                    .Where(x => x.IsDeleted == false)
                    .ToListAsync();

            }
            return await _eShopDbContext.Products
                .Include(x => x.Pictures)
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Name
                .Contains(name))
                .ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetRecentProduct()
        {
            var listProductByVew = await _eShopDbContext.Products
                .Include(x => x.Pictures)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Take(4)
                .ToListAsync();
            return listProductByVew;
        }

        public async Task<IEnumerable<Product>> GetProductStock()
        {
            return await _eShopDbContext.Products.Include(x => x.Category)
                .Include(x => x.Supplier)
                .Where(x => x.IsDeleted == false && x.Inventory <= 3)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

        }
    }
}
