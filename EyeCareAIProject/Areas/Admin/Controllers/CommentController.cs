using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IBlogService _blogService;
        public CommentController(ICommentService commentService, IBlogService blogService)
        {
            _commentService = commentService;
            _blogService = blogService;
        }
        private void PrepareBlogs()
        {
            var blogs = _blogService.GetList();
            ViewBag.Blogs = blogs.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.BlogId.ToString()
            }).ToList();
        }
        public IActionResult Index(int? blogId)
        {
            PrepareBlogs(); // Blog dropdown dolacak

            List<Comment> comments;

            if (blogId.HasValue)
            {
                comments = _commentService.TGetListCommentByBlogIdWithUser(blogId.Value);
            }
            else
            {
                comments = _commentService.TGetListCommentWithBlogAndUser();
            }

            return View(comments);
        }


        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.GetById(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
