using DataAccessLayer.DataUIContext;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class GenericDataAccessLayer<T> : IGenericDataAccessLayer<T> where T : class // do DbSet inject đến các bảng trong database nên cần điều kiện để T là 1 class đại diện cho bảng
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<T> _dbSet;
        public GenericDataAccessLayer(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<T>();
        }
        public void Add(T name)
        {
            _dbSet.Add(name);
        }

        public void Delete(T name)
        {
            _dbSet.Remove(name);
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T name)
        {
            _dbSet.Update(name);
        }
    }
}
