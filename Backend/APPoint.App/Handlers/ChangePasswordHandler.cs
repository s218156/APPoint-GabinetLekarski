using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace APPoint.App.Handlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordDTO>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChangePasswordHandler(IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ChangePasswordDTO> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            await _authenticationService.ChangePassword(int.Parse(userId), request.OldPassword, request.NewPassword);

            return new ChangePasswordDTO();
        }
    }
}