using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Update
{
    public class UpdateEvaluationHandler : IRequestHandler<UpdateEvaluationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEvaluationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var evaluation = await _unitOfWork.Repository<Domain.Models.Evaluation>().GetByIdAsync(request.Id);
            var supervisor = await _unitOfWork.Repository<Domain.Models.Supervisor>().GetByIdAsync(request.SupervisorId);
            var internshipOffer = await _unitOfWork.Repository<Domain.Models.InternshipOffer>().GetByIdAsync(request.InternshipOfferId);
            if (supervisor == null)
            {
                return Result.Failure("Supervisor not found.", 404);
            }
            if (internshipOffer == null)
            {
                return Result.Failure("Internship Offer not found.", 404);
            }
            if (evaluation == null)
            {
                return Result.Failure("Evaluation not found.", 404);
            }
            evaluation.Score = request.Score;
            evaluation.Comments = request.Comments;
            evaluation.EvaluationDate = request.EvaluationDate;
            evaluation.SupervisorId = request.SupervisorId;
            evaluation.InternshipOfferId = request.InternshipOfferId;
            _unitOfWork.Repository<Domain.Models.Evaluation>().Update(evaluation);
            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
