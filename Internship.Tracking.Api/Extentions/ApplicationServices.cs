using Internship.Application.Interfaces;
using Internship.Domain;
using Internship.Infrastructure;
using Internship.Infrastructure.Services.Security;

namespace Internship.Tracking.Api.Extentions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddScoped<IIdentityService, IdentityService>();
            Services.AddScoped<ITokenServices, TokenServices>();
            
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            return Services;
        }
    }
}
