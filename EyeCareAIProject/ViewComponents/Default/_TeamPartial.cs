using BusinnessLayer.Abstract;
using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{

    public class _TeamPartial:ViewComponent
    {
        private readonly IDoctorService _doctorService;
        public _TeamPartial(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _doctorService.TGetDoctorsWithUsersAndTreatments().TakeLast(3).ToList();
            return View(values);
        }
    }
}
