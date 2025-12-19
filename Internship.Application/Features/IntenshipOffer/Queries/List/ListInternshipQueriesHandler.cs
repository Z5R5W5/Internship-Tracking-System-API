using Internship.Application.Features.IntenshipOffer.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Queries.List
{
    public class ListInternshipQueriesHandler : IRequestHandler<ListInternshipQueries, Result<List<InternshipResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListInternshipQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<InternshipResponse>>> Handle(ListInternshipQueries request, CancellationToken cancellationToken)
        {
            
            var internshipOffers = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetAllAsync(I=>I.Company);
            if (internshipOffers == null || !internshipOffers.Any())
            {
                return Result<List<InternshipResponse>>.Failure("No internship offers found", 404);
            }
            var response = internshipOffers.Select(internshipOffer => new InternshipResponse
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
            }).ToList();
            return Result < List < InternshipResponse >>.Success( response);
        }
    }
}
