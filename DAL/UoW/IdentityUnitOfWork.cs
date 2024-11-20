using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.IdentityEntities;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.UoW;

public class IdentityUnitOfWork : IIdentityUnitOfWork
{
    private readonly IdentityShopContext _context;
    private UserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public IdentityUnitOfWork(UserRepository userRepository, IdentityShopContext context, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _context = context;
    }
    
    public IUserRepository Users
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_userManager);
            return _userRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}