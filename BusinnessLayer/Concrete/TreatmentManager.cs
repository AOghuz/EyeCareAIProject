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
    public class TreatmentManager:ITreatmentService
    {
        ITreatmentDal _treatmentDal;
        public TreatmentManager(ITreatmentDal treatmentDal)
        {
            _treatmentDal = treatmentDal;
        }

        public Treatment GetById(int id)
        {
            return _treatmentDal.GetByID(id);
        }

        public List<Treatment> GetList()
        {
            return _treatmentDal.GetList();
        }

        public void TAdd(Treatment t)
        {
            _treatmentDal.Insert(t);
        }

        public void TDelete(Treatment t)
        {
            _treatmentDal.Delete(t);
        }

        public List<Treatment> TGetListWithDoctors()
        {
            return _treatmentDal.GetListWithDoctors();
        }

        public void TUpdate(Treatment t)
        {
            _treatmentDal.Update(t);
        }
    }
}
