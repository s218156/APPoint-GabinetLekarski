using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IAppointmentService
    {
        public Task RegisterAppointment(Appointment appointment);
        public Task<Appointment> RemoveAppointment(int id);
        public Task ArchiveAppointment(ArchivedAppointment archivedAppointment);
        public IEnumerable<AppointmentDTO> GetAppointmentsForDoctor(int id);
        public IEnumerable<AppointmentDTO> GetAppointmentsForOrganization(int id);
        public Task<TermDTO> GetEarliestPossibleTerm(string specialization, int length, string language);
        public IEnumerable<ArchivedAppointmentDTO> GetArchivedAppointmentsByPatientId(int patientId);
    }
}
