using DTOLayer.DTOs.DoctorDTOs;
using FluentValidation;

namespace BusinnessLayer.ValidationRules.DoctorValidationRules
{
    public class DoctorAppUserValidator : AbstractValidator<DoctorAppUserDto>
    {
        public DoctorAppUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.").EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.UserName)
    .NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.")
    .Length(11).WithMessage("TC Kimlik Numarası 11 haneli olmalıdır.")
    .Matches(@"^\d{11}$").WithMessage("TC Kimlik Numarası sadece rakamlardan oluşmalıdır.");

        }
    }
}