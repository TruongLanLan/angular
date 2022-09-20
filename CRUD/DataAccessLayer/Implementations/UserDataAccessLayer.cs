using DataAccessLayer.DataUIContext;
using DataAccessLayer.Interfaces;
using InfrastructureLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class UserDataAccessLayer : GenericDataAccessLayer<User>, IUserDataAccessLayer
    {
        public UserDataAccessLayer(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
