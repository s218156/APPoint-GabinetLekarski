using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface ILanguageService
    {
        IEnumerable<LanguageDTO> GetAll();
    }
}
