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
     public class UnitOfWork : IUnitOfWork
    {
        private ShopContext _db;
        private ProductRepository _productRepository;
        private ImageRepository _imageRepository;
        private FeedbackRepository _feedbackRepository;

        public UnitOfWork(ShopContext shopContext)
        {
            _db = shopContext;
        }

        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_db);
                return _productRepository;
            }    
        }

        public IImageRepository Images
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository(_db);
                return _imageRepository;
            }
        }

        public IFeedbackRepository Feedbacks
        {
            get
            {
                if (_feedbackRepository == null)
                    _feedbackRepository = new FeedbackRepository(_db);
                return _feedbackRepository;
            }
        }

        public async Task SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
