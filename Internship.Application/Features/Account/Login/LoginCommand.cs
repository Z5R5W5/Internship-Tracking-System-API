using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Account.Login
{
    public record LoginCommand
    (
         string Email ,
         string Password
    ):IRequest<Result<string>>;
}
