using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Delete
{
    public record DeleteStudentCommand
    (int Id):IRequest<bool>;
}
