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
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Domain.Models.Student>().GetByIdAsync(request.Id);
            if (request.AcceptedInternshipId is not null)
            {
                var internship = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.AcceptedInternshipId.Value);
                student.AcceptedInternshipId = request.AcceptedInternshipId;

            }
            if (student == null)
            {
                return Result.Failure("Student not found.", 404);
            }
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Major = request.Major;
            student.UniversityId = request.UniversityId;

            _unitOfWork.Repository<Domain.Models.Student>().Update(student);
            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
