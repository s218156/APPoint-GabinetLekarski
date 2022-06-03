using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IDrugService
    {
        Task<Drug> AddAsync(Drug drug);
        IEnumerable<Drug> GetAll();
    }
}
