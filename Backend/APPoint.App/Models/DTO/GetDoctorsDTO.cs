namespace APPoint.App.Models.DTO
{
    public class GetDoctorsDTO : List<DoctorDTO>
    {
        public GetDoctorsDTO(IEnumerable<DoctorDTO> collection) : base(collection) { }
    }
}
