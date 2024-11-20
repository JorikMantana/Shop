using AutoMapper;
using BLL.DTOs;

namespace Shop.MVC.MappingProfiles;

public class UserMvProfile : Profile
{
    public UserMvProfile()
    {
        CreateMap<UserDto, UserMvProfile>().ReverseMap();
    }
}