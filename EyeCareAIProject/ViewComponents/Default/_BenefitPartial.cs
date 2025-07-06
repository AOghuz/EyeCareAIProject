using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _BenefitPartial:ViewComponent
    {
        BenefitManager _benefitManager = new BenefitManager(new EfBenefitDal());
        public IViewComponentResult Invoke()
        {
            var values = _benefitManager.GetList();
            return View(values);
        }
    }
}
