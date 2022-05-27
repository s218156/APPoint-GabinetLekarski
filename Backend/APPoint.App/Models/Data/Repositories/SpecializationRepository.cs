using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.Data.Repositories
{
    internal class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
