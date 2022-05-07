using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Dyzury")]
    public class AvailableHours
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data_Start")]
        public DateTime Start { get; set; }

        [Column("Data_Koniec")]
        public DateTime End { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;
    }
}
