using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDoctorDal:IGenericDal<Doctor>
    {
        public Doctor GetDoctorWithUser(int id);
        List<Doctor> GetDoctorsWithUsers();
        List<Doctor> GetDoctorsWithUsersAndTreatments();
        Doctor GetDoctorWithUserAsNoTracking(int id);
        Task<Doctor> GetDoctorByAppUserIdAsync(int appUserId);
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId);


    }
}
