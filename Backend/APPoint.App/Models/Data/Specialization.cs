using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Specjalizacje")]
    public class Specialization
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nazwa")]
        public string Name { get; set; } = default!;
    }
}
