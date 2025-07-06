using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int InfoId { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public string? Location { get; set; }
        public string? WorkTime { get; set; }
        public string? MapLocation { get; set; }
        public string? FacebookURL { get; set; }
        public string? InstagramURL { get; set; }
    }
}
