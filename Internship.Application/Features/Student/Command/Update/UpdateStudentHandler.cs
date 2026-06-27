using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Update
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public UpdateStudentHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.UpdateUserAsync(
                request.Id,
                request.FirstName,
                request.LastName,
                
                request.Email,
                request.Password,
                request.DisplayName,
                request.role,
                null, // universityId
                null, // major
                request.AcceptedInternshipId);
            
        }
    }
}
