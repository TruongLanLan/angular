using NCB.Common;
using NCB.Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Response> Get(SearchKeyword keyword);

        public Task<Response> Update(UserUpdateVM user);
        public Task<Response> Create(UserAddVM user);
    }
}
