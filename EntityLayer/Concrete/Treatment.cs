using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public string? Description4 { get; set; }
        public string? ImageURL { get; set; }
        public string? Icon { get; set; }
        public string? HomeIcon { get; set; }
        public string? Feature1 { get; set; }
        public string? Feature2 { get; set; }
        public string? Feature3 { get; set; }

        public List<Doctor>? Doctors { get; set; }

        // Tedaviye ait randevular (One-to-Many ilişki)
        public List<Appointment>? Appointments { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
