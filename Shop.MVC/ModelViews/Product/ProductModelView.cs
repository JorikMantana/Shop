namespace Shop.MVC.ModelViews
{
    public class ProductModelView
    {
        public int Id { get; set; }
        public string Name { get; set; } //Название продукта
        public string Description { get; set; } //Описание продукта
        public double Price { get; set; } //Цена продукта
        public int CategoryId { get; set; } //Категория продукта
        public string Type { get; set; } = "Product"; // Тип объекта (Для изображений)

        public ImageModelView Image { get; set; } = new ImageModelView();
    }
}
