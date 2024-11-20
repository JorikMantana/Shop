using DAL.Models;

namespace DAL.Interfaces;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
}