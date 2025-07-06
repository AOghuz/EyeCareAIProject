using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class TestimonialController : Controller
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = _testimonialManager.GetList();
            return View(values);
        }
    }
}
