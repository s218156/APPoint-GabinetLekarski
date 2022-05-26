namespace APPoint.App.Models.DTO
{
    public class DrugDTO
    {
        public int? Id { get; set; }
        public int Dosage { get; set; }
        public string TimeUnit { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public string Schedule { get; set; } = default!;
    }
}
