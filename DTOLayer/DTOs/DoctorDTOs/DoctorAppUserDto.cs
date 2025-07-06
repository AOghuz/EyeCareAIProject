using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DoctorDTOs
{
    public class DoctorAppUserDto
    {
        [Required(ErrorMessage = "TC Kimlik Numarası gereklidir.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik Numarası 11 haneli olmalıdır.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçerli bir TC Kimlik Numarası giriniz.")]
        public string UserName { get; set; }
        // AppUser bilgileri
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }

        // Doctor bilgileri
        public string? Specialization { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Skill { get; set; }
        public string? Education { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public int TreatmentId { get; set; }

    }
}