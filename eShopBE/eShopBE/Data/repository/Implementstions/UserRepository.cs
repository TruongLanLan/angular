using eShopBE.Data.Context;
using eShopBE.Data.repository.Interfaces;
using eShopBE.Entities;
using eShopBE.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;

namespace eShopBE.Data.repository.Implementstions
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(eShopDBContext dbContext) : base(dbContext)
        {

        }
        
        public async Task<IEnumerable<User>> GetAllCustomers()
        {
            return await _eShopDbContext.Users.Where(c => c.Roles == TypeRole.CUSTOMER).ToArrayAsync();
        }

        public async Task<User> GetUserbyUserName(string userName)
        {
            return await _eShopDbContext.Users.FirstOrDefaultAsync(c => c.UserName.Equals(userName));
        }
    }
}
