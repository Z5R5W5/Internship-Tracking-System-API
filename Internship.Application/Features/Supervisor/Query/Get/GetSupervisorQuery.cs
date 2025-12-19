using Internship.Application.Features.Supervisor.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Query.Get
{
    public record GetSupervisorQuery 
    (int Id) : IRequest<Result<SupervisorResponse>>;
}
