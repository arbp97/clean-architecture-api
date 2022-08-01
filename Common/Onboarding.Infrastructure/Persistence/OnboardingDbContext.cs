using Microsoft.EntityFrameworkCore;

namespace Onboarding.Infrastructure.Persistence
{
    public class OnboardingDbContext : DbContext
    {
        public OnboardingDbContext(DbContextOptions options) : base(options) { }
    }
}
