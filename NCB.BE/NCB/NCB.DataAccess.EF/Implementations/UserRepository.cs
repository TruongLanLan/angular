using Microsoft.EntityFrameworkCore;
using NCB.Common;
using NCB.Data.Entities;
using NCB.DataAccess.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NCBDbContext ncbDbContext) : base(ncbDbContext)
        {

        }

        public async Task<IEnumerable<User>> SearchForKeyword(SearchKeyword searchKeyword)
        {
            var data = await _ncbDbContext.Users.ToListAsync();
            if(searchKeyword.keyWord.UserNumber != null)
            {
                data = data.Where(c => c.USER_ID.Contains(searchKeyword.keyWord.UserNumber.Trim())).ToList();
            }
            if(searchKeyword.keyWord.UserName != null)
            {
                data = data.Where(c => c.FIRST_NM.Contains(searchKeyword.keyWord.UserName) || c.LAST_NM.Contains(searchKeyword.keyWord.UserName)).ToList();
            }
            if(searchKeyword.keyWord.RegistrationDateBegin != null && searchKeyword.keyWord.RegistrationDateEnd != null)
            {
                data = data.Where(c => c.CREATE_DATE >= searchKeyword.keyWord.RegistrationDateBegin
                && c.CREATE_DATE <= searchKeyword.keyWord.RegistrationDateEnd).ToList();
            }
            if(searchKeyword.keyWord.Status != null)
            {
                data = data.Where(c => c.STATUS_CD.Contains(searchKeyword.keyWord.Status)).ToList();
            }
            return data;
        }
    }
}
