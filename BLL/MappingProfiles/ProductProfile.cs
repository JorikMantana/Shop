using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}