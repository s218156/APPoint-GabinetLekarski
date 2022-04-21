using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.DTO
{
    public class PatientDTO
    {
        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TelephoneNumber { get; set; } = default!;
    }
}
