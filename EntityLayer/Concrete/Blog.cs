using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        public int TreatmentId { get; set; }
        public Treatment? Treatment { get; set; }
        public DateTime? BlogDate { get; set; }
        public string? Owner { get; set; }
        public string? Title { get; set; }
        public string? LittleDesc { get; set; }
        public string? BigDesc { get; set; }
        public string? About { get; set; }
        public string? ImageURL { get; set; }
        public List<Comment>? Comments { get; set; }


    }
}
