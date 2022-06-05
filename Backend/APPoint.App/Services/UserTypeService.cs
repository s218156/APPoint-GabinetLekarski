using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public IEnumerable<UserType> GetAll() => _userTypeRepository.GetAll();
    }
}
