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
    public class HomeStatisticManager : IHomeStatisticService
    {
        IHomeStatisticDal _homeStatisticDal;
        public HomeStatisticManager(IHomeStatisticDal homeStatisticDal)
        {
            _homeStatisticDal = homeStatisticDal;
        }
        public HomeStatistic GetById(int id)
        {
            return _homeStatisticDal.GetByID(id);
        }

        public List<HomeStatistic> GetList()
        {
           return _homeStatisticDal.GetList();
        }

        public void TAdd(HomeStatistic t)
        {
            _homeStatisticDal.Insert(t);
        }

        public void TDelete(HomeStatistic t)
        {
            _homeStatisticDal.Delete(t);
        }

        public void TUpdate(HomeStatistic t)
        {
            _homeStatisticDal.Update(t);
        }
    }
}
