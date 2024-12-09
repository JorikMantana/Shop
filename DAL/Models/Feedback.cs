using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string NickName { get; set; } //Никнейм пользователя
        public string? Comment { get; set; } //Комментарий
        public int ProductId { get; set; } //id продукта, на который оставляется комментарий
    }
}
