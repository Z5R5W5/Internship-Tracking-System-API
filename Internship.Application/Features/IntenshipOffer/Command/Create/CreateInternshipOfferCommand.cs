using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Create
{
    public record CreateInternshipOfferCommand
    (
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Location,
        int RequiredStudentsCount,
        int CompanyId

        ) :IRequest<Result<int>>;
}
