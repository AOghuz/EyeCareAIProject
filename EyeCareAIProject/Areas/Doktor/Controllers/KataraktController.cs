using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Doktor.Controllers
{
    [Authorize(Roles = "Doctor")]
    [Area("Doktor")]
    public class KataraktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
