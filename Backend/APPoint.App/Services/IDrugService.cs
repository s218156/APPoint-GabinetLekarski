using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IDrugService
    {
        IEnumerable<Drug> GetAll();
        Task<Drug> AddAsync(Drug drug);
    }
}
