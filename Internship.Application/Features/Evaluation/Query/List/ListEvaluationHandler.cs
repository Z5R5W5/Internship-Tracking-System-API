using Internship.Application.Features.Evaluation.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Query.List
{
    public class ListEvaluationHandler : IRequestHandler<ListEvaluationsQuery, Result<List<EvaluationResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListEvaluationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<EvaluationResponse>>> Handle(ListEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var evaluations = await _unitOfWork.Repository<Domain.Models.Evaluation>().GetAllAsync( E => E.Supervisor, E => E.InternshipOffer);
            var response = evaluations.Select(evaluation => new EvaluationResponse
            {
                Id = evaluation.Id,
                Score = evaluation.Score,
                Comments = evaluation.Comments,
                EvaluationDate = evaluation.EvaluationDate,
                SupervisorName = evaluation.Supervisor.FullName,
                InternshipOfferTitle = evaluation.InternshipOffer.Title
            }).ToList();
            return Result < List < EvaluationResponse >>.Success( response);
        }
    }
}
