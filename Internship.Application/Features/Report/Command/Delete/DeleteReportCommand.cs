using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Delete
{
    public record DeleteReportCommand
    
    (
        int Id
    ): IRequest<bool> ;
}
