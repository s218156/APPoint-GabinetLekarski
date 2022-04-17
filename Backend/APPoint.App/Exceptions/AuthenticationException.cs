using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Exceptions
{
    [Serializable]
    public class AuthenticationException : BusinessException
    {
        public AuthenticationException() { }

        public AuthenticationException(string? message) : base(message) { }

        public AuthenticationException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
