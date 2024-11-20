namespace BLL.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; } //Почта пользователя
    public string Password { get; set; } //Пароль пользователя
}