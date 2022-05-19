using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    public class UserLanguageMapping
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Uzytkownik_ID")]
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        [Column("Jezyk_ID")]
        public int LanguageId { get; set; }
        public Language Language { get; set; } = default!;

    }
}
