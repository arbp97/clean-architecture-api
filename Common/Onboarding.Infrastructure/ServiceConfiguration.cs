using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Onboarding.Infrastructure.Persistence;

namespace Onboarding.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<OnboardingDbContext>(
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            return services;
        }
    }
}
