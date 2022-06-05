using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Pacjenci")]
    public class Patient
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Imie")]
        public string Name { get; set; } = default!;

        [Column("Nazwisko")]
        public string Surname { get; set; } = default!;

        [Column("Nr_tel")]
        public string TelephoneNumber { get; set; } = default!;

        [Column("Organizacja_ID")]
        public int OrganizationID { get; set; } = default!;
        public Organization Organization { get; set; } = default!;

        public ICollection<PatientInfo> PatientInfo { get; set; } = default!;
        public ICollection<Drug> Drugs { get; set; } = default!;

        public List<Prescription> Prescriptions { get; set; } = default!;
    }
}
