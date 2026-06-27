using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Create
{
    public record CreateSupervisorCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string DisplayName,
        string role,
        int InternshipOfferId
    ) : IRequest<Result<string>>;
}
