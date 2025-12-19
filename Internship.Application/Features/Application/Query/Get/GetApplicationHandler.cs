using Internship.Application.Features.Application.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Query.Get
{
    
    public class GetApplicationHandler : IRequestHandler<GetApplicationQuery, Result<ApplicationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetApplicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<ApplicationResponse>> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.Repository<Domain.Models.Application>().GetByIdAsync(request.Id,A=>A.Student,A=>A.InternshipOffer);
            if (application == null)
            {
                return Result<ApplicationResponse>.Failure("Application not found", 404);
            }
            var response = new ApplicationResponse
            {
                Id = application.Id,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status,
                StudentName = $"{application.Student.FirstName} {application.Student.LastName}",
                InternshipOfferTitle = application.InternshipOffer.Title
            };
            return Result<ApplicationResponse>.Success(response);
        }
    }
}
