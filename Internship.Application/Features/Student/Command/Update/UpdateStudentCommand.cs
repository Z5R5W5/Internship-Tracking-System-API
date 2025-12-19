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
        int Id,
        string FirstName,
        string LastName,
        string UniversityId,
        string Major,
        string Email,
        int? AcceptedInternshipId) : IRequest<Result>;
}
