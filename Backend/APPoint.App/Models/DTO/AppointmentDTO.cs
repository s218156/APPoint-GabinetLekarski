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
        public string PatientName { get; set; } = string.Empty;
        public string PatientSurname { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomSpecialization { get; set; } = string.Empty;
    }
}
