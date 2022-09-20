
using eShopBE.Data.Context;
using eShopBE.Data.repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopBE.Data.repository.Implementstions
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly eShopDBContext _eShopDbContext;

        public GenericRepository(DbSet<T> dbSet, eShopDBContext eShopDbContext)
        {
            _dbSet = dbSet;
            _eShopDbContext = eShopDbContext;

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
           return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
        }
    }
}
