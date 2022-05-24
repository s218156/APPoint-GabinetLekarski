using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    internal class GetDrugsHandler : IRequestHandler<GetDrugsRequest, GetDrugsDTO>
    {
        private readonly IDrugService _drugService;

        public GetDrugsHandler(IDrugService drugService)
        {
            _drugService = drugService;
        }

        public Task<GetDrugsDTO> Handle(GetDrugsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetDrugsDTO() { Drugs = _drugService.GetAll() });
        }
    }
}
