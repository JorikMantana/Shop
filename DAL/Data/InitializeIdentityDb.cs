using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Data;

public static class InitializeIdentityDb
{
    public static async Task InitializeDb(IServiceProvider serviceProvider)
    {
        var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var _userManager = serviceProvider.GetRequiredService<UserManager<User>>();


        var admin = await _userManager.FindByEmailAsync("admin@admin.com");
        if (admin == null)
        {
            var user = new User()
            {
                UserName = "admin",
                Email = "admin@admin.com",
                Address = "Admin"
            };
        
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _userManager.CreateAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}