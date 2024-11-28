using System.ComponentModel.DataAnnotations;

namespace Shop.MVC.ModelViews;

public class UserModelView
{
    public string Email { get; set; }
    public string Password { get; set; }
    [Required(ErrorMessage = "Имя введи, хуило")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Please enter your Addres")]
    public string Address { get; set; } // Адрес проживания пользователя
}