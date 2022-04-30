using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<AppointmentDTO> GetAppointmentsForOrganization(int id)
        {
            return _appointmentRepository
                .GetAll()
                .Where(a => a.User.OrganizationId == id)
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .Select(a => new AppointmentDTO()
                {
                    Date = a.Date,
                    Length = a.Length,
                    Patient = new PatientDTO()
                    {
                        Name = a.Patient.Name,
                        Surname = a.Patient.Surname,
                        TelephoneNumber = a.Patient.TelephoneNumber
                    },
                    Room = new RoomDTO()
                    {
                        Number = a.Room.Number,
                        Specialization = a.Room.Specialization
                    },
                });
        }

        public IEnumerable<AppointmentDTO> GetAppointmentsForDoctor(int id)
        {
            return _appointmentRepository
                .GetAll()
                .Where(a => a.UserId == id)
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .Select(a => new AppointmentDTO()
                {
                    Date = a.Date,
                    Length = a.Length,
                    Patient = new PatientDTO() 
                    { 
                        Name = a.Patient.Name,
                        Surname = a.Patient.Surname,
                        TelephoneNumber = a.Patient.TelephoneNumber
                    },
                    Room = new RoomDTO()
                    {
                        Number = a.Room.Number,
                        Specialization = a.Room.Specialization
                    },
                });
        }

        public async Task RegisterAppointment(Appointment appointment)
        {
            await _appointmentRepository.AddApointmentAsync(appointment);
        }
    }
}
