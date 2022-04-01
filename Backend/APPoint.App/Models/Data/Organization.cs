using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Organizacje")]
    public class Organization
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nazwa_organizacji")]
        public string Name { get; set; } = default!;

        [Column("Informacje")]
        public string Information { get; set; } = default!;
    }
}
