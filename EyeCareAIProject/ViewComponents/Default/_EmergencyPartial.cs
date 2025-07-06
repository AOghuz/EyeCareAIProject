using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _EmergencyPartial:ViewComponent
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = _aboutManager.GetList();

            return View(values);
        }
    }
}
