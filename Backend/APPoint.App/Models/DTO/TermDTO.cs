using APPoint.App.Models.Data;

namespace APPoint.App.Models.DTO
{
    public class TermDTO
    {
        public DateTime Date { get; set; }

        public int Length { get; set; }

        public User User { get; set; } = default!;

        public Room Room { get; set; } = default!;
    }
}
