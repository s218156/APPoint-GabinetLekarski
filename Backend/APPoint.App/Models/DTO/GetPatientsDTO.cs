namespace APPoint.App.Models.DTO
{
    public class GetPatientsDTO : List<PatientDTO>
    {
        public GetPatientsDTO(IEnumerable<PatientDTO> collection) : base(collection) { }
    }
}
