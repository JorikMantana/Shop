using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}