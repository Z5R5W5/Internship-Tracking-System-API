using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Delete
{
    public record DeleteApplicationCommand
    (
         int Id
    ) : IRequest<bool>;
}
