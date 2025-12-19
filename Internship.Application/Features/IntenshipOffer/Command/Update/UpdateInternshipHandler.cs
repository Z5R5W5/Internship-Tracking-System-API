using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Update
{
    public class UpdateInternshipHandler : IRequestHandler<UpdateInternshipCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateInternshipHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateInternshipCommand request, CancellationToken cancellationToken)
        {
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.Id);
            var company = await _unitOfWork.Repository<Domain.Models.Company>().GetByIdAsync(request.CompanyId);
            if (company == null)
            {
                return Result.Failure("Company not found.", 404);
            }
            if (internshipOffer == null)
            {
                return Result.Failure("Internship Offer not found.", 404);
            }
            internshipOffer.Title = request.Title;
            internshipOffer.Description = request.Description;
            internshipOffer.StartDate = request.StartDate;
            internshipOffer.EndDate = request.EndDate;
            internshipOffer.Location = request.Location;
            internshipOffer.RequiredStudentsCount = request.RequiredStudentsCount;
            internshipOffer.CompanyId = request.CompanyId;
            internshipOffer.IsActive = request.IsActive;
            _unitOfWork.Repository<Domain.Models.InternshipOffer>().Update(internshipOffer);
            await _unitOfWork.CompleteAsync();
            return Result.Success();

        }
    }
}
