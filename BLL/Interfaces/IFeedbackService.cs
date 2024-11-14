using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFeedbackService
    {
        Task CreateFeedback(FeedbackDto feedback);
        Task<FeedbackDto> GetFeedbackById(int id);
        Task<IEnumerable<FeedbackDto>> GetAllFeedbacks();
        Task DeleteFeedback(int id);
        void UpdateFeedback(FeedbackDto feedback);
        Task<IEnumerable<FeedbackDto>> GetFeedbacksByProductId(int ProductId);
    }
}
