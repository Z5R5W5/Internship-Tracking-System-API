using Internship.Application.Features.Evaluation.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Query.List
{
    public record ListEvaluationsQuery
    () : IRequest<Result<List<EvaluationResponse>>>;
}
