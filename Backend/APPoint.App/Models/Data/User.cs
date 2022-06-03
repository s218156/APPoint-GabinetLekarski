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

        [Column("refreshtoken")]
        public string? RefreshToken { get; set; }

        [Column("Organizacja_ID")]
        public int OrganizationId { get; set; } = default!;
        public Organization Organization { get; set; } = default!;

        [Column("Specjalizacja_ID")]
        public int? SpecializationId { get; set; }
        public Specialization Specialization { get; set; } = default!;

        [Column("Typ_ID")]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; } = default!;

        public ICollection<AvailableHours> AvailableHours { get; set; } = default!;
        public ICollection<Appointment> Appointments { get; set; } = default!;
        public ICollection<Language> Languages { get; set; } = default!;
    }
}
