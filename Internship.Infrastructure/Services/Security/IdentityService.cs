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
            var Users= await _userManager.Users.AsNoTracking().Select(user => new UserResponseDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserName = user.UserName
            }).ToListAsync();
            return  Result<List<UserResponseDto>>.Success(Users);

        }

        public async Task<Result<string>> LoginAsync(string email, string password)
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
            var token = await _tokenServices.CreateTokenAsync(user, _userManager);
            return Result<string>.Success(token);
        }

        public async  Task<Result<string>> RegisterAsync(
            string email,
            string password,
            string displayName
            )
        {
            var user = new AppUser
            {
                UserName = email,
                Email = email,
                DisplayName = displayName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return Result<string>.Failure(string.Join(", ", errors), 400);
            }

            //await _userManager.AddToRoleAsync(user, role);
            var token = await _tokenServices.CreateTokenAsync(user, _userManager);
            return Result<string>.Success(token);

        }

     
    }
}
