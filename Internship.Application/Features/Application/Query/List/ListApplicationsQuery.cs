using Internship.Application.Features.Application.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Query.List
{
    public record ListApplicationsQuery
    () : IRequest<Result<List<ApplicationResponse>>>;
}
