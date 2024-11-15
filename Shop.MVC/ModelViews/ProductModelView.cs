namespace Shop.MVC.ModelViews
{
    public class ProductModelView
    {
        public int Id { get; set; }
        public string Name { get; set; } //Название продукта
        public string Description { get; set; } //Описание продукта
        public double Price { get; set; } //Цена продукта
        public string? Category { get; set; } //Категория продукта

        public ImageModelView Image { get; set; } = new ImageModelView();
    }
}
