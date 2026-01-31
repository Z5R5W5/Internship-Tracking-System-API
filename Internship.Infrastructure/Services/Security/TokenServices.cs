using Internship.Application.Interfaces;
using Internship.Domain.Models.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Services.Security
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.DisplayName),
                new Claim(ClaimTypes.Name,user.Email),
            };
            var roles = await userManager.GetRolesAsync(user);
            Claims.AddRange(roles.Select(role=>new Claim(ClaimTypes.Role,role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebToken:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token=new JwtSecurityToken(
                issuer: _configuration["JsonWebToken:issuer"],
                audience: _configuration["JsonWebToken:audience"],
                claims: Claims,
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JsonWebToken:DurationInDays"])),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
