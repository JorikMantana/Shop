using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Shop.MVC.ModelViews;

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

        public async Task<IActionResult> Create(ImageModelView model, ProductModelView _product)
        {
            var product = _mapper.Map<ProductDto>(_product);
            await _productService.CreateProductAsync(product);

            var image = _mapper.Map<ImageDto>(model);
            await _imageService.CreateImage(image);

            return RedirectToAction("CreateNewProduct");
        }

        public IActionResult CreateNewProduct()
        {
            return View();
        }
    }
}
