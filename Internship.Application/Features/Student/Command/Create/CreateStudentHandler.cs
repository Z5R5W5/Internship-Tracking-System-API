using Internship.Application.Interfaces;
using Internship.Application.Results;
using Internship.Domain.Models.identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Create
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        
        public CreateStudentHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            return await _identityService.RegisterAsync(request.FirstName, request.LastName, request.UniversityId, request.Major, request.Email, request.Password, request.DisplayName, request.role);

        }
    }
}
