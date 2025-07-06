using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{
    public interface IAppointmentService:IGenericService<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByPatientTcAsync(string tc);
        Task<List<Appointment>> GetAppointmentsByDoctorTcAsync(string doctorTc);
        Task<List<Appointment>> GetAllWithIncludesAsync();

    }
}
