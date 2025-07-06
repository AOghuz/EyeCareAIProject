using System.ComponentModel.DataAnnotations;

namespace EyeCareAIProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı giriniz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string? SurName { get; set; }
        [Required(ErrorMessage = "Lütfen TC Kimlik numaranızı giriniz")]
        public string? TurkishIdentityNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Mail adresinizi giriniz")]
        public string? Mail { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Lütfen Tekrar şifre giriniz"), Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        public string? ConfirmPassword { get; set; }
        // Yeni Eklenen Alanlar: Cinsiyet ve Doğum Tarihi
        [Required(ErrorMessage = "Lütfen Cinsiyetinizi seçiniz")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Lütfen Doğum tarihinizi seçiniz")]
        public DateTime? DateOfBirth { get; set; }
    }
}
