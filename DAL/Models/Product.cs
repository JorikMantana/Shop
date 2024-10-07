using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Product : IdInfo
    {
        public string Name { get; set; } //Название продукта
        public string Description { get; set; } //Описание продукта
        public double Price { get; set; } //Цена продукта
        //public Image[] Images { get; set; } //Изображения продукта
    }
}
