using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{
    public interface ICommentService: IGenericService<Comment>
    {
        List<Comment> TGetListCommentWithBLog(); // Blog bilgileriyle tüm yorumları çek
        List<Comment> TGetListCommentWithBlogAndUser(); // Blog + Kullanıcı bilgileriyle tüm yorumları çek
        List<Comment> TGetListCommentByBlogIdWithUser(int blogId);

    }
}
