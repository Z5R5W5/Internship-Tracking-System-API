using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Update
{
    public record UpdateReportCommand
        (
        int Id,
        string Title,
        string Content,
        DateTime SubmissionDate,
        string ReportType,
        int StudentId) : IRequest<Result>;

}
