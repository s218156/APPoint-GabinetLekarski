using System.Reflection;
using APPoint.App.Handlers;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace APPoint.App.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<AppointmentRegistrationRequest, AppointmentRegistrationDTO>, AppointmentRegistrationHandler>();
            services.AddTransient<IRequestHandler<LoginRequest, LoginDTO>, LoginHandler>();
            services.AddTransient<IRequestHandler<GetAppointmentsForDoctorRequest, GetAppointmentsForUserDTO>, GetAppointmentsForUserHandler>();
            services.AddTransient<IRequestHandler<GetAppointmentsForOrganizationRequest, GetAppointmentsForOrganizationDTO>, GetAppointmentsForOrganizationHandler>();
            services.AddTransient<IRequestHandler<PatientRegistrationRequest, PatientRegistrationDTO>, PatientRegistrationHandler>();

            return services;
        }
    }
}
