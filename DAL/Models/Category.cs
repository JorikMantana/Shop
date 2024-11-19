namespace DAL.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } //Название категории
    public ICollection<Product> Products { get; set; } //Навигационное свойство для связи с продуктами
}