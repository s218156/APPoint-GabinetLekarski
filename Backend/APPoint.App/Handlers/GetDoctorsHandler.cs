using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetDoctorsHandler : IRequestHandler<GetDoctorsRequest, GetDoctorsDTO>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetDoctorsHandler(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetDoctorsDTO> Handle(GetDoctorsRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            var doctors = _userService.GetDoctorsByOrganizationId(organizationId).Select(d => new DoctorDTO()
            {
                Id = d.Id,
                Name = d.Name,
                Surname = d.Surname,
                Specialization = d.Specialization.Name
            });

            return Task.FromResult(new GetDoctorsDTO(doctors));
        }
    }
}
