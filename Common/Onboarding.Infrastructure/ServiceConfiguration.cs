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
            string dbConnectionString = Environment.GetEnvironmentVariable("ConnectionString");

            if (string.IsNullOrEmpty(dbConnectionString))
                dbConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OnboardingDbContext>(
                options => options.UseSqlServer(dbConnectionString)
            );

            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
