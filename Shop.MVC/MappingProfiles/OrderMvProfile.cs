using AutoMapper;
using BLL.DTOs;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles;

public class OrderMvProfile : Profile
{
    public OrderMvProfile()
    {
        CreateMap<OrderDto, OrderModelView>().ReverseMap();
    }
}