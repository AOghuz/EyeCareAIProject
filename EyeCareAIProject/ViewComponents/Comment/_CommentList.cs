using BusinnessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.BlogId == id).Count();
            var values = _commentManager.TGetListCommentByBlogIdWithUser(id);
            return View(values);

        }
    }
}
