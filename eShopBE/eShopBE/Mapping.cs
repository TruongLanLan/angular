using AutoMapper;
using eShopBE.Entities;
using eShopBE.ViewModel.CategoryVM;

namespace eShopBE
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryAddVM>().ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();



        }
    }
}
