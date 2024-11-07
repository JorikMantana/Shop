using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateFeedback(FeedbackDto feedback)
        {
            var _feedback = _mapper.Map<Feedback>(feedback);
            await _db.Feedbacks.CreateFeedback(_feedback);
            await _db.SaveChanges();
        }

        public async Task DeleteFeedback(int id)
        {
            await _db.Feedbacks.DeleteFeedback(id);
            await _db.SaveChanges();
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbacks()
        {
            var feedbacks = _db.Feedbacks.GetAllFeedbacks();
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task<FeedbackDto> GetFeedbackById(int id)
        {
            var feedback = await _db.Feedbacks.GetFeedbackById(id);
            return _mapper.Map<FeedbackDto>(feedback);
        }

        public void UpdateFeedback(FeedbackDto feedback)
        {
            _db.Feedbacks.UpdateFeedback(_mapper.Map<Feedback>(feedback));
        }
    }
}
