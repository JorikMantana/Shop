using DAL.Models;

namespace Shop.MVC.ModelViews;

public class ProductWithCategoriesModelView
{
    public ProductModelView Product { get; set; }
    public IEnumerable<CategoryModelView> Categories { get; set; }
    public CategoryModelView Category { get; set; } = new CategoryModelView();
    public ImageModelView Image { get; set; } = new ImageModelView();
}