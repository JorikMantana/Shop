namespace DAL.Models;

public class Order
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int Count { get; set; }
    public string Address { get; set; }
}