using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Leki")]
    public class Drug
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nazwa")]
        public string Name { get; set; } = default!;
    }
}
