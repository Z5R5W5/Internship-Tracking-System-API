using Internship.Application.Features.Report.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Query.List
{
    public class ListReportsHandler : IRequestHandler<ListReportsQuery, Result<List<ReportResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public ListReportsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<ReportResponse>>> Handle(ListReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await unitOfWork.Repository<Domain.Models.Report>().GetAllAsync(R=>R.Student);
            if (reports == null || !reports.Any())
            {
                return Result<List<ReportResponse>>.Failure("No reports found", 404);
            }
            var response = reports.Select(report => new ReportResponse
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                SubmissionDate = report.SubmissionDate,
                ReportType = report.ReportType,
                StudrntName = report.Student.FirstName + " " + report.Student.LastName
            }).ToList();
            return Result < List < ReportResponse >>.Success( response);
        }
    }
}
