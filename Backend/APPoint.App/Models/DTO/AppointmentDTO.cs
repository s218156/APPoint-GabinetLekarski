using System.Text.Json.Serialization;
using APPoint.App.Infrastructure.Converters;

namespace APPoint.App.Models.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Date { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly Time { get; set; }
        public int Length { get; set; }
        public string PatientName { get; set; } = default!;
        public string PatientSurname { get; set; } = default!;
        public string TelephoneNumber { get; set; } = default!;
        public string RoomNumber { get; set; } = default!;
        public string RoomSpecialization { get; set; } = default!;
    }
}
