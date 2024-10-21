using AutoMapper;
using BLL.DTOs;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles
{
    public class ProductMvProfile : Profile
    {
        public ProductMvProfile() 
        {
            CreateMap<ProductDto, ProductModelView>().ReverseMap();
        }
    }
}
