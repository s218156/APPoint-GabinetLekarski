namespace APPoint.App.Models.DTO
{
    public class GetPatientAppointmentsDTO : List<AppointmentDTO>
    {
        public GetPatientAppointmentsDTO(IEnumerable<AppointmentDTO> collection) : base(collection) { }
    }
}
