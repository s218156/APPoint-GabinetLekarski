using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Typy_uzytkownikow")]
    public class UserType
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Typ")]
        public string Type { get; set; } = default!;

        [Column("Opis")]
        public string Description { get; set; } = default!;

        public ICollection<User> Users { get; set; } = default!;
    }
}
