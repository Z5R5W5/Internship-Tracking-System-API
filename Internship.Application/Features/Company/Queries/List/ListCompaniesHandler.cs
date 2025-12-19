using Internship.Application.Features.Company.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Queries.List
{
    public class ListCompaniesHandler : IRequestHandler<ListCompaniesQuery, Result<List<CompanyResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListCompaniesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<CompanyResponse>>> Handle(ListCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _unitOfWork.Repository<Domain.Models.Company>().GetAllAsync();
            if (companies == null || !companies.Any())
            {
                return Result<List<CompanyResponse>>.Failure("No companies found", 404);
            }
            var response = companies.Select(company => new CompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                ContactEmail = company.ContactEmail,
                Address = company.Address
            }).ToList();
            return Result < List < CompanyResponse >>.Success( response);
        }
    }
}
