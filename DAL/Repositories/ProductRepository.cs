using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
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
            return await _db.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int categoryId)
        {
            return await _db.Products.Where(p => p.Category.Id == categoryId).ToListAsync();
        }
    }
}
