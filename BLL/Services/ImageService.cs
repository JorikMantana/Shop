﻿using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _db = unitOfWork;
        }

        public async Task CreateImage(ImageDto model)
        {
            var image = _mapper.Map<Image>(model);
            await _db.Images.CreateImage(image);
            await _db.SaveChanges();
        }

        public async Task DeleteImage(int id)
        {
            await _db.Images.DeleteImage(id);
            await _db.SaveChanges();
        }

        public async Task<ImageDto> GetImageById(int id)
        {
            var image = await _db.Images.GetImageById(id);
            var imageDto = _mapper.Map<ImageDto>(image);
            return imageDto;
        }

        public async Task<IEnumerable<ImageDto>> GetAllImages()
        {
            var images = await _db.Images.GetAllImages();
            return _mapper.Map<IEnumerable<ImageDto>>(images);
        }

        public async Task<ImageDto> GetImageByProductId(int ProductId)
        {
            var image = await _db.Images.GetImageByProductId(ProductId);
            var imageDto = _mapper.Map<ImageDto>(image);
            return imageDto;
        }
    }
}
