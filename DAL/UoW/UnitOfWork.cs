using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    internal class UnitOfWork
    {
        private ShopContext _db = new ShopContext();
        private ProductRepository _productRepository;

        public ProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_db);
                return _productRepository;
            }    
        }

        public async Task Save()
        {
            _db.SaveChanges();
        }
    }
}
