using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ShopContext _db;
        public FeedbackRepository(ShopContext shopContext)
        {
            _db = shopContext;
        }

        public async Task CreateFeedback(Feedback feedback)
        {
            await _db.AddAsync(feedback);
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _db.FindAsync<Feedback>(id);
            _db.Feedbacks.Remove(feedback);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _db.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByProductId(int ProductId)
        {
            return await _db.Feedbacks.Where(f => f.ProductId == ProductId).ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _db.Feedbacks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _db.Feedbacks.Entry(feedback).State = EntityState.Modified;
        }
    }
}
