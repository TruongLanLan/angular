using eShopAPI.Common.Enum;

namespace eShopAPI.Data.ViewModel.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public RANK? CustomerRank { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int CoutOrder { get; set; }
        public string Phone { get; set; }
        public long TotalPrice { get; set; }
    }
}
