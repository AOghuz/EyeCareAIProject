using System.ComponentModel.DataAnnotations;

namespace EyeCareAIProject.Models
{
    public class DoctorAppUserViewModel
    {

        // AppUser bilgileri
        [Required(ErrorMessage = "TC Kimlik Numarası zorunludur.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik Numarası 11 haneli olmalıdır.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "TC Kimlik Numarası sadece rakamlardan oluşmalıdır.")]
        public string UserName { get; set; }

        public string FirstName { get; set; } // Zorunlu
        public string LastName { get; set; }  // Zorunlu
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string Email { get; set; } // Zorunlu
        public string Password { get; set; } // Zorunlu
        public string NewPassword { get; set; }
        public IFormFile? Image { get; set; } // Opsiyonel resim

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
