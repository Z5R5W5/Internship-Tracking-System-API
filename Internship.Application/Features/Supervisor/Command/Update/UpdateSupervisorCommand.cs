using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Update
{
    public record UpdateSupervisorCommand
    (
        int Id,
        string FullName,
        string Email,
        string Role,
        int InternshipOfferId) : IRequest<Result>;
}
