using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Services
{
    public interface ICryptographyService
    {
        public string Hash(string password, string salt);
    }
}
