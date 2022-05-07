using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Wizyty")]
    public class Appointment 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_utworzenia")]
        public DateTime CreationDate { get; set; }

        [Column("Data_wizyty")]
        public DateTime Date { get; set; }

        [Column("Czas_trwania")]
        public int Length { get; set; }

        [Column("Pacjent_ID")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        [Column("Uzytkownik_ID")]
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        [Column("Gabinet_ID")]
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;
    }
}
