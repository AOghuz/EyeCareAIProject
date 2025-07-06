using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public string? Specialization { get; set; } // Doktorun uzmanlık alanı
        public string? Description { get; set; }
        public string? Experience { get; set; } // Mesleki Deneyim
        public string? Skill { get; set; }
        public string? Education { get; set; } // Eğitim bilgisi
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }

        public bool? Status { get; set; } // Aktif/Pasif durumu

        public int TreatmentId { get; set; }  // Foreign Key
        public Treatment? Treatment { get; set; }
    }

}
