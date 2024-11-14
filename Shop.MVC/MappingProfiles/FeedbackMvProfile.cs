using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles
{
    public class FeedbackMvProfile : Profile
    {
        public FeedbackMvProfile()
        {
            CreateMap<FeedbackDto, FeedbackModelView>().ReverseMap();
        }
    }
}