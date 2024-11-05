using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.Models;
using Shop.MVC.ModelViews;
using System.Diagnostics;

namespace Shop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productDb;
        private readonly IImageService _imageDb;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IImageService imageService, IProductService productService, IMapper mapper)
        {
            _imageDb = imageService;
            _productDb = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModelView _product)
        {
            var product = _mapper.Map<ProductDto>(_product);
            await _productDb.CreateProductAsync(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
            IEnumerable<ProductDto> productDtos = await _productDb.GetAllProductsAsync();
            var products = _mapper.Map<IEnumerable<ProductModelView>>(productDtos);

            IEnumerable<ImageDto> imageDtos = await _imageDb.GetAllImages();
            var images = _mapper.Map<IEnumerable<ImageModelView>>(imageDtos);

            var productImages = products.Select(product => new ProductWithImageModelView
            {
                Product = product,
                ImageUrl = images.FirstOrDefault(img => img.ProductId == product.Id)?.ImagePath // Предполагается, что у вас есть свойство ProductId в ImageDto
            });

            var model = new ProductsModelView
            {
                ProductsWithImages = productImages,
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
