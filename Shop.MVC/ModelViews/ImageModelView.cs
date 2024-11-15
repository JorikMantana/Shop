namespace Shop.MVC.ModelViews
{
    public class ImageModelView
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ImagePath { get; set; }
        public bool? isMainImage { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
