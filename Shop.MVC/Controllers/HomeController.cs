using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;

namespace Shop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productDb;
        private readonly IImageService _imageDb;
        private readonly ICategoryService _categoryDb;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IImageService imageService, IProductService productService,  ICategoryService categoryService, IMapper mapper)
        {
            _imageDb = imageService;
            _productDb = productService;
            _categoryDb = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryDb.GetAllCategoriesAsync();
            var categoriesMv = _mapper.Map<IEnumerable<CategoryModelView>>(categories);

            var images = await _imageDb.GetAllImages();
            var imagesMv = _mapper.Map<IEnumerable<ImageModelView>>(images);

            var CategoryImages = categoriesMv.Select(category => new CategoryWithImageModelView()
            {
                Category = category,
                ImageUrl = imagesMv.FirstOrDefault(img=>img.ItemId == category.Id && img.ItemType == category.Type)?.ImagePath
            });

            var model = new CategoriesModelView()
            {
                CategoriesWithImages = CategoryImages
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModelView _product)
        {
            var product = _mapper.Map<ProductDto>(_product);
            await _productDb.CreateProductAsync(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Products(int CategoryId)
        {
            IEnumerable<ProductDto> productDtos = await _productDb.GetAllProductsByCategoryAsync(CategoryId);
            var products = _mapper.Map<IEnumerable<ProductModelView>>(productDtos);

            IEnumerable<ImageDto> imageDtos = await _imageDb.GetAllImages();
            var images = _mapper.Map<IEnumerable<ImageModelView>>(imageDtos);

            var productImages = products.Select(product => new ProductWithImageModelView
            {
                Product = product,
                ImageUrl = images.FirstOrDefault(img => img.ItemId == product.Id)?.ImagePath
            });

            var model = new ProductsModelView
            {
                ProductsWithImages = productImages,
            };
            
            return View(model);
        }
    }
}
