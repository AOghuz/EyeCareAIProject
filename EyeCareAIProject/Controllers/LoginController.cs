using EntityLayer.Concrete;
using EyeCareAIProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Enums;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]

        public IActionResult SignUp()
        {
            return View();
        }
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegister)
        {
            if (string.IsNullOrWhiteSpace(userRegister.Password) || string.IsNullOrWhiteSpace(userRegister.ConfirmPassword))
            {
                ModelState.AddModelError("Password", "Şifre alanı boş bırakılamaz.");
                return View(userRegister);
            }

            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Şifreler eşleşmiyor.");
                return View(userRegister);
            }

            AppUser appUser = new AppUser()
            {
                FirstName = userRegister.Name,
                LastName = userRegister.SurName,
                Gender = userRegister.Gender,
                DateOfBirth = userRegister.DateOfBirth,
                Email = userRegister.Mail,
                UserName = userRegister.TurkishIdentityNumber,
                UserType = UserType.Patient
            };

            var result = await _userManager.CreateAsync(appUser, userRegister.Password);

            if (result.Succeeded)
            {
                // 🔐 OTOMATİK ROLE ATAMA
                await _userManager.AddToRoleAsync(appUser, "Patient");

                return RedirectToAction("SignIn");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    if (item.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError("UserName", "Bu kullanıcı adı zaten alınmış.");
                    }
                }
            }

            return View(userRegister);
        }


        [HttpGet]

        public IActionResult SignIn()
        {
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSigInViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.TurkishIdentityNumber, model.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.TurkishIdentityNumber);
                var roles = await _userManager.GetRolesAsync(user);
                

                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "AdminProfile", new { area = "Admin" });

                if (roles.Contains("Doctor"))
                    return RedirectToAction("Index", "Profile", new { area = "Doktor" });

                if (roles.Contains("Patient"))
                    return RedirectToAction("UpdateProfile", "MyProfile", new { area = "Hasta" });

                return RedirectToAction("Index", "Default"); // fallback
            }

            TempData["Error"] = "Giriş başarısız. Kullanıcı adı veya şifre hatalı.";
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }
        
        


    }
}
