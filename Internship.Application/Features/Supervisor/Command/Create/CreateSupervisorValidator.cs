using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Create
{
    public class CreateSupervisorValidator: AbstractValidator<CreateSupervisorCommand>
    {
        public CreateSupervisorValidator() 
        {
            RuleFor(x=>x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");
            RuleFor(x=>x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .MaximumLength(50).WithMessage("Role cannot exceed 50 characters.");
            RuleFor(x=>x.InternshipOfferId)
                .GreaterThan(0).WithMessage("Internship Offer ID must be a positive integer.");

        }
    }
}
