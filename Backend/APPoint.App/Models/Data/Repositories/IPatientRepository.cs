using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.Data.Repositories
{
    public interface IPatientRepository
    {
        Task AddPatientAsync(Patient patient);
    }
}
