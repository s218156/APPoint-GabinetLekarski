using System.Text.Json.Serialization;


namespace APPoint.App.Models.DTO
{
    public class GetAppointmentsDTO
    {
        [JsonPropertyName("Monday")]
        public IEnumerable<AppointmentDTO> Monday { get; set; } = default!;
        [JsonPropertyName("Tuesday")]
        public IEnumerable<AppointmentDTO> Tuesday { get; set; } = default!;
        [JsonPropertyName("Wednesday")]
        public IEnumerable<AppointmentDTO> Wednesday { get; set; } = default!;
        [JsonPropertyName("Thursday")]
        public IEnumerable<AppointmentDTO> Thursday { get; set; } = default!;
        [JsonPropertyName("Friday")]
        public IEnumerable<AppointmentDTO> Friday { get; set; } = default!;
        [JsonPropertyName("Saturday")]
        public IEnumerable<AppointmentDTO> Saturday { get; set; } = default!;
        [JsonPropertyName("Sunday")]
        public IEnumerable<AppointmentDTO> Sunday { get; set; } = default!;
    }
}
