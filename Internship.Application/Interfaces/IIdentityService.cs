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
            string firstName,
            string lastName,
            string email,
            string password,
            string displayName,
            string role,
            string? universityId = null,
            string? major = null,
            int? internshipOfferId = null
        );
        Task<Result<string>> LoginAsync(
             string email,
             string password,
             string role
         );
        Task<Result<List<UserResponseDto>>> GetAllUsersAsync();
        Task<Result<UserResponseDto>> GetCurrentUserAsync();
        Task<Result<string>> LogoutAsync();
        Task<Result<string>> DeleteUserAsync(string userId);
        Task<Result<string>> UpdateUserAsync(
            string userId,
            string firstName,
            string lastName,
            string email,
            string password,
            string displayName,
            string role,
            string? universityId = null,
            string? major = null,
            int? internshipOfferId = null
        );
        Task<Result<List<UserResponseDto>>> GetUsersByRoleAsync(string role);
        // get user by id
        Task<Result<UserResponseDto>> GetUserByIdAsync(string userId);
    }
}
