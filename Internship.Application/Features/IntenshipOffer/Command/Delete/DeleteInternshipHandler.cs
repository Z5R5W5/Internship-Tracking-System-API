using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Delete
{
    public class DeleteInternshipHandler : IRequestHandler<DeleteInternshipCommmand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteInternshipHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteInternshipCommmand request, CancellationToken cancellationToken)
        {
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.Id);
            if (internshipOffer == null)
            {
                return default;
            }
            _unitOfWork.Repository<Domain.Models.InternshipOffer>().Delete(internshipOffer);
            await _unitOfWork.CompleteAsync();
            return internshipOffer.Id;
        }
    }
}
