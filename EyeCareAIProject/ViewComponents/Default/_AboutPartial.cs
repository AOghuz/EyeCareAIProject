using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        SubAboutManager _subAboutManager = new SubAboutManager(new EfSubAboutDal());
        
        public IViewComponentResult Invoke()
        {
            var values = _subAboutManager.GetList();

            return View(values);
        }
    }

}
