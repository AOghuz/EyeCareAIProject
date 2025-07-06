using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _ServicePartial:ViewComponent
    {
        TreatmentManager _treatmentManager = new TreatmentManager(new EfTreatmentDal());
        public IViewComponentResult Invoke()
        {
            var values = _treatmentManager.GetList();
            return View(values);
        }
    }
}
