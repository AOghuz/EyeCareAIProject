using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature 

    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SubTitle1 { get; set; }
        public string? SubDescription1 { get; set; }
        public string? SubTitle2 { get; set; }
        public string? SubDescription2 { get; set; }
        public string? SubTitle3 { get; set; }
        public string? SubDescription3 { get; set; }
        public string? SubTitle4 { get; set; }
        public string? SubDescription4 { get; set; }
    }
}
