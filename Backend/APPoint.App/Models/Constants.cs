using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models
{
    public static class Constants
    {
        public static class ErrorCode
        {
            public const string UserNotFound = "APPERR1";
            public const string IncorrectPassword = "APPERR2";
            public const string LoginAlreadyTaken = "APPERR3";
        }
        public static class Role
        {
            public const string Administrator = "administator";
            public const string Doctor = "doctor";
            public const string Registrator = "registrator";
        }
    }
}
