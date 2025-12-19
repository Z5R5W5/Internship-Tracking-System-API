using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Create
{
    public class CreateInternshipOfferHandler : IRequestHandler<CreateInternshipOfferCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateInternshipOfferHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateInternshipOfferCommand request, CancellationToken cancellationToken)
        {
            var internshipOffer = new Domain.Models.InternshipOffer
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                RequiredStudentsCount = request.RequiredStudentsCount,
                CompanyId = request.CompanyId,
                IsActive = true
            };
           await _unitOfWork.Repository<Domain.Models.InternshipOffer>().AddAsync(internshipOffer);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success( internshipOffer.Id);
        }
    }
}
