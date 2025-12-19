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
        private readonly IUnitOfWork _unitOfWork;
        public ListStudentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<StudentResponse>>> Handle(ListStudentQueries request, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.Repository<Domain.Models.Student>().GetAllAsync();
            if (students == null || !students.Any())
            {
                return Result<List<StudentResponse>>.Failure("No students found", 404);
            }
            var Response = students.Select(student=> new StudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UniversityId = student.UniversityId,
                Major = student.Major,
                Email = student.Email
                
            }).ToList();
            return Result < List < StudentResponse >>.Success( Response);
             
        }
    }
}
