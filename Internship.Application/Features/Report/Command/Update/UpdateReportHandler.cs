using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Update
{
    public class UpdateReportHandler : IRequestHandler<UpdateReportCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;
        public UpdateReportHandler(IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            _unitOfWork = unitOfWork;
            _identityService = identityService;
        }
        public async Task<Result> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {

            var report = await _unitOfWork.Repository<Domain.Models.Report>().GetByIdAsync(request.Id);
            var student = await _identityService.GetUserByIdAsync(request.StudentId);
            if (student == null)
            {
                return Result.Failure("Student not found.", 404);
            }
            if (report == null)
            {
                return Result.Failure("Report not found.", 404);
            }
            report.Title = request.Title;
            report.Content = request.Content;
            report.SubmissionDate = request.SubmissionDate;
            report.ReportType = request.ReportType;
            report.StudentId = request.StudentId;

            _unitOfWork.Repository<Domain.Models.Report>().Update(report);
            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
