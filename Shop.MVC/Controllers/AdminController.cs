using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public AdminController(IMapper mapper, IOrderService orderService, ICategoryService categoryService, IProductService productService, IImageService imageService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            var orders = await _orderService.GetAllOrders();
            var mappedOrders = _mapper.Map<IEnumerable<OrderModelView>>(orders);

            var products = await _productService.GetAllProductsAsync();
            var mappedProducts = _mapper.Map<IEnumerable<ProductModelView>>(products);

            var orderWithProduct = mappedOrders.Select(order => new OrderWithProductModelView
            {
                Order = order,
                Product = mappedProducts.FirstOrDefault(p => p.Id == order.ProductId)
            });

            var model = new OrdersWithProdutsModelView()
            {
                OrdersWithProduct = orderWithProduct
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductWithCategoriesModelView _productWithCategories)
        {
            var product = _mapper.Map<ProductDto>(_productWithCategories.Product);
            var createdProduct = await _productService.CreateProductAsync(product);

            if(_productWithCategories.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProductImages");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + _productWithCategories.Product.Image.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await _productWithCategories.Product.Image.ImageFile.CopyToAsync(stream);
                }

                string relativePath = $"/img/ProductImages/{uniqueFileName}";

                var image = new ImageDto
                {
                    ItemId = createdProduct.Id, 
                    ImagePath = relativePath,
                    ItemType = _productWithCategories.Product.Type
                };

                await _imageService.CreateImage(image);
            }

            return RedirectToAction("CreateNewProduct");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryModelView category)
        {
            var _category = _mapper.Map<CategoryDto>(category);
            var createdCategory = await _categoryService.CreateCategoryAsync(_category);

            if (category.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/CategoryIcons");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + category.Image.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await category.Image.ImageFile.CopyToAsync(stream);
                }

                string relativePath = $"/img/CategoryIcons/{uniqueFileName}";

                var image = new ImageDto
                {
                    ItemId = createdCategory.Id,
                    ImagePath = relativePath,
                    ItemType = category.Type
                };

                await _imageService.CreateImage(image);
            }

            return RedirectToAction("CreateNewCategory");
            
        }

        [Authorize]
        public IActionResult CreateNewCategory()
        {
            var model = new CategoryModelView()
            {
                Image = new ImageModelView()
            };
            
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateNewProduct()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var _categories = _mapper.Map<IEnumerable<CategoryModelView>>(categories);
            
            var model = new ProductWithCategoriesModelView()
            {
                Image = new ImageModelView(),
                Categories = _categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrder(id);
            return RedirectToAction("OrdersList");
        }
    }
}
