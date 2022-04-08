using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;
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

        public LoginHandler(IAuthenticationService authenticationService, ITokenGenerator tokenGenerator)
        {
            _authenticationService = authenticationService;
            _tokenGenerator = tokenGenerator;
        }

        public Task<LoginDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = _authenticationService.Login(request.Login, request.Password);

            var token = _tokenGenerator.GenerateToken(user);

            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            return Task.FromResult(new LoginDTO() { Token = token, RefreshToken = refreshToken });
        }
    }
}
