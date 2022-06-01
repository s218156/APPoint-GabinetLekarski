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
        private readonly IDrugService _drugService;
        private readonly ILogger<AppointmentArchivizationHandler> _logger;

        public AppointmentArchivizationHandler(IAppointmentService appointmentService, ILogger<AppointmentArchivizationHandler> logger, IDrugService drugService)
        {
            _appointmentService = appointmentService;
            _drugService = drugService;
            _logger = logger;
        }

        public async Task<AppointmentArchivizationDTO> Handle(AppointmentArchivizationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                var appointment = await _appointmentService.RemoveAppointment(request.Id);

                foreach (var medicine in request.Medicine)
                {
                    if (medicine.Id is null)
                    {
                        if(medicine.Name is null)
                        {
                            throw new ArgumentNullException(nameof(medicine.Name), $"Drug without name or id has been supplied");
                        }

                        var drug = await _drugService.AddAsync(new Drug()
                        {
                            Name = medicine.Name
                        });

                        medicine.Id = drug.Id;
                    }
                }

                var archivedAppointment = new ArchivedAppointment(appointment)
                {
                    TookPlace = true,
                    Remarks = request.VisitRemarks,
                    WasNecessary = request.WasNecessary,
                    WasPrescriptionIssued = request.WasPrescriptionIssued
                };

                archivedAppointment.Prescriptions = new List<Prescription>();

                foreach (var medicine in request.Medicine)
                {
                    var prescription = new Prescription()
                    {
                        Dosage = medicine.Dosage,
                        Schedule = medicine.Schedule,
                        Unit = medicine.TimeUnit,
                        Remarks = medicine.Remarks,
                        AssignmentDate = DateTime.Now,
                        PatientId = appointment.PatientId,
                        ArchivedAppointmentId = appointment.Id
                    };

                    if (medicine.Id is null)
                    {
                        throw new ArgumentNullException(nameof(medicine.Id), $"Drug has not been added succesfully");
                    }

                    prescription.Drug = _drugService.GetAll().FirstOrDefault(d => d.Id == medicine.Id) ??
                        throw new ArgumentException($"Drug with Id {medicine.Id} not found"); ;

                    archivedAppointment.Prescriptions.Add(prescription);
                }

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
