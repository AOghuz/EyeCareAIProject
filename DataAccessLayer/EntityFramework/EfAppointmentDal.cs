using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppointmentDal : GenericRepository<Appointment>, IAppointmentDal
    {
        public async Task<List<Appointment>> GetAppointmentsByPatientTcAsync(string tc)
        {
            using (var context = new Context())
            {
                return await context.Appointments
                    .Include(a => a.Treatment)
                    .Include(a => a.AppUser)
                    .Include(a => a.Doctor).ThenInclude(d => d.AppUser)
                    .Where(a => a.AppUser.UserName == tc)
                    .OrderBy(a => a.AppointmentDate)
                    .ThenBy(a => a.AppointmentTime)
                    .ToListAsync();
            }
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorTcAsync(string doctorTc)
        {
            using (var context = new Context())
            {
                return await context.Appointments
                    .Include(a => a.Treatment)
                    .Include(a => a.AppUser)
                    .Include(a => a.Doctor).ThenInclude(d => d.AppUser)
                    .Where(a => a.Doctor.AppUser.UserName == doctorTc)
                    .OrderBy(a => a.AppointmentDate)
                    .ThenBy(a => a.AppointmentTime)
                    .ToListAsync();
            }
        }
        public async Task<List<Appointment>> GetAllWithIncludesAsync()
        {
            using (var context = new Context())
            {
                return await context.Appointments
                    .Include(a => a.Treatment)
                    .Include(a => a.AppUser)
                    .Include(a => a.Doctor).ThenInclude(d => d.AppUser)
                    .OrderBy(a => a.AppointmentDate)
                    .ThenBy(a => a.AppointmentTime)
                    .ToListAsync();
            }
        }

    }

}
