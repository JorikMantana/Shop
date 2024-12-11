using System.ComponentModel.DataAnnotations;

namespace Shop.MVC.ModelViews
{
    public class FeedbackModelView
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string? Comment { get; set; }
        public int ProductId { get; set; }
    }
}