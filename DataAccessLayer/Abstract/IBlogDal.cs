using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        /// <summary>
        /// Belirli bir blogu, ilişkili Treatment bilgisiyle birlikte getirir.
        /// </summary>
        Blog GetBlogWithTreatment(int id);

        /// <summary>
        /// Tüm blogları, ilişkili Treatment bilgisiyle birlikte getirir.
        /// </summary>
        List<Blog> GetBlogsWithTreatments();
    }
}