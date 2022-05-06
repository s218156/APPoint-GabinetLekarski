using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginDTO>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public LoginHandler(IAuthenticationService authenticationService, ITokenGenerator tokenGenerator, IUserService userService)
        {
            _authenticationService = authenticationService;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
        }

        public async Task<LoginDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = _authenticationService.Login(request.Login, request.Password);

            var token = _tokenGenerator.GenerateToken(user);

            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            await _userService.StoreRefreshToken(user.Id, refreshToken);

            return new LoginDTO() { Token = token, RefreshToken = refreshToken };
        }
    }
}
