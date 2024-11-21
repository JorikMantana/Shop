using System.Security.Claims;
using BLL.DTOs;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces;

public interface IUserService
{
    Task CreateUser(UserDto user);
    Task LoginUser(UserDto user);
    Task LogOutUser();
}