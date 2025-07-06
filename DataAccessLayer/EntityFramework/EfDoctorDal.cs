using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDoctorDal : GenericRepository<Doctor>, IDoctorDal
    {
        public Doctor GetDoctorWithUser(int id)
        {
            using (var context = new Context())
            {
                return context.Doctors
                    .Include(d => d.AppUser) // AppUser bilgilerini getiriyoruz
                    .FirstOrDefault(d => d.DoctorId == id && d.AppUser.UserType == UserType.Doctor);
            }
        }
        public Doctor GetDoctorWithUserAsNoTracking(int id)
        {
            using (var context = new Context())
            {
                return context.Doctors
                    .Include(x => x.AppUser)
                    .AsNoTracking()  // TAKİP KAPALI
                    .FirstOrDefault(x => x.DoctorId == id);
            }
        }


        public List<Doctor> GetDoctorsWithUsers()
        {
            using (var context = new Context())
            {
                return context.Doctors
                    .Include(d => d.AppUser) // AppUser bilgileriyle birlikte getir
                    .Where(d => d.AppUser.UserType == UserType.Doctor) // Sadece doktorları al
                    .ToList();
            }
        }

        public List<Doctor> GetDoctorsWithUsersAndTreatments()
        {
            using (var context = new Context())
            {
                return context.Doctors
                    .Include(d => d.AppUser)   // AppUser bilgileriyle birlikte getir
                    .Include(d => d.Treatment) // Doktorun bağlı olduğu tıbbi birimi getir
                    .Where(d => d.AppUser.UserType == UserType.Doctor) // Sadece doktorları çek
                    .ToList();
            }
        }
        public async Task<Doctor> GetDoctorByAppUserIdAsync(int appUserId)
        {
            using (var context = new Context())
            {
                return await context.Doctors.FirstOrDefaultAsync(d => d.AppUserId == appUserId);
            }
        }

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId)
        {
            using (var context = new Context())
            {
                return await context.Appointments
                .Include(a => a.Treatment)
                .Include(a => a.AppUser)
                .Where(a => a.DoctorId == doctorId)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.AppointmentTime)
                .ToListAsync();
            }
        }

    }

}
    

