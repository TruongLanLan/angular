using AutoMapper;
using NCB.Data.Entities;
using NCB.Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Common
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserAddVM>().ReverseMap();
            CreateMap<User, UserUpdateVM>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
