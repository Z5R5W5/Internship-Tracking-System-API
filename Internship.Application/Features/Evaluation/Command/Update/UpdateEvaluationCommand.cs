using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Update
{
    public record UpdateEvaluationCommand
    (
        int Id,
        int Score,
        string Comments,
        DateTime EvaluationDate,
        int SupervisorId,
        int InternshipOfferId
    ) : IRequest<Result>;
}
