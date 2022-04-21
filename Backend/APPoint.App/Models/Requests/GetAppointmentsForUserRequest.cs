using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class GetAppointmentsForUserRequest : IRequest<GetAppointmentsForUserDTO>
    {
        public int UserId { get; set; }
    }
}
