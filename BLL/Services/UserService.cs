using System.Security.Claims;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.IdentityEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IIdentityUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    
    public UserService(UserManager<User> userManager, IIdentityUnitOfWork unitOfWork, IMapper mapper, SignInManager<User> signInManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task CreateUser(UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        if (await _userManager.FindByEmailAsync(userEntity.Email) == null)
        {
            await _userManager.CreateAsync(userEntity);
        }
    }

    public async Task LoginUser(UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        await _signInManager.SignInAsync(userEntity, false);
    }
}