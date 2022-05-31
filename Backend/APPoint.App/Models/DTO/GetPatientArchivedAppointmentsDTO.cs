using System.Linq;

namespace APPoint.App.Models.DTO
{
    public class GetPatientArchivedAppointmentsDTO : List<ArchivedAppointmentDTO>
    {
        public GetPatientArchivedAppointmentsDTO(IEnumerable<ArchivedAppointmentDTO> collection) : base(collection) { }
    }
}
