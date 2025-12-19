using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Command.Create
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Company address is required.")
                .MaximumLength(200).WithMessage("Company address cannot exceed 200 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required.")
                .EmailAddress().WithMessage("Contact email must be a valid email address.")
                .MaximumLength(100).WithMessage("Contact email cannot exceed 100 characters.");
        }
    }
}
