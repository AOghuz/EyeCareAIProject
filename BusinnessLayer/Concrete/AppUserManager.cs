using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Concrete
{
    public class AppUserManager : IAppUserService
        
    {
        IAppUserDal _patientDal;
        private readonly Context _context;
        public AppUserManager(IAppUserDal patientDal, Context context)
        {
            _patientDal = patientDal;
            _context = context;
        }
        public AppUser GetById(int id)
        {
            return _patientDal.GetByID(id);
        }

        public List<AppUser> GetList()
        {
            return _patientDal.GetList();
        }

        public void TAdd(AppUser t)
        {
            _patientDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _patientDal.Delete(t);
        }

        public void TUpdate(AppUser t)
        {
            _patientDal.Update(t);
        }
        public AppUser TGetPatientByIdAsNoTracking(int id)
        {
            return _patientDal.GetPatientByIdAsNoTracking(id);
        }
        public Context GetContext()  // Bunu ekle
        {
            return _context;
        }
    }
}
