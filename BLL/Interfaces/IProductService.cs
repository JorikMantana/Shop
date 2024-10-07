using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        public Task CreateProductAsync(ProductDTO modelDto);
        public Task RemoveProductAsync(int id);
        public void UpdateProduct(ProductDTO modelDto);
        public Task<ProductDTO> GetProductByIdAsync(int id);
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}
