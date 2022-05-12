using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IAppointmentService
    {
        public Task RegisterAppointment(Appointment appointment);
        public IEnumerable<AppointmentDTO> GetAppointmentsForDoctor(int id);
        public IEnumerable<AppointmentDTO> GetAppointmentsForOrganization(int id);
        public Task<TermDTO> GetEarliestPossibleTerm(string specialization, int length);
    }
}
