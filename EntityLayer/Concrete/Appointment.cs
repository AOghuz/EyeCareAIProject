using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public DateTime? AppointmentDate { get; set; }
        

        public string? AppointmentTime { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int TreatmentId { get; set; }
        public Treatment? Treatment { get; set; }
        public int? DoctorId { get; set; }  // Foreign Key olarak ekledik
        public Doctor? Doctor { get; set; }  // Navigation Property
    }
}
