namespace APPoint.App.Models.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string TelephoneNumber { get; set; } = default!;
    }
}
