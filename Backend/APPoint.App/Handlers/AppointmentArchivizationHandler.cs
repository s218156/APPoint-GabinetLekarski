using System;
using System.Collections.Generic;
using System.Transactions;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace APPoint.App.Handlers
{
    public class AppointmentArchivizationHandler : IRequestHandler<AppointmentArchivizationRequest, AppointmentArchivizationDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentArchivizationHandler> _logger;

        public AppointmentArchivizationHandler(IAppointmentService appointmentService, ILogger<AppointmentArchivizationHandler> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        public async Task<AppointmentArchivizationDTO> Handle(AppointmentArchivizationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                var appointment = await _appointmentService.RemoveAppointment(request.Id);

                var archivedAppointment = new ArchivedAppointment(appointment)
                {
                    TookPlace = request.TookPlace,
                    Result = request.Result,
                    Remarks = request.Remarks,
                    WasNecessary = request.WasNecessary,
                    WasPrescriptionIssued = request.WasPrescriptionIssued
                };

                await _appointmentService.ArchiveAppointment(archivedAppointment);

                transactionScope.Complete();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while archiving an appointment");

                throw;

            }

            return new AppointmentArchivizationDTO();
        }
    }
}
