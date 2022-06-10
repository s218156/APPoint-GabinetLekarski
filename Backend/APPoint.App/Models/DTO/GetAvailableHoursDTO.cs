using System.Text.Json.Serialization;

namespace APPoint.App.Models.DTO
{
    public class GetAvailableHoursDTO 
    {
        [JsonPropertyName("Monday")]
        public IEnumerable<AvailableHoursDTO> Monday { get; set; } = default!;
        [JsonPropertyName("Tuesday")]
        public IEnumerable<AvailableHoursDTO> Tuesday { get; set; } = default!;
        [JsonPropertyName("Wednesday")]
        public IEnumerable<AvailableHoursDTO> Wednesday { get; set; } = default!;
        [JsonPropertyName("Thursday")]
        public IEnumerable<AvailableHoursDTO> Thursday { get; set; } = default!;
        [JsonPropertyName("Friday")]
        public IEnumerable<AvailableHoursDTO> Friday { get; set; } = default!;
        [JsonPropertyName("Saturday")]
        public IEnumerable<AvailableHoursDTO> Saturday { get; set; } = default!;
    }
}
