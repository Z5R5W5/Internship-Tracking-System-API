using Internship.Application.Features.Student.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Query.Get
{
    public class GetStudentHandler : IRequestHandler<GetStudentQuery, Result<StudentResponse>>
    {
        private readonly IIdentityService _identityService;
        public GetStudentHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<StudentResponse>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var studentResult = await _identityService.GetUserByIdAsync(request.Id);
            if (studentResult == null)
            {
                return Result<StudentResponse>.Failure("Student not found", 404);
            }
            var student = studentResult.Value;
            var response = new StudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UniversityId = student.UniversityId,
                Major = student.Major,
                Email = student.Email
            };
            return Result<StudentResponse>.Success(response);

        }
    }
}
