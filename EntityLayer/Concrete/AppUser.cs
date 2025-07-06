using EntityLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string? Address { get; set; } 
        public string? ContactNumber { get; set; }
        public UserType? UserType { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Comment>? Comments { get; set; }


    }
}


