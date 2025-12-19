using Internship.Application.Features.Student.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Query.Get
{
    public record GetStudentQuery
    (int Id) : IRequest<Result<StudentResponse>>;
}
