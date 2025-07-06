
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
        }
    }
}
