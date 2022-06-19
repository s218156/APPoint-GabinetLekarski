using System.ComponentModel.DataAnnotations;
using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class PatientRegistrationRequest : IRequest<PatientRegistrationDTO> 
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        [RegularExpression(@"^(\+\d{2})?(\d{9})$", ErrorMessage = "Invalid telephone number")]
        public string TelephoneNumber { get; set; } = default!;
        [RegularExpression(@"^(M|F)$", ErrorMessage = "Invalid sex")]
        public string Sex { get; set; } = default!;
    }
}
