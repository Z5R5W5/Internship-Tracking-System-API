using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Update
{
    public class UpdateApplicationHandler : IRequestHandler<UpdateApplicationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateApplicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.Repository<Domain.Models.Application>().GetByIdAsync(request.Id);
            var student = await _unitOfWork.Repository<Domain.Models.Student>().GetByIdAsync(request.StudentId);
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.InternshipOfferId);
            if (student == null)
            {
                return Result.Failure("Student not found.");
            }
            if (internshipOffer == null)
            {
                return Result.Failure("Internship Offer not found.");
            }
            if (application == null)
            {
                return Result.Failure("Application not found.");
            }
            
            application.ApplicationDate = request.ApplicationDate;
            application.Status = request.Status;
            application.StudentId = request.StudentId;
            application.InternshipOfferId = request.InternshipOfferId;
            _unitOfWork.Repository<Domain.Models.Application>().Update(application);
            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
