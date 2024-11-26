using DAL.Models;

namespace Shop.MVC.ModelViews;

public class OrdersWithProdutsModelView
{
    public IEnumerable<OrderWithProductModelView> OrdersWithProduct { get; set; }
}