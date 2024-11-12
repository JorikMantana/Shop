using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;


namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IUnitOfWork _db;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork UoW)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _db = UoW;

        }

        public async Task<Product> CreateProductAsync(ProductDto modelDto)
        {
            var product = _mapper.Map<Product>(modelDto);
            await _db.Products.CreateProductAsync(product);
            await _db.SaveChanges();

            return product;
        }

        public async Task RemoveProductAsync(int id)
        {
            await _db.Products.RemoveProductAsync(id);
            await _db.SaveChanges();
        }

        public void UpdateProduct(ProductDto modelDto)
        {
            _db.Products.UpdateProduct(_mapper.Map<Product>(modelDto));
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _db.Products.GetProductByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _db.Products.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        
        
    }
}
