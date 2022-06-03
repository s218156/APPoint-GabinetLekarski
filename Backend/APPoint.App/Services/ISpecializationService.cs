using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface ISpecializationService
    {
        Task<Specialization> AddAsync(Specialization specialization);
        IEnumerable<Specialization> GetAll();
    }
}
