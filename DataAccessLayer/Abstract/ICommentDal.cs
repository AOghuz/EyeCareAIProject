using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetListCommentWithBLog(); // Blog bilgileriyle tüm yorumları çek
        List<Comment> GetListCommentWithBlogAndUser(); // Blog + Kullanıcı bilgileriyle tüm yorumları çek
        List<Comment> GetListCommentByBlogIdWithUser(int blogId); // Sadece belirli BlogId'ye ait yorumları çek
    }

}
