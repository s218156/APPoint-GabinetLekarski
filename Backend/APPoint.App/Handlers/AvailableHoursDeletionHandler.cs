using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class AvailableHoursDeletionHandler : IRequestHandler<AvailableHoursDeletionRequest, AvailableHoursDeletionDTO>
    {
        private readonly IAvailableHoursService _availableHoursService;

        public AvailableHoursDeletionHandler(IAvailableHoursService availableHoursService)
        {
            _availableHoursService = availableHoursService;
        }

        public async Task<AvailableHoursDeletionDTO> Handle(AvailableHoursDeletionRequest request, CancellationToken cancellationToken)
        {
            await _availableHoursService.DeleteAsync(request.Id);

            return new AvailableHoursDeletionDTO();
        }
    }
}
