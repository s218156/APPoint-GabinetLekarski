using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    internal class AvailableHours
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_Start")]
        public DateTime Start { get; set; }

        [Column("Data_Koniec")]
        public DateTime End { get; set; }

        public Employee Employee { get; set; } = default!;

        public Room Room { get; set; } = default!;
    }
}
