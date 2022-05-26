using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.Data.Repositories
{
    internal class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
