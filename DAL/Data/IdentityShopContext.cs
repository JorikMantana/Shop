using DAL.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class IdentityShopContext : IdentityDbContext<ApplicationUser>
{
    public IdentityShopContext(DbContextOptions<IdentityShopContext> options) : base(options) { }
}