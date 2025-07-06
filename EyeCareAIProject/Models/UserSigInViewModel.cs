using System.ComponentModel.DataAnnotations;

namespace EyeCareAIProject.Models
{
    public class UserSigInViewModel
    {
        [Required(ErrorMessage = "T.C. Kimlik Numarası gereklidir.")]
        [StringLength(11, ErrorMessage = "T.C. Kimlik Numarası 11 karakter olmalıdır.")]
        public string TurkishIdentityNumber { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; }
    }
}
