using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetByBlogId(int id)
        {
            return _commentDal.GetListByFilter(x => x.BlogId == id);
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetListCommentByBlogIdWithUser(int blogId)
        {
            return _commentDal.GetListCommentByBlogIdWithUser(blogId);
        }

        public List<Comment> TGetListCommentWithBLog()
        {
            return _commentDal.GetListCommentWithBLog();
        }

        public List<Comment> TGetListCommentWithBlogAndUser()
        {
            return _commentDal.GetListCommentWithBlogAndUser();
        }

        public void TAdd(Comment t)
        {
             _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

       

        
        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
        
    }
}
