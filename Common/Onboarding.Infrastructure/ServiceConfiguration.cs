using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Onboarding.Infrastructure.Persistence;
using Onboarding.Infrastructure.Repository;

namespace Onboarding.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<OnboardingDbContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("OnboardingDB"))
            );

            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
