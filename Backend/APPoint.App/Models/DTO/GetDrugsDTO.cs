using APPoint.App.Models.Data;

namespace APPoint.App.Models.DTO
{
    public class GetDrugsDTO
    {
        public IEnumerable<Drug> Drugs { get; set; } = default!;
    }
}
