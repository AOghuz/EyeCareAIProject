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
    public class EfTreatmentDal : GenericRepository<Treatment>, ITreatmentDal
    {
        public List<Treatment> GetListWithDoctors()
        {
            using (var c = new Context())
            {
                return c.Treatments
                    .Include(x => x.Doctors)  // Doktorları Include et
                    .ThenInclude(d => d.AppUser)  // Doktorların AppUser bilgilerini Include et
                    .ToList();
            }
        }
    }
}
