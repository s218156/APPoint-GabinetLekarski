using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class ChangePasswordRequest : IRequest<ChangePasswordDTO>
    {
        public string OldPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!; 
    }
}
