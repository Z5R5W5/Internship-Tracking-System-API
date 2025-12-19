using Internship.Application.Features.Application.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Query.Get
{
    public record GetApplicationQuery
    (int Id):IRequest<Result<ApplicationResponse>>;
}
