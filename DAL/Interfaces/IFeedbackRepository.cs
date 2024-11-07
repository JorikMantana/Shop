using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFeedbackRepository
    {
        Task CreateFeedback(Feedback feedback);
        Task DeleteFeedback(int id);
        Task<Feedback> GetFeedbackById(int id);
        void UpdateFeedback(Feedback feedback);
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
    }
}
