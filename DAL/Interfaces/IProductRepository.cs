using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        public Task CreateProductAsync(Product model);
        public Task RemoveProductAsync(int id);
        public void UpdateProduct(Product model);
        public Task<Product> GetProductByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(string category);
    }
}
