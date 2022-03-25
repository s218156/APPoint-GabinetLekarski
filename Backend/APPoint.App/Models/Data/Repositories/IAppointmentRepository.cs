using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Infrastructure;

namespace APPoint.App.Models.Data.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task AddApointmentAsync(Appointment appointment);
    }
}
