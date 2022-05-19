namespace APPoint.App.Models.DTO
{
    public class ArchivedAppointmentDTO
    {
        public DateTime CreationDate { get; set; }

        public DateTime Date { get; set; }

        public int Length { get; set; }

        public bool TookPlace { get; set; }

        public string Remarks { get; set; } = default!;

        public bool WasNecessary { get; set; }

        public bool WasPrescriptionIssued { get; set; }

        public string DoctorName { get; set; } = default!;

        public string RoomNumber { get; set; } = default!;
    }

}
