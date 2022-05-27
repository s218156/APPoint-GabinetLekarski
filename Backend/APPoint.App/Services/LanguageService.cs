using APPoint.App.Models.DTO;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public IEnumerable<LanguageDTO> GetAll()
        {
            return _languageRepository
                .GetAll()
                .Select(l => new LanguageDTO()
                {
                    Id = l.Id,
                    Name = l.Name,
                });
        }
    }
}
