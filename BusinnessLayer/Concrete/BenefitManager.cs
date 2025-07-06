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
    public class BenefitManager : IBenefitService
    {
        IBenefitDal _benefitDal;
        public BenefitManager(IBenefitDal benefitDal)
        {

            _benefitDal = benefitDal;
        }
        public Benefit GetById(int id)
        {
            return _benefitDal.GetByID(id);
        }

        public List<Benefit> GetList()
        {
            return _benefitDal.GetList();
        }

        public void TAdd(Benefit t)
        {
            _benefitDal.Insert(t);
        }

        public void TDelete(Benefit t)
        {
            _benefitDal.Delete(t);
        }

        public void TUpdate(Benefit t)
        {
            _benefitDal.Update(t);
        }
    }
}
