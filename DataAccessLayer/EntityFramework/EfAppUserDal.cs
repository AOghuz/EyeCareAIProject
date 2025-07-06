using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public AppUser GetPatientByIdAsNoTracking(int id)
        {
            using (var context = new Context())
            {
                return context.Users
                    .AsNoTracking()  // TAKİP KAPALI
                    .FirstOrDefault(x => x.Id == id && x.UserType == UserType.Patient); // Yalnızca hastaları getir
            }
        }


    }
}
