using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Delete
{
    public class DeleteSupervisorHandler : IRequestHandler<DeleteSupervisorCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public DeleteSupervisorHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<string>> Handle(DeleteSupervisorCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.DeleteUserAsync(request.Id);

        }
    }
}
