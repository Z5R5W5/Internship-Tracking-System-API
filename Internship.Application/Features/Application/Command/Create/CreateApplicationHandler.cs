using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Create
{
    public class CreateApplicationHandler : IRequestHandler<CraetaAppliactionCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateApplicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CraetaAppliactionCommand request, CancellationToken cancellationToken)
        {
            var application = new Domain.Models.Application
            {
                ApplicationDate = request.ApplicationDate,
                Status = request.Status,
                StudentId = request.StudentId,
                InternshipOfferId = request.InternshipOfferId
            };
            await _unitOfWork.Repository<Domain.Models.Application>().AddAsync(application);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success(application.Id);

        }
    }
}
