using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;

namespace Onboarding.Infrastructure.Persistence
{
    public class OnboardingDbContext : DbContext
    {
        public OnboardingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity
                    .Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Cicle).HasMaxLength(50);

                entity.Property(e => e.InternalContractCode).HasColumnType("bigint");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnType("int");
            });
        }
    }
}
