using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Onboarding.Infrastructure.Persistence
{
    public class OnboardingDbContextFactory : IDesignTimeDbContextFactory<OnboardingDbContext>
    {
        public OnboardingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnboardingDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
            Console.WriteLine(Environment.GetEnvironmentVariable("ConnectionString"));

            return new OnboardingDbContext(optionsBuilder.Options);
        }
    }
}
