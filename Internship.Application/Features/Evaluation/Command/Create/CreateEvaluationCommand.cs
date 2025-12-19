using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Create
{
    public record CreateEvaluationCommand
    (

        int Score,
        string Comments,
        DateTime EvaluationDate,
        int SupervisorId,
        int InternshipOfferId
    ) : IRequest<Result<int>>;
}
