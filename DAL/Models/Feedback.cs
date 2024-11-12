﻿using System;
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
        public string NickName { get; set; }
        public string? Comment { get; set; }
        public int ProductId { get; set; }

        [Range(1,5)]
        public int Evaluation { get; set; }

    }
}
