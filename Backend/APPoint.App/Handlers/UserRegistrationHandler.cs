using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class UserRegistrationHandler : IRequestHandler<UserRegistrationRequest, UserRegistrationDTO>
    {
        private readonly IUserService _userService;
        private readonly ILanguageService _languageService;
        private readonly IUserTypeService _userTypeService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRegistrationHandler(
            IUserService userService,
            ILanguageService languageService,
            IUserTypeService userTypeService,
            IHttpContextAccessor httpContextAccessor,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _languageService = languageService;
            _userTypeService = userTypeService;
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserRegistrationDTO> Handle(UserRegistrationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            var user = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Login = request.Login,
                Password = request.Password,
                OrganizationId = organizationId,
                UserType = _userTypeService.GetAll().FirstOrDefault(u => u.Type == request.UserType) ?? throw new ArgumentException("User type not found"),
            };

            if(request.SpecializationId is not null)
            {
                user.SpecializationId = request.SpecializationId;
            }

            if (request.Languages is not null)
            {
                user.Languages = new List<Language>();

                foreach (var languageId in request.Languages)
                {
                    user.Languages.Add(_languageService.GetAll().FirstOrDefault(l => l.Id == languageId) ?? throw new ArgumentException("Language not found"));
                }
            }

            await _authenticationService.Register(user);

            return new UserRegistrationDTO();
        }
    }
}
