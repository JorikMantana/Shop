using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}