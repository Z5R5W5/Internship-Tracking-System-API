using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Delete
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public DeleteStudentHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.DeleteUserAsync(request.Id);
        }
    }
}
