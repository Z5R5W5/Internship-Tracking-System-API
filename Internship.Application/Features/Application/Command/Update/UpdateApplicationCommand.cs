using Internship.Application.Features.Application.Command.Create;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Update
{
    public record UpdateApplicationCommand(
        int Id,
        DateTime ApplicationDate,
        string Status,
        int StudentId,
        int InternshipOfferId
        ) :IRequest<Result>;


}
