using DAL.Models;

namespace Shop.MVC.ModelViews;

public class OrderWithProductModelView
{
    public OrderModelView Order { get; set; }
    public ProductModelView Product { get; set; }
}