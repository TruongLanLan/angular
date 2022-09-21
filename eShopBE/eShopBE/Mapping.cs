using AutoMapper;
using eShopBE.Entities;
using eShopBE.ViewModel.CategoryVM;
using eShopBE.ViewModel.ProductVM;
using eShopBE.ViewModel.SupplierVM;
using eShopBE.ViewModel.UserViewM;

namespace eShopBE
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryAddVM>().ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();
            CreateMap<CategoryVM, Category>().ReverseMap();

            CreateMap<Supplier, SupplierAddVM>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateVM>().ReverseMap();
            CreateMap<SupplierVM, Supplier>().ReverseMap();

            CreateMap<Product, ProductAddVM>().ReverseMap();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
            CreateMap<ProductVM, Product>().ReverseMap();

            CreateMap<User, UserAddVM>().ReverseMap();
            CreateMap<User, UserUpdateVM>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();




        }
    }
}
