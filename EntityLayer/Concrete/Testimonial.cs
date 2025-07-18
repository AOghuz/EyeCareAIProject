﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? Comment { get; set; }
        public string? Job { get; set; }
        public bool? Status { get; set; }
    }
}
