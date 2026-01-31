using Internship.Application.Features.Account.Queries.GetAllUsers;
using Internship.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Interfaces
{
    public interface IIdentityService
    {
       Task<Result<string>> RegisterAsync(
           string email,
           string password,
           string displayName
        );
        Task<Result<string>> LoginAsync(
             string email,
             string password
         );
        Task<Result<List<UserResponseDto>>> GetAllUsersAsync();
    }
}
