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
        public Category? Category { get; set; } //Категория продукта
    }
}
