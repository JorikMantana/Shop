using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } //Название продукта
        public string Description { get; set; } //Описание продукта
        public double Price { get; set; } //Цена продукта
        public int CategoryId { get; set; } // Id категории, к которой относится продукт
        public virtual Category Category { get; set; } //Навигационное поле, категория продукта
    }
}
