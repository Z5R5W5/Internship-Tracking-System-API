using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Delete
{
    public record DeleteSupervisorCommand
    (int Id):IRequest<bool>;
}
