using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Abstract;

namespace EyeCareAIProject.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Patient")]
    public class AppointmentsController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppointmentDal _appointmentDal;


        public AppointmentsController(Context context, UserManager<AppUser> userManager,IAppointmentDal appointmentDal)
        {
            _context = context;
            _userManager = userManager;
            _appointmentDal = appointmentDal;
        }

        public IActionResult Index()
        {
            ViewBag.Treatments = GetTreatments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Appointment model)
        {
            Console.WriteLine("---- FORM VERİLERİ ----");
            Console.WriteLine($"AppointmentDate: {model.AppointmentDate}");
            Console.WriteLine($"AppointmentTime: {model.AppointmentTime}");
            Console.WriteLine($"TreatmentId: {model.TreatmentId}");
            Console.WriteLine($"DoctorId: {model.DoctorId}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine("------------------------");

            if (ModelState.IsValid)
            {
                bool isAlreadyTaken = _context.Appointments.Any(a =>
                    a.AppointmentDate == model.AppointmentDate &&
                    a.AppointmentTime == model.AppointmentTime &&
                    a.DoctorId == model.DoctorId);

                if (isAlreadyTaken)
                {
                    ModelState.AddModelError(string.Empty, "Seçilen tarih ve saatte bu doktora ait başka bir randevu mevcut.");
                }
                else
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user != null)
                    {
                        model.AppUserId = user.Id;
                        _context.Appointments.Add(model);
                        await _context.SaveChangesAsync();

                        TempData["Success"] = "Randevu talebiniz başarıyla oluşturuldu.";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Kullanıcı bilgisi alınamadı.");
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ MODELSTATE GEÇERSİZ:");
                foreach (var m in ModelState)
                {
                    foreach (var err in m.Value.Errors)
                    {
                        Console.WriteLine($"- {m.Key}: {err.ErrorMessage}");
                    }
                }
            }

            ViewBag.Treatments = GetTreatments();
            return View(model);
        }

        [HttpGet]
        public JsonResult GetDoctorsByTreatment(int treatmentId)
        {
            var doctors = (from doctor in _context.Doctors
                           join user in _context.Users on doctor.AppUserId equals user.Id
                           where doctor.TreatmentId == treatmentId
                           select new
                           {
                               id = doctor.DoctorId,
                               name = user.FirstName + " " + user.LastName
                           }).ToList();

            return Json(doctors);
        }

        private List<SelectListItem> GetTreatments()
        {
            return _context.Treatments
                .Select(t => new SelectListItem
                {
                    Value = t.TreatmentId.ToString(),
                    Text = t.Name
                }).ToList();
        }
        public async Task<IActionResult> MyAppointments()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Index", "Login");

            var allAppointments = await _appointmentDal.GetAppointmentsByPatientTcAsync(user.UserName);
            var today = DateTime.Today;

            var aktif = allAppointments
                .Where(a => a.AppointmentDate >= today && a.Status != "İptal")
                .ToList();

            var gecmis = allAppointments
                .Where(a => a.AppointmentDate < today || a.Status == "İptal")
                .ToList();

            ViewBag.AktifRandevular = aktif;
            ViewBag.GecmisRandevular = gecmis;

            return View();
        }


    }

}
