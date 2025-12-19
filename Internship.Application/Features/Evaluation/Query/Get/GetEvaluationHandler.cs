using Internship.Application.Features.Evaluation.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Query.Get
{
    public class GetEvaluationHandler : IRequestHandler<GetEvaluationQuery, Result<EvaluationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEvaluationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<EvaluationResponse>> Handle(GetEvaluationQuery request, CancellationToken cancellationToken)
        {
            var evaluation = await _unitOfWork.Repository<Domain.Models.Evaluation>().GetByIdAsync(request.Id,E=>E.Supervisor,E=>E.InternshipOffer);
            if (evaluation == null)
            {
                return Result<EvaluationResponse>.Failure("Evaluation not found", 404);
            }
            
            var response = new EvaluationResponse
            {
                Id = evaluation.Id,
                Score = evaluation.Score,
                Comments = evaluation.Comments,
                EvaluationDate = evaluation.EvaluationDate,
                SupervisorName = evaluation.Supervisor.FullName,
                InternshipOfferTitle = evaluation.InternshipOffer.Title
            };
            return Result < EvaluationResponse >.Success( response);
        }
    }
}
