using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Domain.Models.Company
            {
                Name = request.Name,
                ContactEmail = request.ContactEmail,
                Address = request.Address
            };
            await _unitOfWork.Repository<Domain.Models.Company>().AddAsync(company);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success(company.Id);
        }
    }
}
