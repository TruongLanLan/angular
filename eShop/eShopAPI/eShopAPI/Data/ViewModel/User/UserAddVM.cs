using eShopAPI.Common.Enum;

namespace eShopAPI.Data.ViewModel.User
{
    public class UserAddVM
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public TypeRole Roles { get; set; }
    }
}
