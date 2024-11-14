namespace Shop.MVC.ModelViews;

public class ProductWithFeedbackAndImageModelView
{
    public ProductModelView Product { get; set; }
    public string ImageUrl { get; set; }
    public IEnumerable<FeedbackModelView> Feedbacks { get; set; }
}