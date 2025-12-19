using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Create
{
    public class CreateApplicationValidator : AbstractValidator<CraetaAppliactionCommand>
    {
        public CreateApplicationValidator() 
        {
            RuleFor(x => x.ApplicationDate)
                .NotEmpty().WithMessage("Application date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Application date cannot be in the future.");
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status cannot exceed 20 characters.");
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("StudentId must be a positive integer.");
            RuleFor(x => x.InternshipOfferId)
                .GreaterThan(0).WithMessage("InternshipOfferId must be a positive integer.");
        }
    }
}
