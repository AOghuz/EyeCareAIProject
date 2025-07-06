using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _TreatmentCategoryPartial:ViewComponent
    {
        TreatmentManager _treatmentManager = new TreatmentManager(new EfTreatmentDal());
        public IViewComponentResult Invoke()
        {
            var values = _treatmentManager.GetList();
            return View(values);
        }
    }
}
