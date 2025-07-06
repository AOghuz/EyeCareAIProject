using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Doktor.Controllers
{
    [Authorize(Roles = "Doctor")]
    [Area("Doktor")]
    public class AppointmentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDoctorService _doctorService;

        public AppointmentController(UserManager<AppUser> userManager, IDoctorService doctorService)
        {
            _userManager = userManager;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            var doctor = await _doctorService.GetDoctorByAppUserIdAsync(user.Id);
            if (doctor == null) return NotFound("Bu kullanıcıya ait doktor kaydı bulunamadı.");

            var appointments = await _doctorService.GetDoctorAppointmentsAsync(doctor.DoctorId);
            return View(appointments);
        }
    }

}
