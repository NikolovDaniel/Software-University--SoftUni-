using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {

            CreateMap<ImportUserDto, User>();

            CreateMap<ImportProductDto, Product>();
            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Seller, opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            CreateMap<ImportCategoryDto, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
