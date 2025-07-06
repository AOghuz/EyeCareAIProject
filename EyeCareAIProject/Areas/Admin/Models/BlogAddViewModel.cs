namespace EyeCareAIProject.Areas.Admin.Models
{
    public class BlogAddViewModel
    {
        public int BlogId { get; set; } // Güncelleme için lazım
        public string? Title { get; set; }
        public string? LittleDesc { get; set; }
        public string? BigDesc { get; set; }
        public string? About { get; set; }
        public string? Owner { get; set; }
        public int TreatmentId { get; set; }

        public IFormFile? ImageFile { get; set; } // 👈 görsel yükleme
        public string? ExistingImage { get; set; } // güncellemede görsel değişmezse koruruz
    }

}
