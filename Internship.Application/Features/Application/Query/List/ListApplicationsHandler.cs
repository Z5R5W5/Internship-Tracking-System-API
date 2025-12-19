using Internship.Application.Features.Application.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Query.List
{
    public class ListApplicationsHandler : IRequestHandler<ListApplicationsQuery, Result<List<ApplicationResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListApplicationsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<ApplicationResponse>>> Handle(ListApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = await _unitOfWork.Repository<Domain.Models.Application>().GetAllAsync(A=>A.Student,A=>A.InternshipOffer);
            if (applications == null || !applications.Any())
            {
                return Result<List<ApplicationResponse>>.Failure("No applications found", 404);
            }
            var response = applications.Select(application => new ApplicationResponse
            {
                Id = application.Id,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status,
                StudentName = $"{application.Student.FirstName} {application.Student.LastName}",
                InternshipOfferTitle = application.InternshipOffer.Title
            }).ToList();
            return Result < List < ApplicationResponse >> .Success(response);
        }
    }
}
