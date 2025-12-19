using Internship.Application.Features.Report.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Query.Get
{
    public record GetReportQuery
    (int Id
    ):IRequest<Result<ReportResponse>>;
}
