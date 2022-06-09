namespace APPoint.App.Models.DTO
{
    public class GetMonthlyStatisticsDTO
    {
        public int Visits { get; set; }
        public int PrescriptionsIssued { get; set; }
        public SexStatisticDTO Sex { get; set; } = default!;
        public Dictionary<string, int> BestMedicines { get; set; } = default!;
        public Dictionary<string, int> Durations { get; set; } = default!;
    }
}
