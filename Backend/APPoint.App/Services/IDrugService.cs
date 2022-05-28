using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IDrugService
    {
        IEnumerable<DrugDTO> GetAll();
    }
}
