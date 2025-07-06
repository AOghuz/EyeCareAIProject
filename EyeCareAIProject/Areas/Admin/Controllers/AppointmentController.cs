using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
   
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetByPatientTc(string tc)
        {
            if (string.IsNullOrWhiteSpace(tc) || tc.Length != 11)
                return Json(new List<object>()); // boş döndür

            var list = await _appointmentService.GetAppointmentsByPatientTcAsync(tc);

            var result = list.Select(a => new
            {
                Date = a.AppointmentDate?.ToString("dd.MM.yyyy") ?? "-",
                Time = a.AppointmentTime,
                PatientName = a.AppUser != null ? a.AppUser.FirstName + " " + a.AppUser.LastName : "-",
                PatientTc = a.AppUser?.UserName ?? "-",
                DoctorName = a.Doctor?.AppUser?.FirstName + " " + a.Doctor?.AppUser?.LastName ?? "-",
                DoctorTc = a.Doctor?.AppUser?.UserName ?? "-",
                Treatment = a.Treatment?.Name ?? "-",
                Description = a.Description
            });

            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetByDoctorTc(string doctorTc)
        {
            var list = await _appointmentService.GetAppointmentsByDoctorTcAsync(doctorTc);

            var result = list.Select(a => new
            {
                Date = a.AppointmentDate?.ToString("dd.MM.yyyy"),
                Time = a.AppointmentTime,
                PatientName = a.AppUser?.FirstName + " " + a.AppUser?.LastName,
                PatientTc = a.AppUser?.UserName,
                DoctorName = a.Doctor?.AppUser?.FirstName + " " + a.Doctor?.AppUser?.LastName,
                DoctorTc = a.Doctor?.AppUser?.UserName,
                Treatment = a.Treatment?.Name,
                Description = a.Description
            });

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var list = await _appointmentService.GetAllWithIncludesAsync();

            var result = list.Select(a => new
            {
                Date = a.AppointmentDate?.ToString("dd.MM.yyyy") ?? "-",
                Time = a.AppointmentTime,
                PatientName = a.AppUser.FirstName + " " + a.AppUser.LastName,
                PatientTc = a.AppUser.UserName,
                DoctorName = a.Doctor.AppUser.FirstName + " " + a.Doctor.AppUser.LastName,
                DoctorTc = a.Doctor.AppUser.UserName,
                Treatment = a.Treatment.Name,
                Description = a.Description
            });

            return Json(result);
        }


    }
}
