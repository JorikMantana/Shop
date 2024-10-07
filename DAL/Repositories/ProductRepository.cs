using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class ProductRepository : IProductRepository<Product>
    {
        private ShopContext _db;

        public ProductRepository(ShopContext shopContext) 
        {
            _db = shopContext;
        }

        public async Task AddToDb(Product model)
        {
            await _db.AddAsync(model);
        }

        public async Task<IQueryable<Product>> GetAllFromDb()
        {
            //TODO
        }

        public Task GetFromDb(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromDb(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDb(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
