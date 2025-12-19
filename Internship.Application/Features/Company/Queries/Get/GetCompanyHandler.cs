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
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  async Task<Result<CompanyResponse>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Repository<Domain.Models.Company>().GetByIdAsync(request.Id);
            if (company == null)
            {
                return Result<CompanyResponse>.Failure("Company not found", 404);
            }
            var response = new CompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                ContactEmail = company.ContactEmail,
                Address = company.Address
            };
            return Result < CompanyResponse >.Success( response);
        }
    }
}
