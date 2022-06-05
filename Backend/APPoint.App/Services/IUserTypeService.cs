using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IUserTypeService
    {
        IEnumerable<UserType> GetAll();
    }
}
