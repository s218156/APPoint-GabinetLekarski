using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IAppointmentService
    {
        public Task RegisterAppointment(Appointment appointment);
        public IEnumerable<AppointmentDTO> GetAppointmentsForUser(int id);
        public IEnumerable<AppointmentDTO> GetAppointmentsForOrganization(int id);
    }
}
