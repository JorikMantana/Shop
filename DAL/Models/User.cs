using Microsoft.AspNetCore.Identity;

namespace DAL.Models;

public class User : IdentityUser
{
    public string Address { get; set; } // Адрес проживания пользователя
}