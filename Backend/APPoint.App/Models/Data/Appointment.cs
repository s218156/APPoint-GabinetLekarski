using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    public class Appointment 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_utworzenia")]
        public DateTime CreationDate { get; set; }

        [Column("Data_wizyty")]
        public DateTime Date { get; set; }

        [Column("Dlugosc_wizyty")]
        public int Length { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;
    }
}
