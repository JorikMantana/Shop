namespace Shop.MVC.ModelViews;

public class OrderModelView
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public string Address { get; set; }
}