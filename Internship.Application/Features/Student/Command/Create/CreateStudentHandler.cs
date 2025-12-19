using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Create
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Domain.Models.Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UniversityId = request.UniversityId,
                Major = request.Major,
                Email = request.Email,
                AcceptedInternshipId = request.AcceptedInternshipId
            };
            await _unitOfWork.Repository<Domain.Models.Student>().AddAsync(student);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success( student.Id);
        }
    }
}
