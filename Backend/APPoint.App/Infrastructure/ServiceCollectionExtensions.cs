using System.Reflection;
using System.Text;
using APPoint.App.Handlers;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddTransient<IRequestHandler<GetAppointmentsForDoctorRequest, GetAppointmentsDTO>, GetAppointmentsForDoctorHandler>();
            services.AddTransient<IRequestHandler<GetAppointmentsForOrganizationRequest, GetAppointmentsDTO>, GetAppointmentsForOrganizationHandler>();
            services.AddTransient<IRequestHandler<PatientRegistrationRequest, PatientRegistrationDTO>, PatientRegistrationHandler>();
            services.AddTransient<IRequestHandler<AppointmentDeletionRequest, AppointmentDeletionDTO>, AppointmentDeletionHandler>();
            services.AddTransient<IRequestHandler<GetPatientArchivedAppointmentsRequest, GetPatientArchivedAppointmentsDTO>, GetPatientArchivedAppointmentsHandler>();
            services.AddTransient<IRequestHandler<GetDrugsRequest, GetDrugsDTO>, GetDrugsHandler>();
            services.AddTransient<IRequestHandler<GetLanguagesRequest, GetLanguagesDTO>, GetLanguagesHandler>();
            services.AddTransient<IRequestHandler<GetEarliestPossibleTermRequest, GetEarliestPossibleTermDTO>, GetEarliestPossibleTermHandler>();
            services.AddTransient<IRequestHandler<GetPossibleTermsRequest, GetPossibleTermsDTO>, GetPossibleTermsHandler>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<ICryptographyService, CryptographyService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ISpecializationService, SpecializationService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IUserTypeService, UserTypeService>();
            services.AddTransient<IAvailableHoursService, AvailableHoursService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<ISaltRepository, SaltRepository>();
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<IAvailableHoursRepository, AvailableHoursRepository>();
            services.AddTransient<IArchivedAppointmentRepository, ArchivedAppointmentRepository>();
            services.AddTransient<IDrugRepository, DrugRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserTypeRepository, UserTypeRepository>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = configuration.GetValue<string>("APPointSettings:Audience"),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("APPointSettings:Secret"))),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetValue<string>("APPointSettings:Issuer"),
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                };
            });

            return services;
        }
    }
}
