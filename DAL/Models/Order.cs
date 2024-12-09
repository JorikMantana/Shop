namespace DAL.Models;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; } //id продукта в заказе
    public string UserName { get; set; } //Имя заказчика
    public int Count { get; set; } //Кол-во 
    public string Address { get; set; } //Адрес заказчика
}