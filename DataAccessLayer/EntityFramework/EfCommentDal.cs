using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        // Tüm yorumları blog bilgisiyle getir
        public List<Comment> GetListCommentWithBLog()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Blog).ToList();
            }
        }

        // Sadece belirli bir BlogId'ye ait yorumları getir (Blog + Kullanıcı bilgisiyle)
        public List<Comment> GetListCommentByBlogIdWithUser(int blogId)
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Where(x => x.BlogId == blogId)  // Sadece belirli BlogId'ye ait yorumları çek
                    .Include(x => x.AppUser)         // Kullanıcı bilgilerini dahil et
                    .Include(x => x.Blog)            // Blog bilgilerini de al
                    .ToList();
            }
        }

        // Tüm yorumları kullanıcı ve blog bilgisiyle getir
        public List<Comment> GetListCommentWithBlogAndUser()
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Include(x => x.Blog)    // Blog bilgilerini çek
                    .Include(x => x.AppUser) // Kullanıcı bilgilerini çek
                    .ToList();
            }
        }
    }

}
