using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentPage = "AboutUs";
            return View();
        }
    }
}
