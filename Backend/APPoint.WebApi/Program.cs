using System.Reflection;
using APPoint.App.Handlers;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbConnectionString = builder.Configuration.GetConnectionString("APPointDatabase");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<AppointmentRegistrationRequest, AppointmentRegistrationDTO>, AppointmentRegistrationHandler>();
builder.Services.AddTransient<IRequestHandler<LoginRequest, LoginDTO>, LoginHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

