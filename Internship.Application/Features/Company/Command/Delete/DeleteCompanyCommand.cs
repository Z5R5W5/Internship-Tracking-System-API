using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Delete
{
    public record DeleteCompanyCommand
    (
        int Id

     ) : IRequest<int>;
}
