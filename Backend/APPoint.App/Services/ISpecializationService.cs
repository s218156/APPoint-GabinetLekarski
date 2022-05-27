using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface ISpecializationService
    {
        IEnumerable<Specialization> GetAll();
    }
}
