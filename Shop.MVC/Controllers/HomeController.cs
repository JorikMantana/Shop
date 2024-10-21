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
        private readonly IProductService _db;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
        {
            _db = productService;
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
            await _db.CreateProductAsync(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
            IEnumerable<ProductDto> productDtos = await _db.GetAllProductsAsync();
            var products = _mapper.Map<IEnumerable<ProductModelView>>(productDtos);

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
