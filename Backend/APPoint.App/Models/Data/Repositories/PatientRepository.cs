using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task AddPatientAsync(Patient patient)
        {
            await AddAsync(patient);
        }
    }
}
