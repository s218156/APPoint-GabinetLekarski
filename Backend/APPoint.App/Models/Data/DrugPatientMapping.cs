using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Leki_Pacjent")]
    public class DrugPatientMapping
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
        public DateTime Remarks { get; set; }
        [Column("Harmonogram")]
        public string Schedule { get; set; } = default!;

        [Column("Pacjent_ID")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        [Column("Wizyta_ID")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = default!;

        [Column("Lek_ID")]
        public int DrugId { get; set; }
        public Drug Drug { get; set; } = default!;
    }
}
