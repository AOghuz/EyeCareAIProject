using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _ProcessPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
