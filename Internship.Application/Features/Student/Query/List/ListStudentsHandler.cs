using Internship.Application.Features.Student.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Query.List
{
    public class ListStudentsHandler : IRequestHandler<ListStudentQueries, Result<List<StudentResponse>>>
    {
        private readonly IIdentityService _identityService;
        public ListStudentsHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<List<StudentResponse>>> Handle(ListStudentQueries request, CancellationToken cancellationToken)
        {
            var students = await _identityService.GetUsersByRoleAsync("Student");
            if (students == null )
            {
                return Result<List<StudentResponse>>.Failure("No students found.");
            }
            var studentResponses = students.Value.Select(s => new StudentResponse
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UniversityId = s.UniversityId,
                Major = s.Major,
                Email = s.Email
            }).ToList();
            return Result<List<StudentResponse>>.Success(studentResponses);
        }
    }
}
