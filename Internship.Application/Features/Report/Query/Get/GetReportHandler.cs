using Internship.Application.Features.Report.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Query.Get
{
    public class GetReportHandler : IRequestHandler<GetReportQuery, Result<ReportResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetReportHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<ReportResponse>> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            var report = await unitOfWork.Repository<Domain.Models.Report>().GetByIdAsync(request.Id,R=>R.Student);
            if (report == null)
            {
                return Result<ReportResponse>.Failure("Report not found", 404);
            }
            var response = new ReportResponse
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                SubmissionDate = report.SubmissionDate,
                ReportType = report.ReportType,
                StudrntName = report.Student.FirstName + " " + report.Student.LastName
            };
            return Result < ReportResponse >.Success( response);
        }
    }
}
