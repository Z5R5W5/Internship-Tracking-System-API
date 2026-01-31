using Internship.Domain.Models.identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Interfaces
{
    public interface ITokenServices
    {
        Task<string>CreateTokenAsync(AppUser user,UserManager<AppUser> userManager);
    }
}
