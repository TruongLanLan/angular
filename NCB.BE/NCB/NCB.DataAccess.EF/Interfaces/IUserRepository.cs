using NCB.Common;
using NCB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> SearchForKeyword(SearchKeyword searchKeyword);
    }
}
