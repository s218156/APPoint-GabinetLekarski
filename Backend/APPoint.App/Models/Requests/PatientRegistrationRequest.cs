using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class PatientRegistrationRequest : IRequest<PatientRegistrationDTO> 
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string TelephoneNumber { get; set; } = default!;
    }
}
