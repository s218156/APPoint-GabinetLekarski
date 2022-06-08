namespace APPoint.App.Models.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Specialization { get; set; } = default!;
    }
}
