namespace APPoint.App.Models.DTO
{
    public class GetEarliestPossibleTermDTO
    {
        public DateTime Date { get; set; }

        public string DoctorName { get; set; } = string.Empty;
        public int DoctorId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;
        public int RoomId { get; set; }
    }
}
