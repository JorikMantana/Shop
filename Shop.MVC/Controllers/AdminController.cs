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

        public AdminController(IMapper mapper, IProductService productService, IImageService imageService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModelView _product)
        {
            var product = _mapper.Map<ProductDto>(_product);
            var createdProduct = await _productService.CreateProductAsync(product);

            if(_product.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProductImages");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + _product.Image.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Сохраняем изображение на сервере
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await _product.Image.ImageFile.CopyToAsync(stream);
                }

                // Создаем DTO для изображения
                var image = new ImageDto
                {
                    ProductId = createdProduct.Id, // Устанавливаем ID продукта
                    ImagePath = filePath // Сохраняем путь к изображению
                };

                await _imageService.CreateImage(image);
            }

            return RedirectToAction("CreateNewProduct");
        }

        public IActionResult CreateNewProduct()
        {

            var model = new ProductModelView
            {
                Image = new ImageModelView() // Инициализация объекта ImageModelView
            };

            return View(model);
        }
    }
}
