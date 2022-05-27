namespace APPoint.App.Models.DTO
{
    public class GetLanguagesDTO : List<LanguageDTO>
    {
        public GetLanguagesDTO(IEnumerable<LanguageDTO> collection) : base(collection) { } 
    }
}
