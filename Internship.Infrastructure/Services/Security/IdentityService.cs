using Internship.Application.Features.Account.Queries.GetAllUsers;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using Internship.Domain.Models.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Services.Security
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;
        private readonly SignInManager<AppUser> _signInManager;

        public IdentityService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenServices tokenServices)
        {
            _userManager = userManager;
            _tokenServices = tokenServices;
            _signInManager = signInManager;
        }

        public async Task<Result<List<UserResponseDto>>> GetAllUsersAsync()
        {
            var Users = await _userManager.Users.AsNoTracking().Select(user => new UserResponseDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserName = user.UserName,

            }).ToListAsync();
            return Result<List<UserResponseDto>>.Success(Users);

        }

        public async Task<Result<UserResponseDto>> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_signInManager.Context.User);
            if (user == null)
            {
                return Result<UserResponseDto>.Failure("User not found", 404);
            }
            return Result<UserResponseDto>.Success(new UserResponseDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UniversityId = user.UniversityId,
                Major = user.Major,
                AcceptedInternshipId = user.AcceptedInternshipId


            });

        }


        public async Task<Result<string>> LoginAsync(string email, string password, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Result<string>.Failure("Invalid email or password", 401);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                return Result<string>.Failure("Invalid email or password", 401);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains(role))
            {
                return Result<string>.Failure("Unauthorized", 403);
            }
            var token = await _tokenServices.CreateTokenAsync(user, _userManager);
            return Result<string>.Success(token);
        }

        public async Task<Result<string>> RegisterAsync(
            string firstName,
            string lastName,
            string email,
            string password,
            string displayName,
            string role,
            string? universityId = null,
            string? major = null,
            int? internshipOfferId = null
            )
        {
            var user = new AppUser
            {
                UserName = email,
                Email = email,
                DisplayName = displayName,

                FirstName = firstName,
                LastName = lastName,
                UniversityId = universityId,
                Major = major,
                AcceptedInternshipId = internshipOfferId
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return Result<string>.Failure(string.Join(", ", errors), 400);
            }
            //add role to user
            await _userManager.AddToRoleAsync(user, role);

            //await _userManager.AddToRoleAsync(user, role);
            var token = await _tokenServices.CreateTokenAsync(user, _userManager);
            return Result<string>.Success(token);

        }
        //logout user
        public async Task<Result<string>> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Result<string>.Success("User logged out successfully");
        }
        // Delete user by id
        public async Task<Result<string>> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result<string>.Failure("User not found", 404);
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return Result<string>.Failure(string.Join(", ", errors), 400);
            }
            return Result<string>.Success("User deleted successfully");


        }
        public async Task<Result<string>> UpdateUserAsync(
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
            )
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result<string>.Failure("User not found", 404);
            }
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.UserName = email;
            user.DisplayName = displayName;
            user.UniversityId = universityId;
            user.Major = major;
            user.AcceptedInternshipId = internshipOfferId;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return Result<string>.Failure(string.Join(", ", errors), 400);
            }
            //update password
            if (!string.IsNullOrEmpty(password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, password);
                if (!passwordResult.Succeeded)
                {
                    var errors = passwordResult.Errors.Select(e => e.Description);
                    return Result<string>.Failure(string.Join(", ", errors), 400);
                }
            }
            //update role
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, role);
            }
            return Result<string>.Success("User updated successfully");
        }

        public async Task<Result<List<UserResponseDto>>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            var userDtos = users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UniversityId = user.UniversityId,
                Major = user.Major,
                AcceptedInternshipId = user.AcceptedInternshipId

            }).ToList();
            return Result<List<UserResponseDto>>.Success(userDtos);
        }
        public async Task<Result<UserResponseDto>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result<UserResponseDto>.Failure("User not found", 404);
            }
            var userDto = new UserResponseDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UniversityId = user.UniversityId,
                Major = user.Major,
                AcceptedInternshipId = user.AcceptedInternshipId
            };
            return Result<UserResponseDto>.Success(userDto);
        }
    }
}
