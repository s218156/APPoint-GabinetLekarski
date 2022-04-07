using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Uzytkownicy")]
    public class User
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Imie")]
        public string Name { get; set; } = default!;

        [Column("Nazwisko")]
        public string Surname { get; set; } = default!;

        [Column("Login")]
        public string Login { get; set; } = default!;

        [Column("Haslo")]
        public string Password { get; set; } = default!;

        [Column("Stanowisko")]
        public string Job { get; set; } = default!;

        [Column("Specjalizacja")]
        public string? Specialization { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; } = default!;

        public ICollection<AvailableHours> AvailableHours { get; set; } = default!;
        public ICollection<Appointment> Appointments { get; set; } = default!;
    }
}
