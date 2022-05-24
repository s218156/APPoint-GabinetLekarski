using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IDrugService
    {
        IEnumerable<Drug> GetAll();
    }
}
