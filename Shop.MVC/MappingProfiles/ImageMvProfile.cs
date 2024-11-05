using AutoMapper;
using BLL.DTOs;
using Shop.MVC.ModelViews;

namespace Shop.MVC.MappingProfiles
{
    public class ImageMvProfile : Profile
    {
        public ImageMvProfile() 
        {
            CreateMap<ImageDto, ImageModelView>().ReverseMap();
        }
    }
}
