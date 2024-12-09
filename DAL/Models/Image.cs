using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ItemId { get; set; } //Id объекта, к которому относится изображение
        public string ImagePath { get; set; } // Путь к изображению
        public bool isMainImage { get; set; } //Является ли изображение главным у продукта
        public string ItemType { get; set; } // К какому типу объектов относится изображение
    }
}
