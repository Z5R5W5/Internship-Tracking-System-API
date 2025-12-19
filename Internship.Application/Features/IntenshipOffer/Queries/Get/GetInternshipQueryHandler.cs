using Internship.Application.Features.IntenshipOffer.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Queries.Get
{
    public class GetInternshipQueryHandler : IRequestHandler<GetInternshipQuery, Result<InternshipResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInternshipQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<InternshipResponse>> Handle(GetInternshipQuery request, CancellationToken cancellationToken)
        {
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.Id,I=> I.Company);
            if (internshipOffer == null)
            {
                return Result<InternshipResponse>.Failure("Internship offer not found", 404);
            }
            var response = new InternshipResponse
            {
                Id = internshipOffer.Id,
                Title = internshipOffer.Title,
                Description = internshipOffer.Description,
                Location = internshipOffer.Location,
                StartDate = internshipOffer.StartDate,
                EndDate = internshipOffer.EndDate,
                RequiredStudentsCount = internshipOffer.RequiredStudentsCount,
                IsActive = internshipOffer.IsActive,
                CompanyName = internshipOffer.Company.Name
            };
            return Result < InternshipResponse >.Success( response);
        }
    }
}
