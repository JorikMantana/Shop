using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}