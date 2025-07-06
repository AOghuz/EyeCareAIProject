using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
