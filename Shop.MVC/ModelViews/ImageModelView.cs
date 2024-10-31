namespace Shop.MVC.ModelViews
{
    public class ImageModelView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool isMainImage { get; set; }
    }
}
