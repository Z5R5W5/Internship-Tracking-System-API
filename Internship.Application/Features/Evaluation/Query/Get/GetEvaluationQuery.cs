using Internship.Application.Features.Evaluation.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Query.Get
{
    public record GetEvaluationQuery
    (
        int Id
    ) : IRequest<Result<EvaluationResponse>>;
}
