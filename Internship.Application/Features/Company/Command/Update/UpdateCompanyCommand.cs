using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Update
{
    public record UpdateCompanyCommand
    (
        int Id,
        string Name,
        string ContactEmail,
        string Address

    ) :IRequest<Result>;
}
