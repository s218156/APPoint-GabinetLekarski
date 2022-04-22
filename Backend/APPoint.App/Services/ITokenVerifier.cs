using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Services
{
    public interface ITokenVerifier
    {
        int? Verify(string token);
    }
}
