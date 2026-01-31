using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Account.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserResponseDto>>>
    {
        private readonly IIdentityService _identityService;
        public GetAllUsersQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result<List<UserResponseDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _identityService.GetAllUsersAsync();
        }
    }
}
