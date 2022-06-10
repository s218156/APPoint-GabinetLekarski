using System.Text.Json.Serialization;
using APPoint.App.Infrastructure.Converters;

namespace APPoint.App.Models.DTO
{
    public class AvailableHoursDTO
    {
        public string DoctorName { get; set; } = string.Empty;
        public string DoctorSurname { get; set; } = string.Empty;
        public DateTime ShiftStart { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly ShiftEnd { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
    }
}
