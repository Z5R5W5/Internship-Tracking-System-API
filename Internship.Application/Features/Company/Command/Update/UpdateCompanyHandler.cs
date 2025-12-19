using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Repository<Domain.Models.Company>().GetByIdAsync(request.Id);
            if (company == null)
            {
                return Result.Failure("Company not found.", 404);
            }
            company.Name = request.Name;
            company.ContactEmail = request.ContactEmail;
            company.Address = request.Address;
            _unitOfWork.Repository<Domain.Models.Company>().Update(company);
            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
