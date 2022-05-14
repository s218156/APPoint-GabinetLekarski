using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAvailableHoursRepository _availableHoursRepository;
        private readonly IArchivedAppointmentRepository _archivedAppointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IAvailableHoursRepository availableHoursRepository, IArchivedAppointmentRepository archivedAppointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _availableHoursRepository = availableHoursRepository;
            _archivedAppointmentRepository = archivedAppointmentRepository;
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
                    Id = a.Id,
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
                .Where(a => a.UserId == id && 
                    a.Date >= DateTime.Today.AddDays((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek) &&
                    a.Date <= DateTime.Today.AddDays((int)DayOfWeek.Sunday - (int)DateTime.Today.DayOfWeek))
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .Select(a => new AppointmentDTO()
                {
                    Id = a.Id,
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
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task<TermDTO> GetEarliestPossibleTerm(string specialization, int length)
        {
            var potentialTerms = new List<TermDTO>();

            var availableHours = await _availableHoursRepository.GetAvailableHoursBySpecialization(specialization);

            if(!availableHours.Any())
            {
                throw new ArgumentException("Specialization not found", nameof(specialization));
            }

            var currentDay = DateTime.Now;

            do
            {
                foreach (var hours in availableHours.Where(a => a.Start.Day == currentDay.Day))
                {
                    var appointments = _appointmentRepository
                        .GetAll()
                        .Where(a => a.UserId == hours.UserId &&
                            a.Date > hours.Start &&
                            a.Date < hours.End)
                        .OrderBy(a => a.Date)
                        .ToList();

                    // Return an appointment starting at the same time as available hours if there are no registered appointments
                    if (!appointments.Any())
                    {
                        return new TermDTO()
                        {
                            Date = hours.Start,
                            Length = length,
                            Room = hours.Room,
                            User = hours.User
                        };
                    }

                    potentialTerms.AddRange(ComputePossibleTerms(hours, appointments, length));
                }

                currentDay.AddDays(1);
            }
            while (potentialTerms.Count == 0);

            return potentialTerms.MinBy(t => t.Date)!;
        }

        public async Task<Appointment> RemoveAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAll().FirstOrDefaultAsync(a => a.Id == id);

            if(appointment is null)
            {
                throw new InvalidOperationException("Appointment to be deleted not found");
            }

            await _appointmentRepository.DeleteAsync(appointment);

            return appointment;
        }

        public async Task ArchiveAppointment(ArchivedAppointment archivedAppointment)
        {
            await _archivedAppointmentRepository.AddAsync(archivedAppointment);
        }

        private static IEnumerable<TermDTO> ComputePossibleTerms(AvailableHours hours, List<Appointment> existingAppointments, int length)
        {
            var possibleTerms = new List<TermDTO>();

            // Check term between the start of available hours and the first registered appointment
            if ((existingAppointments[0].Date - hours.Start).Minutes >= length)
            {
                possibleTerms.Add(new TermDTO()
                {
                    Date = hours.Start,
                    Length = length,
                    Room = hours.Room,
                    User = hours.User
                });
            }

            // Check terms between appointments
            for (int i = 1; i < existingAppointments.Count; i++)
            {
                if ((existingAppointments[i].Date - existingAppointments[i - 1].Date).Minutes - existingAppointments[i - 1].Length >= length)
                {
                    possibleTerms.Add(new TermDTO()
                    {
                        Date = existingAppointments[i - 1].Date.AddMinutes(existingAppointments[i - 1].Length),
                        Length = length,
                        Room = hours.Room,
                        User = hours.User
                    });
                }
            }

            // Check term between the last registered appointment and the end of available hours
            if ((hours.End - existingAppointments.Last().Date).Minutes - existingAppointments.Last().Length >= length)
            {
                possibleTerms.Add(new TermDTO()
                {
                    Date = existingAppointments.Last().Date.AddMinutes(existingAppointments.Last().Length),
                    Length = length,
                    Room = hours.Room,
                    User = hours.User
                });
            }

            return possibleTerms;
        }
    }
}
