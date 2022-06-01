namespace APPoint.App.Models.DTO
{
    public class PrescriptionDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Dosage { get; set; }
        public string TimeUnit { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string Schedule { get; set; } = string.Empty;
    }
}
