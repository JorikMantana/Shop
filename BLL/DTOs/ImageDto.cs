using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ImagePath { get; set; }
        public bool isMainImage { get; set; }
        public string ItemType { get; set; } // К какому типу объектов относится изображение
    }
}
