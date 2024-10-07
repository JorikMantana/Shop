using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;


namespace BLL.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add()
        {
            _productRepository.AddToDb();
        }

        public void Delete()
        {
            _productRepository.RemoveFromDb();
        }

        public void Get()
        {
            _productRepository.GetFromDb();
        }

        public void GetAll()
        {
            _productRepository.GetAllFromDb();
        }

        public void Update()
        {
            _productRepository.UpdateToDb();
        }
    }
}
