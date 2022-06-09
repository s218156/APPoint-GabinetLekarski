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
            public const string AvailableHoursAlreadyRegisteredForThatPeriodOfTime = "APPERR4";
        }
        public static class Role
        {
            public const string Administrator = "administator";
            public const string Doctor = "doctor";
            public const string Registrator = "registrator";
        }

        public static class VisitDuration
        {
            public const string SixtyMinutes = "60";
            public const string FortyMinutes = "40";
            public const string TwentyMinutes = "20";
        }

        public static class Sex
        {
            public const string Male = "M";
            public const string Female = "F";
        }
    }
}
