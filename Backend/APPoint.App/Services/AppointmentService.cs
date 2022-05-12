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

        public AppointmentService(IAppointmentRepository appointmentRepository, IAvailableHoursRepository availableHoursRepository)
        {
            _appointmentRepository = appointmentRepository;
            _availableHoursRepository = availableHoursRepository;
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
                .Where(a => a.UserId == id && 
                    a.Date >= DateTime.Today.AddDays((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek) &&
                    a.Date <= DateTime.Today.AddDays((int)DayOfWeek.Sunday - (int)DateTime.Today.DayOfWeek))
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

                    if(!appointments.Any())
                    {
                        return new TermDTO()
                        {
                            Date = hours.Start,
                            Length = length,
                            Room = hours.Room,
                            User = hours.User
                        };
                    }

                    if ((appointments[0].Date - hours.Start).Minutes >= length)
                    {
                        potentialTerms.Add(new TermDTO()
                        {
                            Date = hours.Start,
                            Length = length,
                            Room = hours.Room,
                            User = hours.User
                        });
                    }

                    for (int i = 1; i < appointments.Count; i++)
                    {
                        if ((appointments[i].Date - appointments[i - 1].Date.AddMinutes(appointments[i - 1].Length)).Minutes > length)
                        {
                            potentialTerms.Add(new TermDTO()
                            {
                                Date = appointments[i - 1].Date.AddMinutes(appointments[i - 1].Length),
                                Length = length,
                                Room = hours.Room,
                                User = hours.User
                            });
                        }
                    }

                    if ((hours.End - appointments.Last().Date.AddMinutes(appointments.Last().Length)).Minutes >= length)
                    {
                        potentialTerms.Add(new TermDTO()
                        {
                            Date = appointments.Last().Date.AddMinutes(appointments.Last().Length),
                            Length = length,
                            Room = hours.Room,
                            User = hours.User
                        });
                    }
                }

                currentDay.AddDays(1);
            }
            while (potentialTerms.Count == 0);

            return potentialTerms.MinBy(t => t.Date)!;
        }
    }
}
