using Internship.Application.Interfaces;
using Internship.Domain;
using Internship.Infrastructure;

namespace Internship.Tracking.Api.Extentions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            return Services;
        }
    }
}
