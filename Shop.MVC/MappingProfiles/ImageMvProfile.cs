using AutoMapper;
using BLL.DTOs;

namespace Shop.MVC.MappingProfiles
{
    public class ImageMvProfile : Profile
    {
        public ImageMvProfile() 
        {
            CreateMap<ImageDto, ImageMvProfile>().ReverseMap();
        }
    }
}
