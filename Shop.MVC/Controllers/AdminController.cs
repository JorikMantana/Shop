using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
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

        public AdminController(IMapper mapper, ICategoryService categoryService, IProductService productService, IImageService imageService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModelView _product)
        {
            var product = _mapper.Map<ProductDto>(_product);
            var createdProduct = await _productService.CreateProductAsync(product);

            if(_product.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProductImages");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + _product.Image.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await _product.Image.ImageFile.CopyToAsync(stream);
                }

                string relativePath = $"/img/ProductImages/{uniqueFileName}";

                var image = new ImageDto
                {
                    ItemId = createdProduct.Id, 
                    ImagePath = relativePath 
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
                    ImagePath = relativePath
                };

                await _imageService.CreateImage(image);
            }

            return RedirectToAction("CreateNewCategory");
            
        }

        public IActionResult CreateNewCategory()
        {
            var model = new CategoryModelView()
            {
                Image = new ImageModelView()
            };
            
            return View();
        }
        
        public IActionResult CreateNewProduct()
        {

            var model = new ProductModelView
            {
                Image = new ImageModelView()
            };

            return View(model);
        }
    }
}
