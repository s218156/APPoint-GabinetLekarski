using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetSpecializationsHandler : IRequestHandler<GetSpecializationsRequest, GetSpecializationsDTO>
    {
        private readonly ISpecializationService _specializationService;

        public GetSpecializationsHandler(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        public Task<GetSpecializationsDTO> Handle(GetSpecializationsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetSpecializationsDTO(_specializationService.GetAll()));
        }
    }
}
