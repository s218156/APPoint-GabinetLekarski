using APPoint.App.Services;
using APPoint.App.Models.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace APPoint.App.Middlewares
{
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserRepository _userRepository;
        private readonly ITokenVerifier _tokenVerifier;

        public IdentityMiddleware(RequestDelegate next, IUserRepository userRepository, ITokenVerifier tokenVerifier)
        {
            _next = next;
            _userRepository = userRepository;
            _tokenVerifier = tokenVerifier;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userId = _tokenVerifier.Verify(token);

                if (userId != null)
                {
                    var user = _userRepository.GetById(userId.Value);

                    if (user != null)
                    {
                        context.Items["User"] = user;
                    }
                }
            }

            await _next(context);
        }
    }
}
