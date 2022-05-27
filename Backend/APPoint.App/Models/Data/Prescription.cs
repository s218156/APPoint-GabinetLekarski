using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Leki_Pacjent")]
    public class Prescription
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Ilosc_dawek")]
        public int Dosage { get; set; }
        [Column("Jednostka")]
        public string Unit { get; set; } = default!;
        [Column("Data_przypisania")]
        public DateTime AssignmentDate { get; set; }
        [Column("Uwagi")]
        public string Remarks { get; set; } = default!;
        [Column("Harmonogram")]
        public string Schedule { get; set; } = default!;

        [Column("Pacjent_ID")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        [Column("Wizyta_ID")]
        public int ArchivedAppointmentId { get; set; }
        public ArchivedAppointment ArchivedAppointment { get; set; } = default!;

        [Column("Lek_ID")]
        public int DrugId { get; set; }
        public Drug Drug { get; set; } = default!;
    }
}
