using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAppointmentDal : IGenericDal<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByPatientTcAsync(string tc);
        Task<List<Appointment>> GetAppointmentsByDoctorTcAsync(string doctorTc);
        Task<List<Appointment>> GetAllWithIncludesAsync();

    }
}
