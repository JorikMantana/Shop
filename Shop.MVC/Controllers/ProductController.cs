using System.Security.Claims;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;

namespace Shop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        IProductService _productService;
        IImageService _imageService;
        IFeedbackService _feedbackService;
        IOrderService _orderService;
        

        public ProductController(IFeedbackService feedbackService, IProductService productService, IMapper mapper, IImageService imageService, IOrderService orderService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
            _feedbackService = feedbackService;
            _orderService = orderService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ProductDto productDto = await _productService.GetProductByIdAsync(id);
            var product = _mapper.Map<ProductModelView>(productDto);

            ImageDto imageDto = await _imageService.GetImageByProductId(id);
            var image = _mapper.Map<ImageModelView>(imageDto);

            IEnumerable<FeedbackDto> feedbackDtos = await _feedbackService.GetFeedbacksByProductId(id);
            var feedbacks = _mapper.Map<IEnumerable<FeedbackModelView>>(feedbackDtos);

            var model = new ProductWithFeedbackAndImageModelView()
            {
                Product = product,
                ImageUrl = image.ImagePath,
                Feedbacks = feedbacks,
                Feedback = new FeedbackModelView()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(ProductWithFeedbackAndImageModelView model)
        {
            var feedback = _mapper.Map<FeedbackDto>(model.Feedback);
            await _feedbackService.CreateFeedback(feedback);
            
            return RedirectToAction("Index", "Product", new { id = model.Feedback.ProductId });
        }

        [HttpPost]
        public async Task<IActionResult> ProductToOrder(ProductWithFeedbackAndImageModelView model)
        {
            var order = new OrderDto();

            order.ProductId = model.Product.Id;
            order.UserName = User.Identity.Name;
            order.Address = "Some address";
            order.Count = 1;
            
            await _orderService.CreateOrder(order);
            
            return RedirectToAction("Index", "Product", new { id = model.Product.Id });
        }
    }
}
