using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage("University ID is required.")
                .MaximumLength(20).WithMessage("University ID cannot exceed 20 characters.");
            RuleFor(x => x.Major)
                .NotEmpty().WithMessage("Major is required.")
                .MaximumLength(100).WithMessage("Major cannot exceed 100 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");
            RuleFor(x => x.AcceptedInternshipId)
                .GreaterThan(0).When(x => x.AcceptedInternshipId.HasValue)
                .WithMessage("Accepted Internship ID must be a positive integer if provided.");
        }
    }
}
