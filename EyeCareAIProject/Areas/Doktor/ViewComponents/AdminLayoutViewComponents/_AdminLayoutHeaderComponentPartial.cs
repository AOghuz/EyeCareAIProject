using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Doktor.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
