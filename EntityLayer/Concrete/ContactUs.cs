﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? MessageDate { get; set; }
        public bool? MessageStatus { get; set; }
    }
}
