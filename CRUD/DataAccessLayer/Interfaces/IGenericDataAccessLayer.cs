using InfrastructureLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericDataAccessLayer<T>
    {
        void Add(T name);
        void Update(T name);
        void Delete(T name);

        T FindById(int id);
    }
}
