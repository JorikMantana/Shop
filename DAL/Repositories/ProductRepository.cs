using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private ShopContext _db;

        public ProductRepository(ShopContext shopContext) 
        {
            _db = shopContext;
        }

        public async Task CreateProductAsync(Product model)
        {
            await _db.AddAsync(model);
        }

        public async Task RemoveProductAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            
            if(product == null)
                return;
            
            _db.Remove(product);
        }

        public void UpdateProduct(Product model)
        {
            if(model == null)
                return;
            
            _db.Products.Entry(model).State = EntityState.Modified;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            if (!_db.Products.Any())
                return null;
            
            return await _db.Products.ToListAsync();
        }
    }
}
