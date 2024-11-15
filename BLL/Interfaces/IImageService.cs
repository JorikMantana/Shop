﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImageService
    {
        public Task CreateImage(ImageDto model);
        public Task DeleteImage(int id);
        public Task<ImageDto> GetImageById(int id);
        public Task<IEnumerable<ImageDto>> GetAllImages();
        public Task<ImageDto> GetImageByProductId(int ProductId);
    }
}
