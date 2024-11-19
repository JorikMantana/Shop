namespace Shop.MVC.ModelViews
{
    public class ImageModelView
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ImagePath { get; set; }
        public bool? isMainImage { get; set; }
        public string ItemType { get; set; } // К какому типу объектов относится изображение
        public IFormFile ImageFile { get; set; }
    }
}
