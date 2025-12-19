using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Delete
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Repository<Domain.Models.Company>().GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            _unitOfWork.Repository<Domain.Models.Company>().Delete(company);
            await _unitOfWork.CompleteAsync();
            return company.Id;
        }
    }
}
