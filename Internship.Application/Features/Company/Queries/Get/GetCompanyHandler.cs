using Internship.Application.Features.Company.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Queries.Get
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyQuery, Result<CompanyResponse>>
    {
        private readonly IIdentityService _identityService;
        public GetCompanyHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<CompanyResponse>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var companyResult = await _identityService.GetUserByIdAsync(request.Id);
            if (companyResult == null)
            {
                return Result<CompanyResponse>.Failure("Company not found", 404);
            }
            var company = companyResult.Value;
            var response = new CompanyResponse
            {
                Id = company.Id,
                FirstName = company.FirstName,
                LastName = company.LastName,
                DisplayName = company.DisplayName,
                Email = company.Email
            };
            return Result<CompanyResponse>.Success(response);
        }
    }
}
