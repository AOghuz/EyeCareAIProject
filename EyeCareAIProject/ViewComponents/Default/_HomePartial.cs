using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _HomePartial : ViewComponent
    {
        HomeManager _homeManager = new HomeManager(new EfHomeDal());
        public IViewComponentResult Invoke()
        {
            var values = _homeManager.GetList();
            return View();
        }
    }
}
