using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using System.Linq;
using BusinnessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogDal());
        private readonly UserManager<AppUser> _userManager;
        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _blogManager.TGetBlogsWithTreatments();
            return View(values);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.i = id;
            ViewBag.blogID = id;

            // Kullanıcı giriş yapmış mı kontrol et
            if (User.Identity.IsAuthenticated)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);

                if (values != null)
                {
                    ViewBag.userID = values.Id;
                    ViewBag.Id = values.Id;
                }
                else
                {
                    ViewBag.userID = "Anonim";
                    ViewBag.Id = 0;
                }
            }
            else
            {
                ViewBag.userID = "Anonim";
                ViewBag.Id = 0;
            }

            var value = _blogManager.TGetBlogWithTreatment(id);

            if (value == null)
            {
                return NotFound();
            }

            // Son 5 blog gönderisini ViewBag'e atıyoruz
            ViewBag.RecentPosts = _blogManager.TGetBlogsWithTreatments()
                .OrderByDescending(b => b.BlogDate)
                .Take(5)
                .ToList();

            return View(value);
        }

    }
}
