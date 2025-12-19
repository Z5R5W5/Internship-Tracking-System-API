using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Create
{
    public class CreateEvaluationValidator : AbstractValidator<CreateEvaluationCommand>
    {
        public CreateEvaluationValidator() 
        {
            RuleFor(x => x.Score)
                .InclusiveBetween(0, 100).WithMessage("Score must be between 0 and 100.");
            RuleFor(x => x.Comments)
                .NotEmpty().WithMessage("Comments are required.")
                .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters.");
            RuleFor(x => x.EvaluationDate)
                .NotEmpty().WithMessage("Evaluation date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Evaluation date cannot be in the future.");
            RuleFor(x => x.SupervisorId)
                .GreaterThan(0).WithMessage("Supervisor ID must be a positive integer.");
            RuleFor(x => x.InternshipOfferId)
                .GreaterThan(0).WithMessage("Internship Offer ID must be a positive integer.");

        }
    }
}
