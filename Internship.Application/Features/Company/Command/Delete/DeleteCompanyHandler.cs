using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Delete
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public DeleteCompanyHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.DeleteUserAsync(request.Id);
        }

        
    }
}
