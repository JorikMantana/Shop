using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task CreateUserAsync(User user)
    {
        await _userManager.CreateAsync(user);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user;
    }

    public async Task<bool> CheckIfUserExistsAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if(user != null)
            return true;
        else
        {
            return false;
        }
    }
}