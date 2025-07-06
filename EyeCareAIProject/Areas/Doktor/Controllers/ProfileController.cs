using EntityLayer.Concrete;
using EyeCareAIProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doctor")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("SignIn", "Login");

            var model = new DoctorProfileViewModel
            {
                Email = user.Email,
                ContactNumber = user.ContactNumber,
                
                // diğer alanları istersen ekleyebiliriz
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(DoctorProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("SignIn", "Login");

            if (!ModelState.IsValid)
                return View(model);

            // 1. Profil bilgileri güncelleme
            user.Email = model.Email;
            user.ContactNumber = model.ContactNumber;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                ViewBag.ModalTitle = "Profil Güncelleme Hatası";
                ViewBag.ModalContent = string.Join("<br>", updateResult.Errors.Select(e => e.Description));
                ViewBag.ShowModal = true;
                return View(model);
            }

            // 2. Şifre güncelleme (isteğe bağlı)
            if (!string.IsNullOrWhiteSpace(model.CurrentPassword) &&
                !string.IsNullOrWhiteSpace(model.NewPassword) &&
                !string.IsNullOrWhiteSpace(model.ConfirmPassword))
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Yeni şifreler uyuşmuyor.");
                    ViewBag.ModalTitle = "Şifre Güncelleme Hatası";
                    ViewBag.ModalContent = "Yeni şifre ile tekrar edilen şifre uyuşmuyor.";
                    ViewBag.ShowModal = true;
                    return View(model);
                }

                var checkPassword = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
                if (!checkPassword)
                {
                    ModelState.AddModelError("CurrentPassword", "Mevcut şifre hatalı.");
                    ViewBag.ModalTitle = "Şifre Güncelleme Hatası";
                    ViewBag.ModalContent = "Mevcut şifreniz hatalı.";
                    ViewBag.ShowModal = true;
                    return View(model);
                }

                var passwordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordResult.Succeeded)
                {
                    foreach (var error in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    ViewBag.ModalTitle = "Şifre Güncelleme Hatası";
                    ViewBag.ModalContent = string.Join("<br>", passwordResult.Errors.Select(e => e.Description));
                    ViewBag.ShowModal = true;
                    return View(model);
                }

                ViewBag.ModalTitle = "Şifre Güncellendi";
                ViewBag.ModalContent = "Şifreniz başarıyla güncellendi.";
                ViewBag.ShowModal = true;
                return View(model);
            }

            // Şifre değişmemişse ama diğer bilgiler güncellendiyse
            ViewBag.ModalTitle = "Bilgiler Güncellendi";
            ViewBag.ModalContent = "Profil bilgileriniz başarıyla güncellendi.";
            ViewBag.ShowModal = true;
            return View(model);
        }

    }

}

