using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Home
    {
        [Key]
        public int Id { get; set; } // Benzersiz bir kimlik

        public string? Title { get; set; } // Başlık

        public string? Description { get; set; } // Yazı (Açıklama)

        public string? ImageUrl { get; set; } // Görselin URL'si
        
    }
}
