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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;
        public TestimonialManager( ITestimonialDal testimoinalDal)
        {
            _testimonialDal = testimoinalDal;

        }
        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetList()
        {
            return _testimonialDal.GetList();
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
