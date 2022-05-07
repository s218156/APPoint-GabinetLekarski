using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace APPoint.App.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenDTO>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public RefreshTokenHandler(ITokenGenerator tokenGenerator, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _tokenGenerator = tokenGenerator;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<RefreshTokenDTO> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var user = _userService.GetById(int.Parse(userId));

            if(request.RefreshToken != user.RefreshToken)
            {
                throw new AuthorizationException();
            }

            var token = _tokenGenerator.GenerateToken(user);
            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            await _userService.StoreRefreshToken(int.Parse(userId), refreshToken);

            return new RefreshTokenDTO() { Token = token, RefreshToken = refreshToken };
        }
    }
}
