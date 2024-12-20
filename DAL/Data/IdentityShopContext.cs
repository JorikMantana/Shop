using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data;

public class IdentityShopContext : IdentityDbContext<User>
{
    public IdentityShopContext(DbContextOptions<IdentityShopContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}