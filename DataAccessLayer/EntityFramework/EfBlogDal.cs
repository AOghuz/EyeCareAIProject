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
public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public Blog GetBlogWithTreatment(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs
                    .Include(b => b.Treatment) // Treatment bilgilerini getir
                    .FirstOrDefault(b => b.BlogId == id);
            }
        }

        public List<Blog> GetBlogsWithTreatments()
        {
            using (var context = new Context())
            {
                return context.Blogs
                    .Include(b => b.Treatment) // Her blog için Treatment bilgisini de getir
                    .ToList();
            }
        }
    }
}
