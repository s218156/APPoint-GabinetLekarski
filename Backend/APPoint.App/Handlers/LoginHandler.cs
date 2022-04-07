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

        public LoginHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task<LoginDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            _authenticationService.Login(request.Login, request.Password);

            return Task.FromResult(new LoginDTO());
        }
    }
}
