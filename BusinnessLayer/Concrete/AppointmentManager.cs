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
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public Appointment GetById(int id)
        {
            return _appointmentDal.GetByID(id);
        }

        public List<Appointment> GetList()
        {
            return _appointmentDal.GetList();
        }

        public void TAdd(Appointment t)
        {
            _appointmentDal.Insert(t);
        }

        public void TDelete(Appointment t)
        {
            _appointmentDal.Delete(t);
        }

        public void TUpdate(Appointment t)
        {
            _appointmentDal.Update(t);
        }
        public async Task<List<Appointment>> GetAppointmentsByPatientTcAsync(string tc)
        {
            return await _appointmentDal.GetAppointmentsByPatientTcAsync(tc);
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorTcAsync(string doctorTc)
        {
            return await _appointmentDal.GetAppointmentsByDoctorTcAsync(doctorTc);
        }
        public async Task<List<Appointment>> GetAllWithIncludesAsync()
        {
            return await _appointmentDal.GetAllWithIncludesAsync();
        }

    }
}
