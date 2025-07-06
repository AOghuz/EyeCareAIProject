using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    public class AppointmentController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
