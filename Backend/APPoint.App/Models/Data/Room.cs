using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Gabinety")]
    public class Room
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Numer_gabinetu")]
        public string Number { get; set; } = default!;

        [Column("Specjalizacja")]
        public string Specialization { get; set; } = default!;

        public ICollection<AvailableHours> AvailableHours { get; set; } = default!;
        public ICollection<Appointment> Appointments { get; set; } = default!;
    }
}
