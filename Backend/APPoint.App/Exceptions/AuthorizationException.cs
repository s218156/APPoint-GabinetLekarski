using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Exceptions
{
    [Serializable]
    internal class AuthorizationException : BusinessException
    {
        public AuthorizationException() { }

        public AuthorizationException(string? message) : base(message) { }

        public AuthorizationException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
