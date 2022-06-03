using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class DoctorRegistrationRequest : IRequest<DoctorRegistrationDTO>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int SpecializationId { get; set; }
        public string UserType { get; set; } = default!;
        public IEnumerable<int> Languages { get; set; } = default!;
    }
}
