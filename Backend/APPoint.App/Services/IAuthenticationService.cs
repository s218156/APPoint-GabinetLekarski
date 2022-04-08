using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IAuthenticationService
    {
        public User Login(string login, string password);
    }
}
