using System.Security.Claims;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task CreateUser(UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        await _userManager.CreateAsync(userEntity, user.Password);
    }

    public async Task LoginUser(UserDto user)
    {
        var userEntity = await _userManager.FindByEmailAsync(user.Email);
        await _signInManager.PasswordSignInAsync(userEntity, user.Password, false, false);
    }

    public async Task LogOutUser()
    {
        await _signInManager.SignOutAsync();
    }
}