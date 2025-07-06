using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using EyeCareAIProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
  
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ITreatmentService _treatmentService;

        public BlogController(IBlogService blogService, ITreatmentService treatmentService)
        {
            _blogService = blogService;
            _treatmentService = treatmentService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.TGetBlogsWithTreatments();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.Treatments = _treatmentService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.TreatmentId.ToString()
                }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(BlogAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string imageUrl = null;

            // Görsel yüklendiyse kaydet
            if (model.ImageFile != null)
            {
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages", newImageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                imageUrl = newImageName;
            }

            Blog newBlog = new Blog
            {
                Title = model.Title,
                LittleDesc = model.LittleDesc,
                BigDesc = model.BigDesc,
                About = model.About,
                BlogDate = DateTime.Now,
                Owner = model.Owner,
                TreatmentId = model.TreatmentId,
                ImageURL = imageUrl
            };

            _blogService.TAdd(newBlog);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.GetById(id);
            _blogService.TDelete(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetBlogWithTreatment(id);
            if (blog == null) return NotFound();

            var model = new BlogAddViewModel
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                LittleDesc = blog.LittleDesc,
                BigDesc = blog.BigDesc,
                About = blog.About,
                Owner = blog.Owner,
                TreatmentId = blog.TreatmentId,
                ExistingImage = blog.ImageURL
            };

            ViewBag.Treatments = _treatmentService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.TreatmentId.ToString()
                }).ToList();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBlog(BlogAddViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var blog = _blogService.GetById(model.BlogId);
            if (blog == null) return NotFound();

            blog.Title = model.Title;
            blog.LittleDesc = model.LittleDesc;
            blog.BigDesc = model.BigDesc;
            blog.About = model.About;
            blog.Owner = model.Owner;
            blog.TreatmentId = model.TreatmentId;

            // Eğer yeni görsel yüklendiyse değiştir
            if (model.ImageFile != null)
            {
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages", imageName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                blog.ImageURL = imageName;
            }
            else
            {
                blog.ImageURL = model.ExistingImage; // görsel değişmediyse eski kalsın
            }

            _blogService.TUpdate(blog);
            return RedirectToAction("Index");
        }

    }
}
