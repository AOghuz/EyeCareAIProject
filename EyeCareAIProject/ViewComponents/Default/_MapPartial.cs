using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _MapPartial:ViewComponent
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            // Veritabanından tüm listeyi çekiyoruz (Performans için tek seferde!)
            var values = _aboutManager.GetList();

            // Eğer veritabanında kayıt yoksa default Google Maps embed linkini kullan
            var mapData = values.Select(x => x.MapLocation).FirstOrDefault();
                        

            // Harita URL'sini ViewBag içine kaydediyoruz
            ViewBag.MapUrl = mapData;

            return View(values);
        }
    }
}

