using System.ComponentModel.DataAnnotations.Schema;

namespace APPoint.App.Models.Data
{
    [Table("Pacjent-Info")]
    public class PatientInfo
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Wywiad")]
        public string Interview { get; set; } = default!;

        [Column("Pacjent_ID")]
        public int PatientId { get; set; } = default!;
        public Patient Patient { get; set; } = default!;
    }
}
