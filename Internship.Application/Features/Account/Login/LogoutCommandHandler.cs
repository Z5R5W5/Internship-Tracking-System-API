using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Account.Login
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<string>>
    {
        private readonly IIdentityService _identityService;
        public LogoutCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.LogoutAsync();
        }
    }
}
