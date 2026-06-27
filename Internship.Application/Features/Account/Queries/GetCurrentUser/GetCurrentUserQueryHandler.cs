using Internship.Application.Features.Account.Queries.GetAllUsers;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Account.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Result<UserResponseDto>>
    {
        private readonly IIdentityService _userService;
        public GetCurrentUserQueryHandler(IIdentityService userService)
        {
            _userService = userService;
        }
        public async Task<Result<UserResponseDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
           return await _userService.GetCurrentUserAsync();
        }
    }
}
