using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
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
    }
}
