using Internship.Application.Features.Supervisor.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Query.Get
{
    public class GetSupervisorHandler : IRequestHandler<GetSupervisorQuery, Result<SupervisorResponse>>
    {
        private readonly IIdentityService _identityService;
        public GetSupervisorHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<SupervisorResponse>> Handle(GetSupervisorQuery request, CancellationToken cancellationToken)
        {
            var supervisorResult = await _identityService.GetUserByIdAsync(request.Id);

            if (supervisorResult.IsFailure)
            {
                return Result<SupervisorResponse>.Failure("Supervisor not found");
            }

            var supervisor = supervisorResult.Value;

            var response = new SupervisorResponse
            {
                Id = supervisor.Id,
                FirstName = supervisor.FirstName,
                LastName = supervisor.LastName,
                Email = supervisor.Email,
                DisplayName = supervisor.DisplayName,
                Role = "Supervisor",
                InternshipOfferId = supervisor.AcceptedInternshipId
            };

            return Result<SupervisorResponse>.Success(response);
        }
    }
}
