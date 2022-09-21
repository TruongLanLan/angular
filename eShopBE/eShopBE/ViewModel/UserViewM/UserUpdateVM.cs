﻿using eShopBE.Infrastructure.Enum;

namespace eShopBE.ViewModel.UserViewM
{
    public class UserUpdateVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public RANK? CustomerRank { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
