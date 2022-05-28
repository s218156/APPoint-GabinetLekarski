namespace APPoint.App.Models.DTO
{
    public class GetDrugsDTO : List<DrugDTO>
    {
        public GetDrugsDTO(IEnumerable<DrugDTO> collection) : base(collection) { }
    }
}
