namespace BLL.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } //Название продукта
    public string Description { get; set; } //Описание продукта
    public double Price { get; set; }
}