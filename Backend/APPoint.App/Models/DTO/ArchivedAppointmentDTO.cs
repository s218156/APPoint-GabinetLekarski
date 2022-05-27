using System.Text.Json.Serialization;
using APPoint.App.Infrastructure.Converters;
using APPoint.App.Models.DTO;

namespace APPoint.App.Models.DTO
{
    public class ArchivedAppointmentDTO
    {
        public string PatientName { get; set; } = default!;
        public string PatientSurname { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public DateTime CreationDate { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Date { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly Time { get; set; }
        public int Length { get; set; }
        public bool TookPlace { get; set; }
        public IEnumerable<PatientInfoDTO> PatientRemarks { get; set; } = default!;
        public string VisitRemarks { get; set; } = default!;
        public bool WasNecessary { get; set; }
        public bool WasPrescriptionIssued { get; set; }
        public string DoctorName { get; set; } = default!;
        public string RoomNumber { get; set; } = default!;
    }

}
