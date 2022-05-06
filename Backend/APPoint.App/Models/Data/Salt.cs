using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("salt")]
    public class Salt
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("sol")]
        public string Value { get; set; } = default!;

        [Column("Uzytkownik_ID")]
        public int UserId { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}
