using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    internal class Employee
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Imie")]
        public string Name { get; set; } = default!;

        [Column("Nazwisko")]
        public string Surname { get; set; } = default!;

        [Column("Stanowisko")]
        public string Job { get; set; } = default!;

        [Column("Specjalizacja")]
        public string? Specialization { get; set; }

        public ICollection<AvailableHours> AvailableHours { get; set; } = default!;
        public ICollection<Appointment> Appointments { get; set; } = default!;
    }
}
