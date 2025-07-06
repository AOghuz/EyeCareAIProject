using System.ComponentModel.DataAnnotations;

namespace EyeCareAIProject.Areas.Admin.Models
{
    public class PatientUpdateDto
    {
        public int Id { get; set; }  // Güncelleme için gerekli
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IFormFile? Image { get; set; }  // Opsiyonel profil resmi
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        public string TurkishIdentityNumber { get; set; }

    }
}
