using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Update
{
    public class UpdateSupervisorHandler : IRequestHandler<UpdateSupervisorCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public UpdateSupervisorHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public Task<Result<string>> Handle(UpdateSupervisorCommand request, CancellationToken cancellationToken)
        {
            return _identityService.UpdateUserAsync(
                request.Id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.DisplayName,
                request.role,
                null, // universityId
                null, // major
                request.InternshipOfferId
                );
        }
    }
}
