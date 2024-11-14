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
        
        public ProductController(IFeedbackService feedbackService, IProductService productService, IMapper mapper, IImageService imageService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
            _feedbackService = feedbackService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ProductDto productDto = await _productService.GetProductByIdAsync(id);
            var product = _mapper.Map<ProductModelView>(productDto);

            ImageDto imageDto = await _imageService.GetImageByProductId(id);
            var image = _mapper.Map<ImageModelView>(imageDto);

            IEnumerable<FeedbackDto> feedbackDtos = await _feedbackService.GetAllFeedbacks();
            var feedbacks = _mapper.Map<IEnumerable<FeedbackModelView>>(feedbackDtos);

            var model = new ProductWithFeedbackAndImageModelView()
            {
                Product = product,
                ImageUrl = image.ImagePath,
                Feedbacks = feedbacks
            };
            
            return View(model);
        }
    }
}
