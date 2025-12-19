using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Update
{
    public class UpdateEvaluationValidator : AbstractValidator<UpdateEvaluationCommand>
    {
        public UpdateEvaluationValidator() {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be a positive integer.");
            RuleFor(x => x.Score)
                .InclusiveBetween(1, 100)
                .WithMessage("Score must be between 1 and 10.");
            RuleFor(x => x.Comments)
                .NotEmpty()
                .WithMessage("Comments cannot be empty.")
                .MaximumLength(1000)
                .WithMessage("Comments cannot exceed 1000 characters.");
            RuleFor(x => x.EvaluationDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Evaluation date cannot be in the future.");
            RuleFor(x => x.SupervisorId)
                .GreaterThan(0)
                .WithMessage("SupervisorId must be a positive integer.");
            RuleFor(x => x.InternshipOfferId)
                .GreaterThan(0)
                .WithMessage("InternshipOfferId must be a positive integer.");
        }
    }
}
