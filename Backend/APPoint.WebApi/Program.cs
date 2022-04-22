using APPoint.App.Models.Data;
using APPoint.App.Infrastructure;
using APPoint.App.Middlewares;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Services;
using APPoint.App.Settings;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("APPointSettings"));

var dbConnectionString = builder.Configuration.GetConnectionString("APPointDatabase");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();

builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<ITokenGenerator, TokenGenerator>();
builder.Services.AddTransient<ITokenVerifier, TokenVerifier>();

builder.Services.AddHandlers();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

