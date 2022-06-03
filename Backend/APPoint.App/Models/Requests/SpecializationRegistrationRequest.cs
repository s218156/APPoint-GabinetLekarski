using System.ComponentModel.DataAnnotations;
using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class SpecializationRegistrationRequest : IRequest<SpecializationRegistrationDTO>
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
