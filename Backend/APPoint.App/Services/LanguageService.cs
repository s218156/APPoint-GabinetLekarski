using APPoint.App.Models.Data;
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

        public IEnumerable<Language> GetAll() => _languageRepository.GetAll();
    }
}
