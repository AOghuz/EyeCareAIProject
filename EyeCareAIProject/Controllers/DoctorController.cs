using BusinnessLayer.Abstract;
using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;

        }
        public IActionResult Index()
        {
            var values = _doctorService.TGetDoctorsWithUsersAndTreatments();

            return View(values);
        }
        public IActionResult Details(int id)
        {
            var value = _doctorService.GetById(id);
            return View(value);
        }
    }
}
