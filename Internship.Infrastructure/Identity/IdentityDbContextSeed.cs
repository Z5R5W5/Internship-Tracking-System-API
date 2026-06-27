using Internship.Domain.Models.identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Identity
{
    public static class IdentityDbContextSeed
    {
        public static async Task SeedRolesAsync(
            RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            {
            "Admin",
            "Student",
            "Company",
            "Supervisor"
        };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }
        }
        public static async Task SeedUsersAsync(
            UserManager<AppUser> userManager)
        {
            var admin = await userManager.FindByEmailAsync("admin@test.com");

            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    DisplayName = "System Admin"
                };

                await userManager.CreateAsync(admin, "Admin@123");

                await userManager.AddToRoleAsync(admin, "Admin");
            }
            var student = await userManager.FindByEmailAsync("ziadayman@gmail.com");
            if (student == null)
            {
                student = new AppUser
                {
                    UserName = "ziadayman@gmail.com",
                    Email = "ziadayman@gmail.com",
                    DisplayName = "Ziad Ayman"
                };
                await userManager.CreateAsync(student, "Student@123");
                await userManager.AddToRoleAsync(student, "Student");
            }
            var supervisor = await userManager.FindByEmailAsync("supervisor11@gmail.com");
            if (supervisor == null)
            {
                supervisor = new AppUser
                {
                    UserName = "supervisor11@gmail.com",
                    Email = "supervisor11@gmail.com",
                    DisplayName = "Supervisor 1"
                };
                await userManager.CreateAsync(supervisor, "Supervisor@123");
                await userManager.AddToRoleAsync(supervisor, "Supervisor");
            }
            

        }
    }
}
