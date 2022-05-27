using APPoint.App.Models.Data;

namespace APPoint.App.Models.DTO
{
    public class GetSpecializationsDTO : List<Specialization>
    {
        public GetSpecializationsDTO(IEnumerable<Specialization> collection) : base(collection) { }
    }
}
