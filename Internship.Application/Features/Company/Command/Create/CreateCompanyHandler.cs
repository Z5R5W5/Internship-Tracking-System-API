using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public CreateCompanyHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password, request.DisplayName, request.role);
        }
    }
}
