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
        private readonly IIdentityService _identityService; 
        public ListCompaniesHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<List<CompanyResponse>>> Handle(ListCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companiesResult = await _identityService.GetUsersByRoleAsync("Company");
            if (companiesResult == null )
            {
                return Result<List<CompanyResponse>>.Failure("No companies found", 404);
            }
            var response = companiesResult.Value.Select(company => new CompanyResponse
            {
                Id = company.Id,
                FirstName = company.FirstName,
                LastName = company.LastName,
                DisplayName = company.DisplayName,
                Email = company.Email
            }).ToList();
            return Result<List<CompanyResponse>>.Success(response);
        }
    }
}
