using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;

namespace Shop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
    
        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();    
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModelView user)
        {
            var newUser = _mapper.Map<UserDto>(user);
            await _userService.CreateUser(newUser);

            return RedirectToAction("Registration");
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginUser(UserModelView user)
        {
            var loginUser = _mapper.Map<UserDto>(user);
            await _userService.LoginUser(loginUser);
            
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogOutUser();
            return RedirectToAction("Login");
        }
    }
}