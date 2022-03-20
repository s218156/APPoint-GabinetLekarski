using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    internal class Appointment 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_utworzenia")]
        public DateTime CreationDate { get; set; }

        [Column("Data_wizyty")]
        public DateTime Date { get; set; }

        [Column("Dlugosc_wizyty")]
        public int Length { get; set; }

        public Patient Patient { get; set; } = default!;

        public Employee Employee { get; set; } = default!;

        public Room Room { get; set; } = default!;
    }
}
