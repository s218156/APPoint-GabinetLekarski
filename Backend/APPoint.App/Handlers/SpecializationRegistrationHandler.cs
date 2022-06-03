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
    public class SpecializationRegistrationHandler : IRequestHandler<SpecializationRegistrationRequest, SpecializationRegistrationDTO>
    {
        private readonly ISpecializationService _specializationService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SpecializationRegistrationHandler(ISpecializationService specializationService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _specializationService = specializationService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SpecializationRegistrationDTO> Handle(SpecializationRegistrationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            await _specializationService.AddAsync(new Specialization(){ Name = request.Name });

            return new SpecializationRegistrationDTO();
        }
    }
}
