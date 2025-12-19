using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Create
{
    public class CreateEvaluationHandler : IRequestHandler<CreateEvaluationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEvaluationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var evaluation = new Domain.Models.Evaluation
            {
                Score = request.Score,
                Comments = request.Comments,
                EvaluationDate = request.EvaluationDate,
                SupervisorId = request.SupervisorId,
                InternshipOfferId = request.InternshipOfferId
            };
            await _unitOfWork.Repository<Domain.Models.Evaluation>().AddAsync(evaluation);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success(evaluation.Id);
        }
    }
}
