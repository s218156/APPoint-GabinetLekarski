using System.Text.Json.Serialization;
using APPoint.App.Infrastructure.Converters;

namespace APPoint.App.Models.DTO
{
    public class MedicineDTO
    {
        public int Dosage { get; set; }
        public string TimeUnit { get; set; } = default!;
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly PrescriptionDate { get; set; } = default!;
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly PrescriptionTime { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public string Schedule { get; set; } = default!;
    }
}
