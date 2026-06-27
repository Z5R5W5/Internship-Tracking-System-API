using Internship.Application.Interfaces;
using Internship.Application.Results;
using Internship.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Create
{
    public class CreateSupervisorHandler : IRequestHandler<CreateSupervisorCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public CreateSupervisorHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.DisplayName,
                request.role,
                null, // universityId
                null, // major
                request.InternshipOfferId // internshipOfferId
            );
        }
    }
}
