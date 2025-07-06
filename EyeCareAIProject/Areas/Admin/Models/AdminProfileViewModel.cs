using System.ComponentModel.DataAnnotations;

namespace EyeCareAIProject.Areas.Admin.Models
{
    public class AdminProfileViewModel
    {
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }

        
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

    
        public string? NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
