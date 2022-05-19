using System.Linq;

namespace APPoint.App.Models.DTO
{
    public class GetPatientArchivedAppointmentsDTO
    {
        public IEnumerable<ArchivedAppointmentDTO> Appointments { get; set; } = default!;
    }
}
