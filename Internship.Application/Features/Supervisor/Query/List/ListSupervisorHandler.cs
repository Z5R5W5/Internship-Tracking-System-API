using Internship.Application.Features.Supervisor.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Query.List
{

    public class ListSupervisorHandler : IRequestHandler<ListSupervisorQueries, Result<List<SupervisorResponse>>>
    {
        private readonly IIdentityService _identityService;
        public ListSupervisorHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<List<SupervisorResponse>>> Handle(ListSupervisorQueries request, CancellationToken cancellationToken)
        {
            var result = await _identityService.GetUsersByRoleAsync("Supervisor");

            if (result.IsFailure)
                return Result<List<SupervisorResponse>>
                    .Failure("Not Found Supervisors");

            var supervisorResponses = result.Value
                .Select(s => new SupervisorResponse
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    DisplayName = s.DisplayName
                })
                .ToList();

            return Result<List<SupervisorResponse>>
                .Success(supervisorResponses);
        }
    }
}
