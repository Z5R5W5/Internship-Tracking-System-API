using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public UpdateCompanyHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.UpdateUserAsync(request.Id, request.FirstName, request.LastName, request.Email, request.Password, request.DisplayName, request.role);
        }
    }
}
