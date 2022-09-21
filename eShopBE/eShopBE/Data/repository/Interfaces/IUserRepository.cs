using eShopBE.Entities;

namespace eShopBE.Data.repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserbyUserName(string userName);
        public Task<IEnumerable<User>> GetAllCustomers();
    }
}
