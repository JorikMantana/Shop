using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        public Task<Product> CreateProductAsync(ProductDto modelDto);   
        public Task RemoveProductAsync(int id);
        public void UpdateProduct(ProductDto modelDto);
        public Task<ProductDto> GetProductByIdAsync(int id);
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
