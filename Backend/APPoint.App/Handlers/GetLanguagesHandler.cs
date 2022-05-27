using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetLanguagesHandler : IRequestHandler<GetLanguagesRequest, GetLanguagesDTO>
    {
        private readonly ILanguageService _languageService;

        public GetLanguagesHandler(ILanguageService languagesService)
        {
            _languageService = languagesService;
        }

        public Task<GetLanguagesDTO> Handle(GetLanguagesRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetLanguagesDTO(_languageService.GetAll()));
        }
    }
}

