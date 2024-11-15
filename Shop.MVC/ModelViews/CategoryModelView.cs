namespace Shop.MVC.ModelViews;

public class CategoryModelView
{
    public int Id { get; set; }
    public string Name { get; set; } //Название категории
    public ImageModelView Image { get; set; } = new ImageModelView();
}