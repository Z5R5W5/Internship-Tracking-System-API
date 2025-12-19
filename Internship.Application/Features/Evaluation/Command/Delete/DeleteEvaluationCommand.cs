using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Delete
{
    public record DeleteEvaluationCommand
    (
        int Id
    ) : IRequest<bool>;
}
