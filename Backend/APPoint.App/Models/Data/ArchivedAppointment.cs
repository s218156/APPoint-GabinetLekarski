using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Wizyty_Arch")]
    public class ArchivedAppointment
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_utworzenia")]
        public DateTime CreationDate { get; set; }

        [Column("Data_wizyty")]
        public DateTime Date { get; set; }

        [Column("Czas_trwania")]
        public int Length { get; set; }

        [Column("Czy_sie_odbyla")]
        public bool TookPlace { get; set; }

        [Column("Rezultat")]
        public string Result { get; set; } = default!;

        [Column("Uwagi")]
        public string Remarks { get; set; } = default!;

        [Column("Czy_byla_konieczna")]
        public bool WasNecessary { get; set; }

        [Column("Czy_wystawiono_recepte")]
        public bool WasPrescriptionIssued { get; set; }

        [Column("Pacjent_ID")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        [Column("Lekarz_ID")]
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        [Column("Gabinet_ID")]
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;

        public ArchivedAppointment() { }

        public ArchivedAppointment(Appointment appointment)
        {
            Id = appointment.Id;
            CreationDate = appointment.CreationDate;
            Date = appointment.Date;
            Length = appointment.Length;
            PatientId = appointment.PatientId;
            UserId = appointment.UserId;
            RoomId = appointment.RoomId;
        }
    }
}