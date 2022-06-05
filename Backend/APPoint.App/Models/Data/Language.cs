using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Jezyki")]
    public class Language
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nazwa")]
        public string Name { get; set; } = default!;

        public ICollection<User> Users { get; set; } = default!;

        public List<UserLanguageMapping> UserLanguageMappings { get; set; } = default!;
    }
}
