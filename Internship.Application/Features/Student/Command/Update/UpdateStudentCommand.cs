using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Update
{
    public record UpdateStudentCommand
    (
        string Id,
        string FirstName,
        string LastName,
        string UniversityId,
        string Major,
        string Email,
        string Password,
        string DisplayName,
        string role,
        int? AcceptedInternshipId) : IRequest<Result<string>>;
}
