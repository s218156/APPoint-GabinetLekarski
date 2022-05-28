using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetPatientsHandler : IRequestHandler<GetPatientsRequest, GetPatientsDTO>
    {
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetPatientsHandler(IPatientService patientService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _patientService = patientService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public Task<GetPatientsDTO> Handle(GetPatientsRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            return Task.FromResult(new GetPatientsDTO( _patientService.GetPatientsByOrganizationId(organizationId)));       
        }
    }
}
