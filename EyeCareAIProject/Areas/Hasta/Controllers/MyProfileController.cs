using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace EyeCareAIProject.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Patient")]
    public class MyProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public MyProfileController(UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            ModelState.Clear();
            return View(user);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(AppUser updatedUser, IFormFile Image)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            user.Email = updatedUser.Email;
            user.Address = updatedUser.Address;
            user.ContactNumber = updatedUser.ContactNumber;

            // FOTOĞRAF YÜKLEME
            if (Image != null && Image.Length > 0)
            {
                var ext = Path.GetExtension(Image.FileName);
                var fileName = Guid.NewGuid() + ext;
                var path = Path.Combine(_env.WebRootPath, "UserImages", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                user.ImageUrl = fileName;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Message"] = "Profil güncellendi.";
                return RedirectToAction("UpdateProfile");
            }

            return View(updatedUser);
        }
    }
}