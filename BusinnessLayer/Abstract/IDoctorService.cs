using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinnessLayer.Abstract
{
    public interface IDoctorService : IGenericService<Doctor>
    {
        /// <summary>
        /// Belirli bir doktoru, AppUser bilgileriyle birlikte getirir.
        /// </summary>
        Doctor TGetDoctorWithUser(int id);

        /// <summary>
        /// Tüm doktorları AppUser bilgileriyle birlikte getirir.
        /// </summary>
        List<Doctor> TGetDoctorsWithUsers();
        List<Doctor> TGetDoctorsWithUsersAndTreatments(); // Yeni metot
        Context GetContext();  // Bunu ekle
        Doctor TGetDoctorWithUserAsNoTracking(int id);
        Task<Doctor> GetDoctorByAppUserIdAsync(int appUserId);
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId);
    }
}
