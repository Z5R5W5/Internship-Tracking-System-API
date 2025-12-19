using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Create
{
    public class CreateReportValidator :AbstractValidator<CreateReportCommand>
    {
        public CreateReportValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.SubmissionDate)
                .NotEmpty().WithMessage("Submission date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Submission date cannot be in the future.");
            RuleFor(x=> x.ReportType)
                .NotEmpty().WithMessage("Report type is required.")
                .MaximumLength(50).WithMessage("Report type cannot exceed 50 characters.");
            RuleFor(x=>x.StudentId)
                .GreaterThan(0).WithMessage("StudentId must be a positive integer.");


        }
    }
}
