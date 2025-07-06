using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{

    public interface IBlogService : IGenericService<Blog>
    {
        /// <summary>
        /// Belirli bir blogu, ilişkili Treatment bilgisiyle birlikte getirir.
        /// </summary>
        Blog TGetBlogWithTreatment(int id);

        /// <summary>
        /// Tüm blogları, ilişkili Treatment bilgisiyle birlikte getirir.
        /// </summary>
        List<Blog> TGetBlogsWithTreatments();
    }

}
