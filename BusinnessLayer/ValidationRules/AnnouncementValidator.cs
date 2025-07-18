﻿using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuruyu boş geçmeyin");
        }
    }
}
