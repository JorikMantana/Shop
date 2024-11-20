using System.Security.Claims;
using BLL.DTOs;

namespace BLL.Interfaces;

public interface IUserService
{
    Task CreateUser(UserDto user);
    Task<ClaimsIdentity> Authenticate(UserDto user);
}