using AutoMapper;
using eShopAPI.Data.Entities;
using eShopAPI.Data.ViewModel.Category;
using eShopAPI.Data.ViewModel.Product;
using eShopAPI.Data.ViewModel.SaleCode;
using eShopAPI.Data.ViewModel.Supplier;
using eShopAPI.Data.ViewModel.User;

namespace eShopAPI.Common
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

            CreateMap<SaleCode, SaleCodeAddVM>().ReverseMap();
            CreateMap<SaleCode, SaleCodeUpdateVM>().ReverseMap();
        }
    }
}
