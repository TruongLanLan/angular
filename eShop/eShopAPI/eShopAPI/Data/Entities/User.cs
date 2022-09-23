using eShopAPI.Common.Enum;
using System;

namespace eShopAPI.Data.Entities
{
    public class User
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
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public TypeRole Roles { get; set; }
    }
}
