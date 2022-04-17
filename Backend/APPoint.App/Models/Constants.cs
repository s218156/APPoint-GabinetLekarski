using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models
{
    internal static class Constants
    {
        internal const string Issuer = "Appoint";

        internal static class ErrorCode
        {
            internal const string UserNotFound = "APPERR1";
            internal const string IncorrectPassword = "APPERR2";
        }
    }
}
