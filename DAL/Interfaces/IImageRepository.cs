using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IImageRepository
    {
        public Task CreateImage(Image model);
        public Task DeleteImage(int Id);
        public Task<Image> GetImageById(int Id);
        public Task<IEnumerable<Image>> GetAllImages();
        public Task<Image> GetImageByProductId(int ProductId);
    }
}
