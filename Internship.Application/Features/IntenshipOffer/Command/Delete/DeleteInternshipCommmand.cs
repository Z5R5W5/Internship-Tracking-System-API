using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Command.Delete
{
    public record DeleteInternshipCommmand
    (
        int Id
    ) : IRequest<int>;
}
