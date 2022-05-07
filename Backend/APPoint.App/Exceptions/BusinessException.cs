using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Exceptions
{
    [Serializable]
    internal class BusinessException : Exception
    {
        public string ErrorCode { get; init; } = default!;

        public BusinessException() { }

        public BusinessException(string? message) : base(message) { }

        public BusinessException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
