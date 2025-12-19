using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Create
{
    public class CreateReportHandler : IRequestHandler<CreateReportCommand, Result<int>>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateReportHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Domain.Models.Report
            {
                Title = request.Title,
                Content = request.Content,
                SubmissionDate = request.SubmissionDate,
                ReportType = request.ReportType,
                StudentId = request.StudentId
            };
            await unitOfWork.Repository<Domain.Models.Report>().AddAsync(report);
            await unitOfWork.CompleteAsync();
            return Result<int>.Success(report.Id);
        }
    }
}
