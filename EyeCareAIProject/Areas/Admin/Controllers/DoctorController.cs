using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using EyeCareAIProject.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinnessLayer.ValidationRules.DoctorValidationRules;
using DTOLayer.DTOs.DoctorDTOs;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    

    [Route("Admin/Doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITreatmentService _treatmentService;

        public DoctorController(IDoctorService doctorService, UserManager<AppUser> userManager, ITreatmentService treatmentService)
        {
            _doctorService = doctorService;
            _userManager = userManager;
            _treatmentService = treatmentService;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var doctors = _doctorService.TGetDoctorsWithUsersAndTreatments();
            return View(doctors);
        }
        [Route("AddDoctor")]
        [HttpGet]
       
        public IActionResult AddDoctor()
        {
            FillTreatmentList();
            return View(new DoctorAppUserDto());
        }

        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddDoctor(DoctorAppUserDto model)
        {
            FillTreatmentList();

            // Validation
            DoctorAppUserValidator validator = new DoctorAppUserValidator();
            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }

            // Profil resmi işlemi
            string uniqueFileName = null;
            if (model.Image != null)
            {
                var extension = Path.GetExtension(model.Image.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages/", uniqueFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
            }

            // AppUser oluştur
            AppUser newUser = new AppUser
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                ContactNumber = model.ContactNumber,
                ImageUrl = uniqueFileName,
                UserType = EntityLayer.Enums.UserType.Doctor
            };
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("UserName", "Bu TC Kimlik Numarası zaten kayıtlı.");
                return View(model);
            }
            var identityResult = await _userManager.CreateAsync(newUser, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            // Doctor kaydı
            Doctor newDoctor = new Doctor
            {
                AppUserId = newUser.Id,
                Specialization = model.Specialization,
                Description = model.Description,
                Experience = model.Experience,
                Skill = model.Skill,
                Education = model.Education,
                InstagramUrl = model.InstagramUrl,
                TwitterUrl = model.TwitterUrl,
                TreatmentId = model.TreatmentId,
                Status = true
            };

            _doctorService.TAdd(newDoctor);

            // Rol ata (isteğe bağlı)
            await _userManager.AddToRoleAsync(newUser, "Doctor");

            return RedirectToAction("Index");
        }


        private void FillTreatmentList()
        {
            var treatments = _treatmentService.GetList();
            ViewBag.Treatments = treatments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.TreatmentId.ToString()
            }).ToList();
        }
        [HttpGet("UpdateDoctor/{id}")]
        public IActionResult UpdateDoctor(int id)
        {
            var doctor = _doctorService.TGetDoctorWithUser(id);
            if (doctor == null)
                return NotFound();

            var viewModel = new DoctorAppUserViewModel
            {
                UserName = doctor.AppUser.UserName,
                FirstName = doctor.AppUser.FirstName,
                LastName = doctor.AppUser.LastName,
                Email = doctor.AppUser.Email,
                Gender = doctor.AppUser.Gender,
                DateOfBirth = doctor.AppUser.DateOfBirth,
                Address = doctor.AppUser.Address,
                ContactNumber = doctor.AppUser.ContactNumber,

                Specialization = doctor.Specialization,
                Description = doctor.Description,
                Experience = doctor.Experience,
                Skill = doctor.Skill,
                Education = doctor.Education,
                InstagramUrl = doctor.InstagramUrl,
                TwitterUrl = doctor.TwitterUrl,
                TreatmentId = doctor.TreatmentId
            };

            ViewBag.DoctorId = doctor.DoctorId;
            PrepareTreatments();
            return View(viewModel);
        }





        [HttpPost("UpdateDoctor/{id}")]
      
        public async Task<IActionResult> UpdateDoctor(int id, DoctorAppUserViewModel model)
        {
            // Doctor Entity NO TRACKING çekiliyor
            var doctor = _doctorService.TGetDoctorWithUserAsNoTracking(id);
            if (doctor == null)
                return NotFound();

            // AppUser'ı bul
            var user = await _userManager.FindByIdAsync(doctor.AppUserId.ToString());
            if (user == null)
                return NotFound();

            // TC benzersizlik kontrolü
            var existingUserWithSameTC = await _userManager.FindByNameAsync(model.UserName);
            if (existingUserWithSameTC != null && existingUserWithSameTC.Id != user.Id)
            {
                ModelState.AddModelError("UserName", "Bu TC Kimlik Numarası başka bir kullanıcıya ait.");
                PrepareTreatments(); // ViewBag tekrar doldurulmalı
                return View(model);
            }

            // AppUser bilgilerini güncelle
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Gender = model.Gender;
            user.DateOfBirth = model.DateOfBirth;
            user.Address = model.Address;
            user.ContactNumber = model.ContactNumber;

            // Yeni profil resmi yüklendiyse işle
            if (model.Image != null)
            {
                var extension = Path.GetExtension(model.Image.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages/", uniqueFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
                user.ImageUrl = uniqueFileName;
            }

            // 🔐 Yeni şifre verildiyse, ResetPassword kullanarak değiştir
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (!passwordResult.Succeeded)
                {
                    foreach (var error in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", $"Şifre güncellenemedi: {error.Description}");
                    }
                    PrepareTreatments();
                    return View(model);
                }
            }

            // Kullanıcıyı güncelle
            await _userManager.UpdateAsync(user);

            // Doctor bilgilerini güncelle
            doctor.Specialization = model.Specialization;
            doctor.Description = model.Description;
            doctor.Experience = model.Experience;
            doctor.Skill = model.Skill;
            doctor.Education = model.Education;
            doctor.InstagramUrl = model.InstagramUrl;
            doctor.TwitterUrl = model.TwitterUrl;
            doctor.TreatmentId = model.TreatmentId;
            doctor.AppUser = null;

            // EF Tracking problemi için yeniden bağla
            var context = _doctorService.GetContext();
            context.Doctors.Attach(doctor);
            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "Doctor", new { area = "Admin" });
        }




        // Tıbbi birimleri doldur
        private void PrepareTreatments()
        {
            var treatments = _treatmentService.GetList();
            ViewBag.Treatments = treatments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.TreatmentId.ToString()
            }).ToList();
        }


    }

}