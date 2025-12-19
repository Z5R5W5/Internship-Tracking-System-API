using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Update
{
    public record UpdateInternshipCommand
    (
        int Id,
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        bool IsActive,
        string Location,
        int RequiredStudentsCount,
        int CompanyId

    ) : IRequest<Result>;
}
