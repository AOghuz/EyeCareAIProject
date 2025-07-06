using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Enums;
using DataAccessLayer.Concrete; // Include için ekledik.

namespace BusinnessLayer.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        private readonly Context _context;

        public DoctorManager(IDoctorDal doctorDal,Context context)
        {
            _doctorDal = doctorDal;
            _context = context;
        }
        public Doctor TGetDoctorWithUserAsNoTracking(int id)
        {
            return _doctorDal.GetDoctorWithUserAsNoTracking(id);
        }
        public Doctor GetById(int id)
        {
            return _doctorDal.GetDoctorWithUser(id);
        }

        public List<Doctor> GetList()
        {
            return _doctorDal.GetDoctorsWithUsers();
        }

        public void TAdd(Doctor t)
        {
            _doctorDal.Insert(t);
        }

        public void TDelete(Doctor t)
        {
            _doctorDal.Delete(t);
        }

        public List<Doctor> TGetDoctorsWithUsers()
        {
            return _doctorDal.GetDoctorsWithUsers();
        }

        public List<Doctor> TGetDoctorsWithUsersAndTreatments()
        {
            return _doctorDal.GetDoctorsWithUsersAndTreatments(); // Yeni metot
        }

        public Doctor TGetDoctorWithUser(int id)
        {
            
          return _doctorDal.GetDoctorWithUser(id);
            
        }

        public void TUpdate(Doctor t)
        {
            _doctorDal.Update(t);
        }
        public Context GetContext()  // Bunu ekle
        {
            return _context;
        }
        public async Task<Doctor> GetDoctorByAppUserIdAsync(int appUserId)
        {
            return await _doctorDal.GetDoctorByAppUserIdAsync(appUserId);
        }

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId)
        {
            return await _doctorDal.GetDoctorAppointmentsAsync(doctorId);
        }
    }
}
