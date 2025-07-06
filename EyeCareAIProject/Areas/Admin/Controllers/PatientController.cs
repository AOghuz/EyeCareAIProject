using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using EyeCareAIProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [AllowAnonymous]

    [Route("Admin/Patient")]
    public class PatientController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public PatientController(IAppUserService appUserService, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _env = env;
        }

        // Hasta Listesi + TC ile filtreleme
        [HttpGet("Index")]
        public IActionResult Index(string? tc)
        {
            var values = _appUserService.GetList()
                .Where(x => x.UserType == EntityLayer.Enums.UserType.Patient)
                .ToList();

            if (!string.IsNullOrEmpty(tc))
            {
                values = values.Where(x => x.UserName == tc).ToList();
            }

            return View(values);
        }

        // Güncelleme Sayfası (GET)
        [HttpGet("UpdatePatient/{id}")]
        public IActionResult UpdatePatient(int id)
        {
            var patient = _appUserService.TGetPatientByIdAsNoTracking(id);
            if (patient == null)
                return NotFound();

            var model = new PatientUpdateDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                ContactNumber = patient.ContactNumber
            };

            ViewBag.PatientId = patient.Id;
            return View(model);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientUpdateDto model)
        {
            var patient = _appUserService.TGetPatientByIdAsNoTracking(id);
            if (patient == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.TurkishIdentityNumber; // ✅ TC kimlik numarası UserName olarak atanıyor
            user.NormalizedUserName = model.TurkishIdentityNumber.ToUpperInvariant(); // ✅ Normalized versiyonu
            user.Gender = model.Gender;
            user.DateOfBirth = model.DateOfBirth;
            user.Address = model.Address;
            user.ContactNumber = model.ContactNumber;

            // Profil resmi yükleme
            if (model.Image != null)
            {
                var ext = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + ext;
                var path = Path.Combine(_env.WebRootPath, "UserImages", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
                user.ImageUrl = fileName;
            }

            // Şifre güncelleme (isteğe bağlı)
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

                if (!passwordResult.Succeeded)
                {
                    ModelState.AddModelError("", string.Join(", ", passwordResult.Errors.Select(x => x.Description)));
                    return View(model);
                }
            }

            await _userManager.UpdateAsync(user);

            // EF tracking işlemleri
            var context = _appUserService.GetContext();
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "Patient", new { area = "Admin" });
        }

    }
}
