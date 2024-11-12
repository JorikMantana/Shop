using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;

namespace Shop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        IProductService _productService;
        IImageService _imageService;
        
        public ProductController(IProductService productService, IMapper mapper, IImageService imageService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ProductDto productDto = await _productService.GetProductByIdAsync(id);
            var product = _mapper.Map<ProductModelView>(productDto);

            ImageDto imageDto = await _imageService.GetImageByProductId(id);
            var image = _mapper.Map<ImageModelView>(imageDto);

            var model = new ProductWithImageModelView()
            {
                Product = product,
                ImageUrl = image.ImagePath
            };
            
            return View(model);
        }
    }
}
