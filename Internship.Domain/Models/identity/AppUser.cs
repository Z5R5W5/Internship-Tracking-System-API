using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models.identity
{
    public class AppUser : IdentityUser
    {
       public string DisplayName { get; set; } = string.Empty;
    }
}
