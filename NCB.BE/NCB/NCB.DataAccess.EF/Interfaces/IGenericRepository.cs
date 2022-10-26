using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entity);
        void Update(T entity);
        void Update(IEnumerable<T> entity);
    }
}
