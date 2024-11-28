namespace BLL.DTOs;

public class UserDto
{
    public string Email { get; set; } //Почта пользователя
    public string Password { get; set; } //Пароль пользователя
    public string UserName { get; set; } //Имя пользователя
    public string Address { get; set; } // Адрес проживания пользователя
}