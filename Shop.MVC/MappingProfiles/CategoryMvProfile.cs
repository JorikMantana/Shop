using AutoMapper;
using BLL.DTOs;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles;

public class CategoryMvProfile : Profile
{
    public CategoryMvProfile()
    {
        CreateMap<CategoryDto, CategoryModelView>().ReverseMap();
    }
}