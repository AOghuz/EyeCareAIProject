using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Default
{
    public class _BlogPartial:ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var value = _blogManager.TGetBlogsWithTreatments().TakeLast(3).ToList(); // Yeni: Treatment dahil
            return View(value);
        }
    }
}
