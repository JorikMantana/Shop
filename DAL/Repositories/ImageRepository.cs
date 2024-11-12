using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ShopContext _db;

        public ImageRepository(ShopContext _dbContext)
        {
            _db = _dbContext;
        }

        public async Task CreateImage(Image model)
        {
            await _db.AddAsync(model);
        }

        public async Task DeleteImage(int Id)
        {
            var image = await _db.Images.FindAsync(Id);
            _db.Images.Remove(image);
        }

        public async Task<Image> GetImageById(int id)
        {
            return await _db.Images.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _db.Images.ToListAsync();
        }

        public async Task<Image> GetImageByProductId(int ProductId)
        {
            return await _db.Images.FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }
    }
}
