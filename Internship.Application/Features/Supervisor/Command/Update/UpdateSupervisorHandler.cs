using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Update
{
    public class UpdateSupervisorHandler : IRequestHandler<UpdateSupervisorCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSupervisorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _unitOfWork.Repository<Domain.Models.Supervisor>().GetByIdAsync(request.Id);
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.InternshipOfferId);
            if (internshipOffer == null)
            {
                return Result.Failure("Internship Offer not found.", 404);
            }
            if (supervisor == null)
            {
                return Result.Failure("Supervisor not found.", 404);
            }
            supervisor.FullName = request.FullName;
            supervisor.Email = request.Email;
            supervisor.Role = request.Role;
            supervisor.InternshipOfferId = request.InternshipOfferId;

            _unitOfWork.Repository<Domain.Models.Supervisor>().Update(supervisor);
            await _unitOfWork.CompleteAsync();
            return Result.Success();

        }
    }
}
