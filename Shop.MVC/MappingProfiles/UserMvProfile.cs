using AutoMapper;
using BLL.DTOs;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles;

public class UserMvProfile : Profile
{
    public UserMvProfile()
    {
        CreateMap<UserDto, UserModelView>().ReverseMap();
    }
}