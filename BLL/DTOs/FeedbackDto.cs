using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string? Comment { get; set; }
        public int ProductId { get; set; }
    }
}
