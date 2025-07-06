using System.ComponentModel.DataAnnotations;
namespace EyeCareAIProject.Models
{
    public class DoctorProfileViewModel
    {
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        public string? ContactNumber { get; set; }

        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string? ConfirmPassword { get; set; }
    }

}